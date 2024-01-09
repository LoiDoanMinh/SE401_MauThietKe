using LibraryManagement.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;
using LibraryManagement.Models.State;

namespace LibraryManagement.Forms
{
    public partial class CreateBorrowCard : Form
    {
        // TINHTRANG CUONSACH = 1: Available;; = 0: Is borrowed
        public static int numBorrowedBooks;
        public static Reader reader;

        BorrowCard borrowCard;

        BindingList<Book> stockBooks;
        BindingList<Book> chosenBooks;

        BindingSource bindingStock;
        BindingSource bindingChosen;
        Book addBook = null, removeBook = null;
        int maxDays, maxBooks;
        bool searchMode = false, print = true;

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

        public CreateBorrowCard()
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
        private void CreateBorrowCard_Load(object sender, EventArgs e)
        {
            btnAdd.BorderRadius = 20;
            btnRemove.BorderRadius = 20;
            btnExit.BorderRadius = 20;
            btnSave.BorderRadius = 20;

            this.dtgvStock.AutoGenerateColumns = false;
            this.dtgvChosen.AutoGenerateColumns = false;

            stockBooks = new BindingList<Book>();
            chosenBooks = new BindingList<Book>();
            bindingChosen = new BindingSource();
            bindingStock = new BindingSource();
            borrowCard = new BorrowCard();

            Parameters.LoadParam();
            maxDays = Parameters.maxBorrowDays;
            maxBooks = Parameters.maxBorrowBooks;

            LoadData();

            txbBorrowCardId.Text = borrowCard.id;
            txbReaderId.Text = reader.code;
            txbReaderName.Text = reader.name;
            dtpReturnDate.Value = dtpBorrowDate.Value.AddDays(maxDays);
            lbMaxBorrow.Text = $"Số sách được mượn tối đa: {maxBooks}";
            lbQuantity.Text = "Số lượng: " + dtgvChosen.Rows.Count;
        }

        private void LoadData()
        {
            Thread tdLoadStockBooks = new Thread(new ThreadStart(LoadStockBooks));
            Thread tdGetBorrowCard = new Thread(new ThreadStart(GetLastBorrowCardId));

            tdLoadStockBooks.Start();
            tdGetBorrowCard.Start();

            tdGetBorrowCard.Join();
        }

        private void LoadStockBooks()
        {
            SqlConnection conn = new SqlConnection(DatabaseInfo.connectionString);
            conn.Open();
            SqlCommand cmd = new SqlCommand(DatabaseInfo.bookStockQueryCmd, conn);
            using (SqlDataReader reader = cmd.ExecuteReader())
                while (reader.Read())
                {
                    stockBooks.Add(new Book(reader.GetString(0), reader.GetString(1), reader.GetString(2), reader.GetString(3), reader.GetString(4), new AvailableState()));
                }
            conn.Close();

            bindingChosen.DataSource = chosenBooks;
            dtgvChosen.DataSource = bindingChosen;

            bindingStock.DataSource = stockBooks;
            dtgvStock.DataSource = bindingStock;

            ClearSelection(dtgvStock);

            btnSave.Enabled = false;
        }

        private void GetLastBorrowCardId()
        {
            //Get id of the last borrow card 
            SqlConnection conn = new SqlConnection(DatabaseInfo.connectionString);
            conn.Open();
            SqlCommand cmd = new SqlCommand(DatabaseInfo.getBookSlipCode, conn);
            if (cmd.ExecuteScalar() != null)
            {
                string last = cmd.ExecuteScalar().ToString();
                int stt = int.Parse(last.Substring(4, 3)) + 1;
                borrowCard.id = $"MPMS{stt:000}";
            }
            else
                borrowCard.id = "MPMS001";
        }
        #endregion

        #region Input information 
        private void dtpBorrowDate_ValueChanged(object sender, EventArgs e)
        {
            dtpReturnDate.Value = dtpBorrowDate.Value.AddDays(maxDays);

        }

