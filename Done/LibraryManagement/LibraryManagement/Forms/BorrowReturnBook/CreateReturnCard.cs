using LibraryManagement.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;
using static System.Windows.Forms.AxHost;

namespace LibraryManagement.Forms
{
    public partial class CreateReturnCard : Form
    {
        public static Reader reader;
        public static string state;

        ReturnCard returnCard;

        BindingList<BorrowedBook> borrowBooks;
        BindingList<BorrowedBook> chosenBooks;

        BindingSource bindingBorrow;
        BindingSource bindingChosen;

        int maxDays;
        long finePerDay, fineThisPeriod;
        BorrowedBook addBook = null, removeBook = null;
        bool print;

        #region Init and custom form
        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn
        (
          int nLeftRect,     // x-coordinate of upper-left corner
          int nTopRect,      // y-coordinate of upper-left corner
          int nRightRect,    // x-coordinate of lower-right corner
          int nBottomRect,   // y-coordinate of lower-right corner
          int nWidthEllipse, // height of ellipse
          int nHeightEllipse // width of ellipse
        );

        protected override CreateParams CreateParams
        {
            get
            {
                const int CS_DROPSHADOW = 0x20000;
                CreateParams cp = base.CreateParams;
                cp.ClassStyle |= CS_DROPSHADOW;
                return cp;
            }
        }

