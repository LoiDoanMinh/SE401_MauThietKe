using System;
using System.Data.SqlClient;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using LibraryManagement.Models;
using DemoDesign;
using System.ComponentModel;
using System.Windows.Interop;
using System.Diagnostics.Eventing.Reader;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace LibraryManagement.Forms
{
    public partial class DetailBorrowCard : Form
    {
        public static BorrowCard borrowCard;
        public static bool update;
        public static bool delete;
        public static bool deleteBorrowCard;
        public static bool deleteReturn;
        public static bool insertReturn;

        BindingList<Models.DetailBorrowCard> detailList;
        BindingSource bindingDetail;
        int maxDays;

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

        public DetailBorrowCard()
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
        private void DetailBorrowCard_Load(object sender, EventArgs e)
        {
            detailList = new BindingList<Models.DetailBorrowCard>();
            bindingDetail = new BindingSource();

            btnDelete.BorderRadius = 12;
            btnSave.BorderRadius = 12;
            btnExit.BorderRadius = 20;

            btnDelete.Enabled = btnSave.Enabled = false;

            dtpBorrowDate.MaxDate = DateTime.Today;

            Parameters.LoadParam();
            maxDays = Parameters.maxBorrowDays;

            txbBorrowCardId.Text = borrowCard.id;
            txbReaderId.Text = borrowCard.readerId;
            txbReaderName.Text = borrowCard.readerName;
            dtpBorrowDate.Value = DateTime.ParseExact(borrowCard.borrowDate, "dd/MM/yyyy", null);
            dtpReturnDate.Value = dtpBorrowDate.Value.AddDays(maxDays);

            update = delete = deleteBorrowCard = deleteReturn = false;

            LoadDetailBorrowList();
        }

        private void LoadDetailBorrowList()
        {
            SqlConnection conn = new SqlConnection(DatabaseInfo.connectionString);
            conn.Open();
            SqlCommand cmd = new SqlCommand(DatabaseInfo.GetAllDetailBorrowByBorrowCardId(borrowCard.id), conn);
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                int stt = 1;
                bindingDetail.DataSource = detailList;
                detailList.Clear();
                while (reader.Read())
                {
                    Models.DetailBorrowCard detail = new Models.DetailBorrowCard(stt, reader.GetString(0), borrowCard.id, reader.GetString(1), reader.GetString(2), (bool)reader.GetSqlBoolean(3));
                    detailList.Add(detail);
                    stt++;
                }
            }
            conn.Close();

            dtgv.DataSource = bindingDetail;

            bool haveOnReturn = false, returnAll = true;
            foreach (Models.DetailBorrowCard detail in detailList)
                if (detail.status)
                    haveOnReturn = true;
                else
                    returnAll = false;

            if (!haveOnReturn)
                dtpBorrowDate.Enabled = true;
            else if (haveOnReturn)
                dtpBorrowDate.Enabled = false;
            if (!returnAll)
                btnCreateReturnCard.Enabled = true;
            else if (returnAll)
                btnCreateReturnCard.Enabled = false;


            if (dtgv.Rows.Count != 0)
                dtgv.ClearSelection();
        }
        #endregion

        #region Handle edit and delete detail borrow card
        private void dtpBorrowDate_ValueChanged(object sender, EventArgs e)
        {
            if ((sender as DateTimePicker).Value.ToString("dd/MM/yyyy") != borrowCard.borrowDate)
            {
                dtpReturnDate.Value = dtpBorrowDate.Value.AddDays(maxDays);
                btnSave.Enabled = true;
            }
            else
                btnSave.Enabled = false;

            this.ActiveControl = null;
        }

        private void btnSave_Click(object sensder, EventArgs e)
        {
            borrowCard.borrowDate = dtpBorrowDate.Value.ToString("dd/MM/yyyy");
            borrowCard.returnDate = dtpReturnDate.Value.ToString("dd/MM/yyyy");

            SqlConnection conn = new SqlConnection(DatabaseInfo.connectionString);
            conn.Open();
            SqlCommand cmd = new SqlCommand(DatabaseInfo.UpdateBorrowCard(borrowCard.id, borrowCard.borrowDate, borrowCard.returnDate), conn);
            cmd.ExecuteNonQuery();
            conn.Close();

            update = true;
            MessageBox.Show($"Cập nhật thông tin phiếu mượn {borrowCard.id} thành công!", "Thông báo");

            LoadDetailBorrowList();
        }

        private void dtgv_SelectionChanged(object sender, EventArgs e)
        {
            if ((sender as DataGridView).SelectedRows.Count > 0)
                //if (!(bool)(sender as DataGridView).SelectedRows[0].Cells[4].Value)
                btnDelete.Enabled = true;
            else
                btnDelete.Enabled = false;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            string detailId = dtgv.SelectedRows[0].Cells[1].Value.ToString();
            string bookId = dtgv.SelectedRows[0].Cells[2].Value.ToString();

            if (CreateMessage(detailId) == DialogResult.OK)
                try
                {
                    SqlConnection conn = new SqlConnection(DatabaseInfo.connectionString);
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(DatabaseInfo.DeleteDetailBorrowCardById(borrowCard.id, detailId, bookId, deleteBorrowCard), conn);
                    cmd.ExecuteNonQuery();
                    conn.Close();

                    delete = true;
                    if (deleteBorrowCard)
                        this.Close();
                    else
                        MessageBox.Show($"Xóa chi tiết phiếu mượn {detailId} thành công!", "Thông báo");
                    LoadDetailBorrowList();
                }
                catch (Exception ex)
                {
                    delete = false;
                    MessageBox.Show("Xóa chi tiết phiếu thất bại! Vui lòng thử lại!\n(" + ex.Message + ")");
                }
            else
                deleteBorrowCard = deleteReturn = false;
        }

        private DialogResult CreateMessage(string id)
        {
            if (dtgv.Rows.Count == 1)
                deleteBorrowCard = true;
            if ((bool)dtgv.SelectedRows[0].Cells[4].Value)
                deleteReturn = true;

            string msg = "";
            if (deleteReturn || deleteBorrowCard)
            {
                if (deleteReturn && deleteBorrowCard)
                    msg += $"Sách này đã được trả. Nếu xóa chi tiết phiếu mượn {id} thì hệ thống sẽ xóa thông tin phiếu mượn {borrowCard.id} và thông tin phiếu trả đi kèm.";
                else if (deleteReturn)
                    msg += $"Sách này đã được trả. Nếu xóa chi tiết phiếu mượn {id} thì hệ thống sẽ xóa thông tin phiếu trả đi kèm.";
                else if (deleteBorrowCard)
                    msg += $"Nếu xóa chi tiết phiếu mượn {id} thì hệ thống sẽ xóa phiếu mượn {borrowCard.id}.";

                msg += $"\nBạn có muốn tiếp tục xóa không?";
                return MessageBox.Show(msg, "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            }
            else
            {
                msg += $"Bạn có muốn xóa chi tiết phiếu mượn {id} không?";
                return MessageBox.Show(msg, "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            }
        }

        private void btnCreateReturnCard_Click(object sender, EventArgs e)
        {
            CreateReturnCard.reader = Reader.GetReader(txbReaderId.Text);
            new CreateReturnCard().ShowDialog();
            insertReturn = false;
            if (CreateReturnCard.state == "Success")
            {
                MessageBox.Show($"Tạo phiếu trả thành công!", "Thông báo");
                insertReturn = true;
            }
            this.Close();
            new DetailBorrowCard().ShowDialog();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion
    }
}