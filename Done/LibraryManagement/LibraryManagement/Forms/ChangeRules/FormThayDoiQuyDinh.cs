using LibraryManagement.ChangeRuleClass;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
namespace ThayDoiQuyDinh
{

    public partial class FormThayDoiQuyDinh : Form
    {
        SqlConnection connection;
        SqlCommand command;
        DataTable table = new DataTable();
        string str = $@"{LibraryManagement.Models.DatabaseInfo.connectionString}";
        SqlDataAdapter adapter = new SqlDataAdapter();
        string DG = "";
        RuleSingleton ruleSingleton = RuleSingleton.GetInstance();
        public FormThayDoiQuyDinh()
        {
            InitializeComponent();

        }
        public void loadQD()
        {
            disableSortHeader();
            DataTable table = new DataTable();

            lbthoihan.Text = ruleSingleton.Duration.ToString() + " Tháng";

            lbLuuHanh.Text = ruleSingleton.CirulationTime.ToString() + " Năm";

            lbTuoiMax.Text = ruleSingleton.MaxAge.ToString() + " Tuổi";

            lbTuoiMin.Text = ruleSingleton.MinAge.ToString() + " Tuổi";

            lbNgayMax.Text = ruleSingleton.MaxBorrowDay.ToString() + " Ngày";

            lbSachMax.Text = ruleSingleton.MaxBorrowBook.ToString() + " Cuốn";

            lbTien.Text = ruleSingleton.Fine.ToString() + " Đồng";
        }
        public void Form1_Load(object sender, EventArgs e)
        {

            connection = new SqlConnection(str);
            connection.Open();

            loadQD();


        }

        public void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        public void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        public void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        public void textBox5_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        public void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        public void textBox6_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        public void textBox7_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // Nếu bạn muốn, bạn có thể cho phép nhập số thực với dấu chấm
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        public void nButton1_Click(object sender, EventArgs e)
        {
            int i = 0;
            if (txbMucThuTienPhat.Text != "" || txbSoNgayMuonMax.Text != "" || txbSoSachMuonMax.Text != "" || txbThoiGianLuuHanh.Text != "" || txbThoiHanThe.Text != "" || txbTuoiToiDa.Text != "" || txbTuoiToiThieu.Text != "")
            {

                if (txbThoiHanThe.Text != "")
                {
                    command = connection.CreateCommand();
                    command.CommandText = "update Thamso set ThoiHanThe='" + txbThoiHanThe.Text + "' ";
                    ruleSingleton.Duration = int.Parse(txbThoiHanThe.Text);
                    command.ExecuteNonQuery();
                }
                if (txbThoiGianLuuHanh.Text != "")
                {
                    command = connection.CreateCommand();
                    command.CommandText = "update Thamso set ThoiGianLuuHanh='" + txbThoiGianLuuHanh.Text + "' ";
                    command.ExecuteNonQuery();
                    ruleSingleton.CirulationTime = int.Parse(txbThoiGianLuuHanh.Text);
                }
                if (txbTuoiToiDa.Text != "")
                {
                    DataTable a = new DataTable();
                    command = connection.CreateCommand();
                    command.CommandText = "select Tuoitoithieu from thamso";
                    adapter.SelectCommand = command;
                    a.Clear();
                    adapter.Fill(a);
                    if (int.Parse(a.Rows[0].ItemArray[0].ToString()) > int.Parse(txbTuoiToiDa.Text))
                    {
                        MessageBox.Show("quy định về tuổi tối đa không được phép nhỏ hơn tuổi tối thiểu");
                        i = 1;
                    }
                    else
                    {
                        command = connection.CreateCommand();
                        command.CommandText = "update Thamso set TuoiToiDa='" + txbTuoiToiDa.Text + "' ";
                        command.ExecuteNonQuery();

                    }
                    ruleSingleton.MaxAge = int.Parse(txbTuoiToiDa.Text);
                }
                if (txbTuoiToiThieu.Text != "")
                {
                    DataTable b = new DataTable();
                    command = connection.CreateCommand();
                    command.CommandText = "select TuoiToiDa from thamso";
                    adapter.SelectCommand = command;
                    b.Clear();
                    adapter.Fill(b);
                    if (int.Parse(b.Rows[0].ItemArray[0].ToString()) < int.Parse(txbTuoiToiThieu.Text))
                    {
                        MessageBox.Show("quy định về tuổi tối đa không được phép nhỏ hơn tuổi tối thiểu");
                        i = 1;
                    }
                    else
                    {
                        command = connection.CreateCommand();
                        command.CommandText = "update Thamso set TuoiToiThieu='" + txbTuoiToiThieu.Text + "' ";
                        command.ExecuteNonQuery();
                    }
                    ruleSingleton.MinAge = int.Parse(txbTuoiToiThieu.Text);
                }
                if (txbSoNgayMuonMax.Text != "")
                {
                    command = connection.CreateCommand();
                    command.CommandText = "update Thamso set SoNgayMuonMax='" + txbSoNgayMuonMax.Text + "' ";
                    command.ExecuteNonQuery();
                    ruleSingleton.MaxBorrowDay = int.Parse(txbSoNgayMuonMax.Text);
                }
                if (txbSoSachMuonMax.Text != "")
                {
                    command = connection.CreateCommand();
                    command.CommandText = "update Thamso set SoSachMuonMax='" + txbSoSachMuonMax.Text + "' ";
                    command.ExecuteNonQuery();
                    ruleSingleton.MaxBorrowBook = int.Parse(txbSoSachMuonMax.Text);
                }
                if (txbMucThuTienPhat.Text != "")
                {
                    command = connection.CreateCommand();
                    command.CommandText = "update Thamso set MucThuTienPhat='" + double.Parse(txbMucThuTienPhat.Text) + "' ";
                    command.ExecuteNonQuery();
                    ruleSingleton.Fine = int.Parse(txbMucThuTienPhat.Text);
                }
                txbThoiHanThe.Text = "";
                txbThoiGianLuuHanh.Text = "";
                txbTuoiToiDa.Text = "";
                txbSoNgayMuonMax.Text = "";
                txbTuoiToiThieu.Text = "";
                txbSoSachMuonMax.Text = "";
                txbMucThuTienPhat.Text = "";
                if (i == 0)
                    MessageBox.Show("Cập nhật quy định thành công");
                loadQD();
            }
            else
                MessageBox.Show("Tất Cả Các ô đều đang trống, không thể cập nhật");

        }