        private void txbEmployeeName_MouseDown(object sender, MouseEventArgs e)
        {
            (sender as TextBox).Select(0, (sender as TextBox).Text.Length);
            (sender as TextBox).Focus();
        }

        private void txbEmployeeName_TextChanged(object sender, EventArgs e)
        {
            //if (txbEmployeeName.Text != "Nhập tên nhân viên" || txbEmployeeName.Text != "")
            //    borrowCard.employee = txbEmployeeName.Text;
        }
        #endregion

        #region Rules
        private void tgBtnAllowMax_CheckedChanged(object sender, EventArgs e)
        {
            if (tgBtnAllowMax.CheckState == CheckState.Checked)
                lbMaxBorrow.Visible = true;
            else
                lbMaxBorrow.Visible = false;
        }

        private void tgBtnAskBeforePrint_CheckedChanged(object sender, EventArgs e)
        {
            print = (tgBtnAskBeforePrint.CheckState == CheckState.Checked) ? true : false;
        }
        #endregion

        #region Search book
        private void txbSearchBook_TextChanged(object sender, EventArgs e)
        {
            TextBox txt = (TextBox)sender;
            if (stockBooks.Count != 0)
            {
                if (txt.Text.Length == 0)
                {
                    searchMode = false;
                    SetDataSource();
                }
                else
                {
                    searchMode = true;
                    try
                    {
                        var table = ToDataTable(stockBooks);
                        var results = table.Select(string.Format("id LIKE '%{0}%' OR bookId LIKE '%{0}%' OR name LIKE '%{0}%' OR category LIKE '%{0}%' OR author LIKE '%{0}%'", txt.Text));

                        if (results.Length > 0)
                        {
                            dtgvStock.DataSource = results.CopyToDataTable();
                            dtgvStock.Refresh();
                        }
                        else
                            dtgvStock.DataSource = null;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }
            else if (txt.TextLength == 0)
            {
                searchMode = false;
                SetDataSource();
            }

            ClearSelection(dtgvStock);
            ClearSelection(dtgvChosen);
        }

        public static DataTable ToDataTable<T>(BindingList<T> items)
        {
            DataTable dataTable = new DataTable(typeof(T).Name);

            //Get all the properties
            PropertyInfo[] Props = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);
            foreach (PropertyInfo prop in Props)
            {
                //Defining type of data column gives proper data table 
                var type = (prop.PropertyType.IsGenericType && prop.PropertyType.GetGenericTypeDefinition() == typeof(Nullable<>) ? Nullable.GetUnderlyingType(prop.PropertyType) : prop.PropertyType);
                //Setting column names as Property names
                dataTable.Columns.Add(prop.Name, type);
            }
            foreach (T item in items)
            {
                var values = new object[Props.Length];
                for (int i = 0; i < Props.Length; i++)
                {
                    //inserting property values to datatable rows
                    values[i] = Props[i].GetValue(item, null);
                }
                dataTable.Rows.Add(values);
            }
            //put a breakpoint here and check datatable
            return dataTable;
        }

        private void llbDeleteSearch_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (txbSearchBook.Text.Length > 0)
            {
                txbSearchBook.Text = "";
                txbSearchBook.Focus();
            }
        }
        #endregion