        public CreateReturnCard()
        {
            InitializeComponent();

            Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 12, 12));
        }

        //Drag Form
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern bool ReleaseCapture();

        private void pnlTop_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }
        #endregion

        #region Load data to components
        private void CreateReturnCard_Load(object sender, EventArgs e)
        {
            state = "Init";
            btnAdd.BorderRadius = 20;
            btnRemove.BorderRadius = 20;
            btnExit.BorderRadius = 20;
            btnSave.BorderRadius = 20;
            btnSave.Enabled = false;

            this.dtgvBorrow.AutoGenerateColumns = false;
            this.dtgvChosen.AutoGenerateColumns = false;

            Parameters.LoadParam();
            maxDays = Parameters.maxBorrowDays;
            finePerDay = Parameters.finePerDay;

            borrowBooks = new BindingList<BorrowedBook>();
            chosenBooks = new BindingList<BorrowedBook>();
            bindingBorrow = new BindingSource();
            bindingChosen = new BindingSource();
            returnCard = new ReturnCard();

            UpdateTextBoxWhenChanged();
            LoadData();

            txbReturnCardId.Text = returnCard.id;
            txbReaderId.Text = reader.code;
            txbReaderName.Text = reader.name;
            tgBtnAskBeforePrint.Checked = print = false;
        }

        private void LoadData()
        {
            Thread tdGetReturnCard = new Thread(new ThreadStart(GetLastReturnCardId));
            Thread tdLoadBorrowedBooks = new Thread(new ThreadStart(GetBorrowedBooksByReaderId));

            tdGetReturnCard.Start();
            tdLoadBorrowedBooks.Start();

            tdLoadBorrowedBooks.Join();
        }

        private void GetLastReturnCardId()
        {
            //Get id of the last return card 
            SqlConnection conn = new SqlConnection(DatabaseInfo.connectionString);
            conn.Open();
            SqlCommand cmd = new SqlCommand(DatabaseInfo.getNewReturnSlipCode, conn);
            if (cmd.ExecuteScalar() != null)
            {
                string last = cmd.ExecuteScalar().ToString();
                int stt = int.Parse(last.Substring(4, 3)) + 1;
                returnCard.id = $"MPTS{stt:000}";
            }
            else
                returnCard.id = "MPTS001";
        }

        private void GetBorrowedBooksByReaderId()
        {
            //Get list of books were borrowed by cbbReaderId and fill datagridview
            SqlConnection conn = new SqlConnection(DatabaseInfo.connectionString);
            conn.Open();
            SqlCommand cmd = new SqlCommand(DatabaseInfo.GetBorrowedBooksByReaderId(reader.code), conn);
            using (SqlDataReader reader = cmd.ExecuteReader())
                while (reader.Read())
                {
                    BorrowedBook bb = new BorrowedBook(reader.GetString(0), reader.GetString(1), reader.GetString(2), reader.GetString(3), reader.GetDateTime(4).ToString("dd/MM/yyyy"), reader.GetDateTime(5).ToString("dd/MM/yyyy"));
                    UpdateBorrowDaysAndFine(bb);
                    borrowBooks.Add(bb);
                }
            conn.Close();

            bindingBorrow.DataSource = borrowBooks;
            dtgvBorrow.DataSource = bindingBorrow;
            bindingChosen.DataSource = chosenBooks;
            dtgvChosen.DataSource = bindingChosen;

            DateTime min = DateTime.ParseExact(borrowBooks[0].borrowDate, "dd/MM/yyyy", null);
            foreach (BorrowedBook bb in borrowBooks)
                if (DateTime.ParseExact(bb.borrowDate, "dd/MM/yyyy", null) < min)
                    min = DateTime.ParseExact(bb.borrowDate, "dd/MM/yyyy", null);
            dtpReturnDate.MinDate = min;

            ClearSelection(dtgvBorrow);
        }

        private void UpdateBorrowDaysAndFine(BorrowedBook bb)
        {
            bb.borrowedDays = Math.Abs((int)DateTime.ParseExact(bb.borrowDate, "dd/MM/yyyy", null).Subtract(dtpReturnDate.Value).TotalDays);
            if (bb.borrowedDays > maxDays)
            {
                bb.lateDays = bb.borrowedDays - maxDays;
                bb.fine = CalculateFine(bb.lateDays);
            }
            else
            {
                bb.lateDays = 0;
                bb.fine = 0;
            }
        }

        private long CalculateFine(int days)
        {
            long fine = finePerDay * days;
            return fine;
        }

        private long GetDebtByReaderId(string readerId)
        {
            SqlConnection conn = new SqlConnection(DatabaseInfo.connectionString);
            conn.Open();
            SqlCommand cmd = new SqlCommand(DatabaseInfo.GetDebtByReaderId(readerId), conn);
            return (long)(decimal)cmd.ExecuteScalar();
        }
        #endregion

        #region Input information 
        private void dtpReturnDate_ValueChanged(object sender, EventArgs e)
        {
            /* Code sau xử lý nếu người dùng chọn ngày trả sách sớm hơn ngày mượn gần nhất của 1 cuốn bất kỳ cần trả. * /
            /*          var value = (sender as DateTimePicker).Value;

                        //Find the max borrow date in chosen book list
                        List<DateTime> borrowDateList = new List<DateTime>();
                        for (int i = 0; i < dtgvChosen.Rows.Count; i++)
                            borrowDateList.Add(DateTime.ParseExact(dtgvChosen.Rows[i].Cells[3].Value.ToString(), "dd/MM/yyyy", null));

                        DateTime max = borrowDateList[0];
                        foreach (DateTime dt in borrowDateList)
                            if (dt > max)
                                max = dt;
                        if (value < max)
                        {
                            MessageBox.Show("Ngày trả không thể sớm hơn ngày mượn gần nhất", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            (sender as DateTimePicker).Value = DateTime.Now;
                        }
            */

            if (borrowBooks.Count > 0)
                foreach (BorrowedBook bb in borrowBooks)
                    UpdateBorrowDaysAndFine(bb);
            if (chosenBooks.Count > 0)
                foreach (BorrowedBook bb in chosenBooks)
                    UpdateBorrowDaysAndFine(bb);

            UpdateTextBoxWhenChanged();
            dtgvBorrow.Refresh();
            dtgvChosen.Refresh();
            this.ActiveControl = null;
        }

        private void UpdateTextBoxWhenChanged()
        {
            //Calculate total late days, fine this period and total fine of that reader
            int totalLateDays = 0;
            fineThisPeriod = 0;
            foreach (BorrowedBook b in chosenBooks)
            {
                totalLateDays += b.lateDays;
                fineThisPeriod += b.fine;
            }

            if (fineThisPeriod != 0)
                txbFineThisPeriod.Text = string.Format("{0:0,0 VNĐ}", fineThisPeriod);
            else
                txbFineThisPeriod.Text = "0 VNĐ";

            long totalFine = GetDebtByReaderId(reader.code) + fineThisPeriod;
            if (totalFine != 0)
                txbTotalFine.Text = string.Format("{0:0,0 VNĐ}", totalFine);
            else
                txbTotalFine.Text = "0 VNĐ";

            txbLateDays.Text = totalLateDays.ToString();
        }
        #endregion

        #region Rules
        private void tgBtnAskBeforePrint_CheckedChanged(object sender, EventArgs e)
        {
            print = (tgBtnAskBeforePrint.CheckState == CheckState.Checked) ? true : false;
        }
        #endregion

        #region Add and remove book from borrow list
        private void ChangeBook(string opt)
        {
            //"+": Add; "-": Remove
            if (opt == "+")
                ChangeBookBetweenTwoList(borrowBooks, chosenBooks, addBook);
            else if (opt == "-")
                ChangeBookBetweenTwoList(chosenBooks, borrowBooks, removeBook);

            SetDataSource();
            UpdateTextBoxWhenChanged();

            ClearSelection(dtgvChosen);
            ClearSelection(dtgvBorrow);
        }

        private void ChangeBookBetweenTwoList(BindingList<BorrowedBook> l1, BindingList<BorrowedBook> l2, BorrowedBook book)
        {
            foreach (BorrowedBook b in l1)
                if (b.id == book.id)
                {
                    l2.Add(b);
                    l1.Remove(b);
                    return;
                }
        }

        private void SetDataSource()
        {
            borrowBooks = SortList(borrowBooks);
            chosenBooks = SortList(chosenBooks);

            bindingBorrow.DataSource = borrowBooks;
            bindingChosen.DataSource = chosenBooks;

            dtgvBorrow.DataSource = bindingBorrow;
            dtgvChosen.DataSource = bindingChosen;

            addBook = null;
            removeBook = null;

            if (dtgvChosen.Rows.Count > 0)
                btnSave.Enabled = true;
            else
                btnSave.Enabled = false;
        }

        private BindingList<BorrowedBook> SortList(BindingList<BorrowedBook> blist)
        {
            List<BorrowedBook> list = new List<BorrowedBook>(blist);
            list = list.OrderBy(o => o.id).ToList();
            BindingList<BorrowedBook> newblist = new BindingList<BorrowedBook>(list);
            return newblist;
        }

        private void ClearSelection(DataGridView dtgv)
        {
            if (dtgv.Rows.Count != 0)
                dtgv.ClearSelection();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            addBook = GetSelectedBook(dtgvBorrow);
            if (addBook == null)
                MessageBox.Show("Bạn chưa chọn cuốn sách mà độc giả muốn trả!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
                ChangeBook("+");
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            removeBook = GetSelectedBook(dtgvChosen);
            if (dtgvChosen.Rows.Count <= 0)
                MessageBox.Show("Danh sách sách đã chọn trống!", "Thông báo");
            else if (removeBook == null)
                MessageBox.Show("Vui lòng chọn sách mà bạn muốn bỏ chọn!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else
                ChangeBook("-");
        }

        private void dtgvBorrow_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            addBook = GetSelectedBook(sender as DataGridView);
            if (addBook == null)
                MessageBox.Show("Bạn chưa chọn cuốn sách mà độc giả muốn trả!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else
                ChangeBook("+");
        }

        private void dtgvChosen_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            removeBook = GetSelectedBook(sender as DataGridView);
            if (removeBook == null)
                MessageBox.Show("Vui lòng chọn sách mà bạn muốn bỏ chọn!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else
                ChangeBook("-");
        }

        private BorrowedBook GetSelectedBook(DataGridView dtgv)
        {
            if (dtgv.SelectedRows.Count > 0)
                return (BorrowedBook)dtgv.SelectedRows[0].DataBoundItem;
            return null;
        }
        #endregion

        #region Create new return card, print and cancel action
        private void btnSave_Click(object sender, EventArgs e)
        {
            returnCard.readerId = reader.code;
            returnCard.readerName = reader.name;
            returnCard.returnDate = dtpReturnDate.Value.ToShortDateString();
            returnCard.fineThisPeriod = fineThisPeriod;
            returnCard.returnBooks = new BindingList<BorrowedBook>(chosenBooks);

            UpdateData(returnCard);
        }

        private void UpdateData(ReturnCard card)
        {
            try
            {
                SqlConnection conn = new SqlConnection(DatabaseInfo.connectionString);
                conn.Open();
                SqlCommand cmd = new SqlCommand(DatabaseInfo.InsertReturnCard(card), conn);
                cmd.ExecuteNonQuery();
                conn.Close();

                if (print)
                {
                    printDocument.DocumentName = "ReturnCard_" + returnCard.id;
                    printPreviewDialog.Document = printDocument;
                    printPreviewDialog.Height = this.Height;
                    printPreviewDialog.Width = this.Width;
                    printPreviewDialog.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Tạo phiếu trả thất bại! Vui lòng thử lại!\n(" + ex.Message + ")");
                state = "Cancelled";
                return;
            }

            state = "Success";
            DemoDesign.BorrowReturnBook.cardId = returnCard.id;
            this.Close();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            state = "Cancelled";
            this.Close();
        }

        private void printDocument_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            int width = e.PageBounds.Width;
            int x = 28, center = width / 2, y = 260, tablewidth = width - x * 2, colwidth, rowheight = dtgvChosen.Rows[0].Height + 2;


            e.Graphics.FillRectangle(new SolidBrush(Color.FromArgb(40, 84, 131)), new Rectangle(0, 0, width, 20));

            //Title
            var temp = TextRenderer.MeasureText("Phiếu Trả Sách", new Font("Segoe UI", 22.2F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(0)))).Width;
            e.Graphics.DrawString("Phiếu Trả Sách", new Font("Segoe UI", 22.2F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(0))), Brushes.Navy, new PointF(center - temp / 2, 32));

            //Information of borrow card
            e.Graphics.DrawString("Mã phiếu trả:  " + returnCard.id, new Font("Segoe UI", 12.75F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0))), Brushes.Black, new PointF(x, 100));
            e.Graphics.DrawString("Mã độc giả:  " + returnCard.readerId, new Font("Segoe UI", 12.75F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0))), Brushes.Black, new PointF(x, 130));
            e.Graphics.DrawString("Tên độc giả:  " + returnCard.readerName, new Font("Segoe UI", 12.75F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0))), Brushes.Black, new PointF(x, 160));
            e.Graphics.DrawString("Ngày trả:  " + dtpReturnDate.Value.ToString("dd/MM/yyyy"), new Font("Segoe UI", 12.75F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0))), Brushes.Black, new PointF(x, 190));
            e.Graphics.DrawString("Tổng ngày trả trễ:  " + txbLateDays.Text, new Font("Segoe UI", 12.75F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0))), Brushes.Black, new PointF(center, 100));
            e.Graphics.DrawString("Tiền phạt kỳ này:  " + txbFineThisPeriod.Text, new Font("Segoe UI", 12.75F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0))), Brushes.Black, new PointF(center, 130));
            e.Graphics.DrawString("Tổng nợ:  " + txbTotalFine.Text, new Font("Segoe UI", 12.75F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0))), Brushes.Black, new PointF(center, 160));

            //Title of list return book list
            temp = TextRenderer.MeasureText("Danh sách sách độc giả trả", new Font("Segoe UI", 16F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(0)))).Width;
            e.Graphics.DrawString("Danh sách sách độc giả trả", new Font("Segoe UI", 16F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(0))), Brushes.Navy, new PointF(center - temp / 2, 220));

            //Fill back color of table header 
            e.Graphics.FillRectangle(new SolidBrush(Color.FromArgb(40, 84, 131)), new Rectangle(x, y, tablewidth, rowheight));

            for (int i = -1; i < dtgvChosen.Rows.Count; i++)
            {
                for (int j = 0; j < dtgvChosen.Columns.Count; j++)
                {
                    if (j == 1 || j == 4)
                        colwidth = tablewidth / 7 * 2;
                    else
                        colwidth = tablewidth / 7;

                    if (i >= 0)
                    {
                        e.Graphics.DrawRectangle(Pens.Black, x, y, colwidth, rowheight);
                        e.Graphics.DrawString(dtgvChosen.Rows[i].Cells[j].Value.ToString(), new Font("Segoe UI", 12.75F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0))), Brushes.Black, new RectangleF(x, y + 2, colwidth, rowheight));
                    }
                    else
                    {
                        e.Graphics.DrawRectangle(Pens.Black, x, y, colwidth, rowheight);
                        e.Graphics.DrawString(dtgvChosen.Columns[j].HeaderText, new Font("Segoe UI", 12.75F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(0))), Brushes.White, new RectangleF(x, y + 2, colwidth, rowheight));
                    }

                    x += colwidth;
                }
                x = 28; y += rowheight;
            }

            if (dtgvBorrow.Rows.Count > 0)
            {
                //Title of list borrowed book list
                temp = TextRenderer.MeasureText("Danh sách sách độc giả còn đang mượn", new Font("Segoe UI", 16F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(0)))).Width;
                e.Graphics.DrawString("Danh sách sách độc giả còn đang mượn", new Font("Segoe UI", 16F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(0))), Brushes.Navy, new PointF(center - temp / 2, y + 20));
                y += 60;

                e.Graphics.FillRectangle(new SolidBrush(Color.FromArgb(40, 84, 131)), new Rectangle(x, y, tablewidth, rowheight));
                for (int i = -1; i < dtgvBorrow.Rows.Count; i++)
                {
                    for (int j = 0; j < dtgvBorrow.Columns.Count; j++)
                    {
                        if (j == 1 || j == 4)
                            colwidth = tablewidth / 7 * 2;
                        else
                            colwidth = tablewidth / 7;

                        if (i >= 0)
                        {
                            e.Graphics.DrawRectangle(Pens.Black, x, y, colwidth, rowheight);
                            e.Graphics.DrawString(dtgvBorrow.Rows[i].Cells[j].Value.ToString(), new Font("Segoe UI", 12.75F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0))), Brushes.Black, new RectangleF(x, y + 2, colwidth, rowheight));
                        }
                        else
                        {
                            e.Graphics.DrawRectangle(Pens.Black, x, y, colwidth, rowheight);
                            e.Graphics.DrawString(dtgvBorrow.Columns[j].HeaderText, new Font("Segoe UI", 12.75F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(0))), Brushes.White, new RectangleF(x, y + 2, colwidth, rowheight));
                        }

                        x += colwidth;
                    }
                    x = 28; y += rowheight;
                }
            }

            e.Graphics.FillRectangle(Brushes.Black, new Rectangle(0, y + 20, width, 2));
        }
        #endregion
    }
}