        public void nButton3_Click(object sender, EventArgs e)
        {
            //panel4.Hide();

            btnCapNhat.Hide();


            //lbTieuDe1.Text = "Danh Sách Loại Độc Giả";
            DataTable table1 = new DataTable();
            command = connection.CreateCommand();
            command.CommandText = "select MaLoaiDocGia as [Mã Loại],TenLoaiDocGia as [Tên Loại Độc Giả] from LoaiDocGia";
            adapter.SelectCommand = command;
            table1.Clear();
            adapter.Fill(table1);
            gbQuyDinhHienHanh.DataSource = table1;

        }

        public void nButton2_Click(object sender, EventArgs e)
        {
            //panel4.Show();

            btnCapNhat.Show();


            //lbTieuDe1.Text = "Quy Định Hiện Hành ";
            gbQuyDinhHienHanh.DataSource = null;
        }

        void loadDocGia()
        {
            DataTable table1 = new DataTable();
            command = connection.CreateCommand();
            command.CommandText = "select MaLoaiDocGia as [Mã Loại],TenLoaiDocGia as [Tên Loại Độc Giả] from LoaiDocGia";
            adapter.SelectCommand = command;
            table1.Clear();
            adapter.Fill(table1);
            gbQuyDinhHienHanh.DataSource = table1;
        }
        void loadTheLoai()
        {
            DataTable table1 = new DataTable();
            command = connection.CreateCommand();
            command.CommandText = "select MaTheLoai as [Mã Loại],TenTheLoai as [Tên Thể Loại Sách] from TheLoai";
            adapter.SelectCommand = command;
            table1.Clear();
            adapter.Fill(table1);
            gbQuyDinhHienHanh.DataSource = table1;
        }
        public void nButton4_Click(object sender, EventArgs e)
        {
            //lbTieuDe1.Text = "Danh Sách Loại Độc Giả";
            loadDocGia();
            //label24.Text = "Tên Loại Độc Giả";

        }

        public void nButton5_Click(object sender, EventArgs e)
        {
            //lbTieuDe1.Text = "Danh Sách Thể Loại Sách";
            loadTheLoai();
            //label24.Text = "Tên Thể Loại Sách";

        }

        public void nButton6_Click(object sender, EventArgs e)
        {

        }
        public void disableSortHeader()
        {
            foreach (DataGridViewColumn column in gbQuyDinhHienHanh.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
        }









        public void txbSoNgayMuonMax_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (int.Parse(txbSoNgayMuonMax.Text) == 0)
                {
                    MessageBox.Show("Số Ngày mượn tối đa không được bằng 0");
                    txbSoNgayMuonMax.Text = "";
                }
            }
            catch
            { }

        }

        public void txbThoiHanThe_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (int.Parse(txbThoiHanThe.Text) == 0)
                {
                    MessageBox.Show("Giá Trị của thời gian thẻ không được bằng 0");
                    txbThoiHanThe.Text = "";
                }
            }
            catch
            { }

        }

        public void txbThoiGianLuuHanh_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (int.Parse(txbThoiGianLuuHanh.Text) == 0)
                {
                    MessageBox.Show("Thời gian lưu hành của sách không được bằng 0"); txbThoiGianLuuHanh.Text = "";
                }
            }
            catch
            { }

        }

        public void txbTuoiToiDa_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (int.Parse(txbTuoiToiDa.Text) == 0)
                {
                    MessageBox.Show("Tuổi tối đa của độc giả mượn sách không được bằng 0"); txbTuoiToiDa.Text = "";
                }
            }
            catch
            { }

        }

        public void txbSoSachMuonMax_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (int.Parse(txbSoSachMuonMax.Text) == 0)
                {
                    MessageBox.Show("Số sách mượn tối đa không được phép bằng 0"); txbSoSachMuonMax.Text = "";
                }
            }
            catch
            { }

        }

        public void lbNgayMax_Click(object sender, EventArgs e)
        {

        }

        public void label14_Click(object sender, EventArgs e)
        {

        }

        public void label15_Click(object sender, EventArgs e)
        {

        }

        public void lbSachMax_Click(object sender, EventArgs e)
        {

        }

        public void label10_Click(object sender, EventArgs e)
        {

        }

        public void lbthoihan_Click(object sender, EventArgs e)
        {

        }

        public void gbQuyDinhHienHanh_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        public void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