        #region Add and remove book from borrow list
        private void ChangeBook(string opt)
        {
            //"+": Add; "-": Remove
            if (opt == "+")
            {
                if (chosenBooks.Count + numBorrowedBooks + 1 > maxBooks && tgBtnAllowMax.Checked)
                    MessageBox.Show("Không được mượn quá " + maxBooks + " cuốn sách", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                else
                    ChangeBookBetweenTwoList(stockBooks, chosenBooks, addBook);
            }
            else if (opt == "-")
                ChangeBookBetweenTwoList(chosenBooks, stockBooks, removeBook);

            if (searchMode)
            {
                try
                {
                    var table = ToDataTable(stockBooks);
                    var results = table.Select(string.Format("id LIKE '%{0}%' OR bookId LIKE '%{0}%' OR name LIKE '%{0}%' OR category LIKE '%{0}%' OR author LIKE '%{0}%'", txbSearchBook.Text));

                    if (results.Length > 0)
                    {
                        dtgvStock.DataSource = results.CopyToDataTable();
                        dtgvStock.Refresh();
                    }
                    else
                        dtgvStock.DataSource = null;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

                chosenBooks = SortList(chosenBooks);
                bindingChosen.DataSource = chosenBooks;
            }
            else
                SetDataSource();

            ClearSelection(dtgvChosen);
            ClearSelection(dtgvStock);
        }

        private void ChangeBookBetweenTwoList(BindingList<Book> l1, BindingList<Book> l2, Book book)
        {
            foreach (Book b in l1)
                if (b.id == book.id)
                {
                    l2.Add(b);
                    l1.Remove(b);
                    return;
                }
        }

        private void SetDataSource()
        {
            stockBooks = SortList(stockBooks);
            chosenBooks = SortList(chosenBooks);

            bindingStock.DataSource = stockBooks;
            bindingChosen.DataSource = chosenBooks;

            dtgvStock.DataSource = bindingStock;
            dtgvChosen.DataSource = bindingChosen;

            addBook = null;
            removeBook = null;

            lbQuantity.Text = "Số lượng: " + dtgvChosen.Rows.Count;

            if (dtgvChosen.Rows.Count > 0)
                btnSave.Enabled = true;
            else
                btnSave.Enabled = false;
        }

        private BindingList<Book> SortList(BindingList<Book> blist)
        {
            List<Book> list = new List<Book>(blist);
            list = list.OrderBy(o => o.id).ThenBy(o => o.bookId).ToList();
            BindingList<Book> newblist = new BindingList<Book>(list);
            return newblist;
        }

        private void ClearSelection(DataGridView dtgv)
        {
            if (dtgv.Rows.Count != 0)
                dtgv.ClearSelection();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            addBook = GetSelectedBook(dtgvStock);
            if (addBook == null)
                MessageBox.Show("Bạn chưa chọn cuốn sách mà độc giả muốn mượn!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
                ChangeBook("+");
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            removeBook = GetSelectedBook(dtgvChosen);
            if (dtgvChosen.Rows.Count <= 0)
                MessageBox.Show("Danh sách sách đã chọn trống!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else if (removeBook == null)
                MessageBox.Show("Vui lòng chọn sách mà bạn muốn bỏ chọn!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else
                ChangeBook("-");
        }

        private void dtgvStock_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            addBook = GetSelectedBook(sender as DataGridView);
            if (addBook == null)
                MessageBox.Show("Bạn chưa chọn cuốn sách mà độc giả muốn mượn!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private Book GetSelectedBook(DataGridView dtgv)
        {
            if (dtgv.SelectedRows.Count > 0)
            {
                string id = dtgv.SelectedRows[0].Cells[0].Value.ToString();
                string bookId = dtgv.SelectedRows[0].Cells[1].Value.ToString();
                string name = dtgv.SelectedRows[0].Cells[2].Value.ToString();
                string category = dtgv.SelectedRows[0].Cells[3].Value.ToString();
                string author = dtgv.SelectedRows[0].Cells[4].Value.ToString();
                return new Book(id, bookId, name, author, category);
            }

            return null;
        }
        #endregion

        #region Create new borrow card, print and cancel action
        private void btnSave_Click(object sender, EventArgs e)
        {
            //if (txbEmployeeName.Text.Length == 0 || txbEmployeeName.Text == "Nhập tên nhân viên")
            //    MessageBox.Show("Bạn chưa nhập tên nhân viên trực. \nVui lòng nhập tên của bạn để được tiếp tục!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //else
            {
                borrowCard.readerId = reader.code;
                borrowCard.readerName = reader.name;
                borrowCard.borrowDate = dtpBorrowDate.Value.ToShortDateString();
                borrowCard.returnDate = dtpReturnDate.Value.ToShortDateString();
                //borrowCard.employee = txbEmployeeName.Text;
                borrowCard.borrowBooks = new List<Book>(chosenBooks);

                UpdateData(borrowCard);
            }
        }

        private void printDocument_PrintPage(object sender, PrintPageEventArgs e)
        {
            int width = e.PageBounds.Width;
            int x = 28, center = width / 2, y = 200, tablewidth = width - x * 2, colwidth, rowheight = dtgvChosen.Rows[0].Height + 2;


            e.Graphics.FillRectangle(new SolidBrush(Color.FromArgb(40, 84, 131)), new Rectangle(0, 0, width, 20));
            e.Graphics.FillRectangle(Brushes.Black, new Rectangle(0, y + dtgvChosen.Rows[0].Height * dtgvChosen.RowCount + 60, width, 2));

            //Title
            Label title = new Label();
            title.AutoSize = true;
            title.Text = "Phiếu Mượn Sách";
            e.Graphics.DrawString(title.Text, new Font("Segoe UI", 22.2F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(0))), Brushes.Navy, new PointF(center - title.Size.Width, 32));

            //Information of borrow card
            e.Graphics.DrawString("Mã phiếu mượn:  " + borrowCard.id, new Font("Segoe UI", 12.75F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0))), Brushes.Black, new PointF(x, 100));
            e.Graphics.DrawString("Mã độc giả:  " + borrowCard.readerId, new Font("Segoe UI", 12.75F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0))), Brushes.Black, new PointF(x, 130));
            e.Graphics.DrawString("Tên độc giả:  " + borrowCard.readerName, new Font("Segoe UI", 12.75F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0))), Brushes.Black, new PointF(x, 160));
            e.Graphics.DrawString("Ngày mượn:  " + dtpBorrowDate.Value.ToString("dd/MM/yyyy"), new Font("Segoe UI", 12.75F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0))), Brushes.Black, new PointF(center, 100));
            e.Graphics.DrawString("Ngày trả:  " + dtpReturnDate.Value.ToString("dd/MM/yyyy"), new Font("Segoe UI", 12.75F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0))), Brushes.Black, new PointF(center, 130));

            //Fill back color of table header 
            e.Graphics.FillRectangle(new SolidBrush(Color.FromArgb(40, 84, 131)), new Rectangle(x, y, tablewidth, rowheight));

            for (int i = -1; i < dtgvChosen.Rows.Count; i++)
            {
                for (int j = 0; j < dtgvChosen.Columns.Count; j++)
                {
                    if (j == 2 || j == 3 || j == 4)
                        colwidth = tablewidth / 8 * 2;
                    else
                        colwidth = tablewidth / 8;

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
        }

        private void UpdateData(BorrowCard card)
        {
            try
            {
                SqlConnection conn = new SqlConnection(DatabaseInfo.connectionString);
                conn.Open();
                SqlCommand cmd = new SqlCommand(DatabaseInfo.InsertBorrowCard(card), conn);
                cmd.ExecuteNonQuery();
                conn.Close();

                if (print)
                {
                    printDocument.DocumentName = "BorrowCard_" + borrowCard.id;
                    printPreviewDialog.Document = printDocument;
                    printPreviewDialog.Height = this.Height;
                    printPreviewDialog.Width = this.Width;
                    printPreviewDialog.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Tạo phiếu mượn thất bại! Vui lòng thử lại!\n(" + ex.Message + ")");
                DemoDesign.BorrowReturnBook.borrowState = "Cancelled";
                return;
            }

            DemoDesign.BorrowReturnBook.borrowState = "Success";
            DemoDesign.BorrowReturnBook.cardId = borrowCard.id;
            this.Close();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            DemoDesign.BorrowReturnBook.borrowState = "Cancelled";
            this.Close();
        }
        #endregion
    }
}