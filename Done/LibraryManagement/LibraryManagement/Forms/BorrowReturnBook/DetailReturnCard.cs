using System;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using LibraryManagement.Models;
using LibraryManagement.State;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace LibraryManagement.Forms
{
    public partial class DetailReturnCard : Form
    {
        public static ReturnCard returnCard;
        public static bool delete;
        public static bool deleteReturn;

        private StateContext state = new StateContext();

        BindingList<Models.DetailReturnCard> detailList;
        BindingSource bindingDetail;

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

        public DetailReturnCard()
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
        private void DetailReturnCard_Load(object sender, EventArgs e)
        {
            detailList = new BindingList<Models.DetailReturnCard>();
            bindingDetail = new BindingSource();

            btnDelete.BorderRadius = 12;
            btnExit.BorderRadius = 20;
            btnDelete.Enabled = false;
            dtpReturnDate.Enabled = false;

            txbReturnCardId.Text = returnCard.id;
            txbReaderId.Text = returnCard.readerId;
            txbReaderName.Text = returnCard.readerName;
            HandleFineThisPeriodTextBox();

            delete = deleteReturn = false;

            LoadDetailReturnList();
        }

        private void LoadDetailReturnList()
        {
            int lateDays = 0;
            SqlConnection conn = new SqlConnection(DatabaseInfo.connectionString);
            conn.Open();
            SqlCommand cmd = new SqlCommand(DatabaseInfo.GetAllDetailReturnByReturnCardId(returnCard.id), conn);
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                int stt = 1;
                bindingDetail.DataSource = detailList;
                detailList.Clear();
                while (reader.Read())
                {
                    Models.DetailReturnCard detail = new Models.DetailReturnCard(stt, reader.GetString(0), reader.GetString(1), reader.GetString(2), returnCard.id, reader.GetString(3), reader.GetInt32(4), (long)reader.GetDecimal(5));
                    detailList.Add(detail);
                    stt++;
                    lateDays += detail.lateDays;
                }
                conn.Close();
            }
            dtgv.DataSource = bindingDetail;

            txbLateDays.Text = lateDays.ToString();
            HandleFineThisPeriodTextBox();

            if (dtgv.Rows.Count != 0)
                dtgv.ClearSelection();
        }

        private void HandleFineThisPeriodTextBox()
        {
            if (returnCard.fineThisPeriod != 0)
                txbFineThisPeriod.Text = string.Format("{0:0,0 VNĐ}", returnCard.fineThisPeriod);
            else
                txbFineThisPeriod.Text = "0 VNĐ";
            dtpReturnDate.Value = DateTime.ParseExact(returnCard.returnDate, "dd/MM/yyyy", null);
        }
        #endregion

        #region Handle edit and delete detail return card
        private void dtgv_SelectionChanged(object sender, EventArgs e)
        {
            if ((sender as DataGridView).SelectedRows.Count > 0)
                btnDelete.Enabled = true;
            else
                btnDelete.Enabled = false;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            Models.DetailReturnCard detail = Models.DetailReturnCard.GetDetailReturnCard(dtgv.SelectedRows[0].Cells[1].Value.ToString());
            if (detail != null)
            {

                if (CreateMessage(detail.id, detail.returnCardId) == DialogResult.OK)
                    try
                    {
                        if (Models.DetailReturnCard.DeleteDetailReturnCard(detail, deleteReturn))
                        {
                            delete = true;
                            if (deleteReturn)
                                this.Close();
                            else //Thực hiện xóa
                            {
                                string msg = "";

                                state.setState(new DeleteDetailReturnCard());
                                msg = state.applyState(id: detail.id, type: 0); 
                                
                                MessageBox.Show(msg, "Thông báo");

                                returnCard = ReturnCard.GetReturnCard(returnCard.id);
                                LoadDetailReturnList();
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        delete = false;
                        MessageBox.Show("Xóa chi tiết phiếu thất bại! Vui lòng thử lại!\n(" + ex.Message + ")");
                    }
                else
                    delete = deleteReturn = false;
            }
            else
                MessageBox.Show("Không tìm thấy chi tiết phiếu mà bạn muốn xóa trong cơ sở dữ liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private DialogResult CreateMessage(string id, string returnCardId)
        {
            string msg = "";
            if (dtgv.Rows.Count == 1)
            {
                state.setState(new DeleteDetailReturnCard());
                string content = state.applyState(id: id, phieu_id: returnCardId, type: 2);

                msg += content;
                deleteReturn = true;
                return MessageBox.Show(msg, "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            }
            else
            {
                state.setState(new DeleteDetailReturnCard());
                string content = state.applyState(id: id, type: 1);

                msg += content;
                return MessageBox.Show(msg, "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion
    }
}