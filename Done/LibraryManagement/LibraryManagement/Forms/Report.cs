using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using LibraryManagement.Models;

namespace DemoDesign
{
    public partial class Report : Form
    {
        List<ReportByCategory> reportByCategory;
        List<ReportByBook> reportByBook;
        List<ReportLate> reportLate;
        List<ReportByReader> reportByReader;


        ReportType reportType = ReportType.Book;
        enum ReportType
        {
            Book,
            BookType,
            Reader
        }

        BindingSource binding;
        public Report()
        {
            InitializeComponent();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            lbInform.Visible = false;
            switch (cmbType.SelectedItem.ToString())
            {
                case "Thể loại":
                    reportType = ReportType.BookType;
                    break;
                case "Sách":
                    reportType = ReportType.Book;
                    break;
                case "Độc giả":
                    reportType = ReportType.Reader;
                    break;
            }
            ChangeDtgvLayout(reportType);
            CreateReport();
        }

        private void Report_Load(object sender, EventArgs e)
        {
            reportByCategory = new List<ReportByCategory>();
            reportLate = new List<ReportLate>();
            reportByBook = new List<ReportByBook>();
            reportByReader = new List<ReportByReader>();

            binding = new BindingSource();

            //cbbReportType.SelectedIndex = 0;
            dtp.Value = DateTime.Now;
            cmbType.SelectedIndex = 0;
            lbTitle.Location = new Point((this.Width - lbTitle.Width) / 2, lbTitle.Location.Y);
        }

        private void CategoryReport()
        {
           
            reportByCategory.Clear();

            string categoryReportCmd = $@"SELECT TenTheLoai, COUNT(THELOAI.MaTheLoai) AS 'So Luot Muon'
                FROM THELOAI, CUONSACH, SACH, DAUSACH, PHIEUMUON, CTPHIEUMUON
                WHERE CTPHIEUMUON.MaCuonSach = CUONSACH.MaCuonSach AND CUONSACH.MaSach = SACH.MaSach
		                AND SACH.MaDauSach = DAUSACH.MaDauSach AND DAUSACH.MaTheLoai = THELOAI.MaTheLoai
			                AND CTPHIEUMUON.MaPhieuMuonSach = PHIEUMUON.MaPhieuMuonSach
				                AND MONTH(NgMuon) = {dtp.Value.Month.ToString()}
                GROUP BY TenTheLoai, THELOAI.MaTheLoai
                ORDER BY [So Luot Muon] DESC";

            SqlConnection conn = new SqlConnection(DatabaseInfo.connectionString);
            conn.Open();
            SqlCommand cmd = new SqlCommand(categoryReportCmd, conn);
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    reportByCategory.Add(new ReportByCategory(reader.GetString(0), reader.GetInt32(1)));
                }
            }
            int stt = 1;
            float totalNumOfBorrowings = 0;
            foreach(ReportByCategory report in reportByCategory)
            {
                report.stt = stt;
                totalNumOfBorrowings += report.numsOfBorrowings;
                stt++;
            }

            lbTotalBorrow.Text = totalNumOfBorrowings.ToString();

            foreach (ReportByCategory report in reportByCategory)
            {
                report.rate = $"{(Math.Round(((float)report.numsOfBorrowings / totalNumOfBorrowings),2)) * 100}%";
            }

            binding = new BindingSource();
            binding.DataSource = reportByCategory;
            dtgv.DataSource = binding;

            if(dtgv.Rows.Count != 0)
            {
                dtgv.SelectedRows[0].Selected = false;
                lbInform.Visible = false;
            }
            else
            {
                lbInform.Visible = true;
                lbInform.Text = $"Không có quyển sách nào được mượn trong tháng {dtp.Value.Month}";
                lbInform.Location = new Point((this.Width - lbInform.Width) / 2, lbInform.Location.Y);
            }
        }

        private void LateReport()
        {
            reportLate.Clear();

            string lateReportCmd = $@"SELECT CTPHIEUMUON.MaCuonSach, TenDauSach, NgMuon
                FROM CTPHIEUMUON, PHIEUMUON, CUONSACH, SACH, DAUSACH
                WHERE PHIEUMUON.MaPhieuMuonSach = CTPHIEUMUON.MaPhieuMuonSach AND CUONSACH.MaCuonSach = CTPHIEUMUON.MaCuonSach
			                AND CUONSACH.MaSach = SACH.MaSach AND SACH.MaDauSach = DAUSACH.MaDauSach
				                AND TinhTrangPM = 0 AND HanTra < '{dtp.Value.ToString("yyyy-MM-dd")}'";
            SqlConnection conn = new SqlConnection(DatabaseInfo.connectionString);
            conn.Open();
            SqlCommand cmd = new SqlCommand(lateReportCmd, conn);
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                int i = 0;
                while (reader.Read())
                {
                    reportLate.Add(new ReportLate(reader.GetString(0), reader.GetString(1), reader.GetDateTime(2).ToString("dd/MM/yyyy")));
                    reportLate[i].lateReturnDays = dtp.Value.Subtract(reader.GetDateTime(2)).Days;
                    i++;
                }
            }

            reportLate.OrderByDescending(o => o.lateReturnDays).ThenBy(o => o.bookCode).ThenBy(o => o.borrowDate).ToList();

            binding = new BindingSource();
            binding.DataSource = reportLate;
            dtgv.DataSource = binding;

            if (dtgv.Rows.Count != 0)
            {
                dtgv.SelectedRows[0].Selected = false;
            }
            else
            {
                lbInform.Visible = true;
                lbInform.Text = "Không có sách nào trả trễ";
                lbInform.Location = new Point((this.Width - lbInform.Width) / 2, lbInform.Location.Y);
            }
        }

        private void ChangeDtgvLayout(ReportType type)
        {
            switch (type)
            {
                case ReportType.BookType:
                    for (int i = dtgv.ColumnCount - 1; i > 0; i--)
                    {
                        // Xóa cột nếu không phải là cột đầu tiên
                        dtgv.Columns.RemoveAt(i);
                    }

                    dtgv.Columns.Add("temp1", "");
                    dtgv.Columns.Add("temp2", "");
                    dtgv.Columns.Add("temp3", "");

                    dtgv.Columns[1].HeaderText = "Tên thể loại";
                    dtgv.Columns[2].HeaderText = "Số lượt mượn";
                    dtgv.Columns[3].HeaderText = "Tỉ lệ";

                    dtgv.Columns[1].Width = 650;
                    dtgv.Columns[2].Width = 224;
                    dtgv.Columns[3].Width = 230;

                    dtgv.Columns[1].DataPropertyName = "categoryName";
                    dtgv.Columns[2].DataPropertyName = "numsOfBorrowings";
                    dtgv.Columns[3].DataPropertyName = "rate";

                    lbTotalBorrowTitle.Visible = true;
                    lbTotalBorrow.Visible = true;

                    dtp.CustomFormat = "MM/yyyy";

                    lbTitleName.Text = $"Thống Kê Theo Thể Loại Tháng {dtp.Value.Month.ToString()}";
                    break;

                case ReportType.Book:
                    for (int i = dtgv.ColumnCount - 1; i > 0; i--)
                    {
                        // Xóa cột nếu không phải là cột đầu tiên
                        dtgv.Columns.RemoveAt(i);
                    }
                    dtgv.Columns.Add("temp1", "");
                    dtgv.Columns.Add("temp2", "");
                    dtgv.Columns.Add("temp3", "");

                    dtgv.Columns[1].HeaderText = "Mã sách";
                    dtgv.Columns[2].HeaderText = "Tên sách";
                    dtgv.Columns[3].HeaderText = "Số lượt mượn";

                    dtgv.Columns[1].Width = 220;
                    dtgv.Columns[2].Width = 660;
                    dtgv.Columns[3].Width = 224;

                    dtgv.Columns[1].DataPropertyName = "bookCode";
                    dtgv.Columns[2].DataPropertyName = "bookName";
                    dtgv.Columns[3].DataPropertyName = "numsOfBorrowings";

                    lbTotalBorrowTitle.Visible = true;
                    lbTotalBorrow.Visible = true;

                    //dtp.CustomFormat = "dd/MM/yyyy";

                    lbTitleName.Text = $"Thống Kê Theo Sách Mượn Tháng {dtp.Value.Month.ToString()}";
                    break;

                case ReportType.Reader:
                    for (int i = dtgv.ColumnCount - 1; i > 0; i--)
                    {
                        // Xóa cột nếu không phải là cột đầu tiên
                        dtgv.Columns.RemoveAt(i);
                    }

                    dtgv.Columns.Add("temp1", "");
                    dtgv.Columns.Add("temp2", "");
                    dtgv.Columns.Add("temp3", "");

                    dtgv.Columns[1].HeaderText = "Mã độc giả";
                    dtgv.Columns[2].HeaderText = "Tên độc giả";
                    dtgv.Columns[3].HeaderText = "Số lượt mượn";

                    dtgv.Columns[1].Width = 220;
                    dtgv.Columns[2].Width = 660;
                    dtgv.Columns[3].Width = 224;

                    dtgv.Columns[1].DataPropertyName = "code";
                    dtgv.Columns[2].DataPropertyName = "name";
                    dtgv.Columns[3].DataPropertyName = "numsOfBorrowings";

                    lbTotalBorrowTitle.Visible = true;
                    lbTotalBorrow.Visible = true;

                    //dtp.CustomFormat = "dd/MM/yyyy";

                    lbTitleName.Text = $"Thống Kê Theo Độc Giả Tháng {dtp.Value.Month.ToString()}";
                    break;
            };

            lbTitleName.Location = new Point((this.Width - lbTitleName.Width) / 2, lbTitleName.Location.Y);
        }
        private void btnExport_Click(object sender, EventArgs e)
        {
            if(dtgv.Rows.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                SaveFileDialog saveFile = new SaveFileDialog();
                string reportName = "";

                switch (reportType)
                {
                    case ReportType.Book:
                        reportName = "BaoCaoTheoSachMuonThang";
                        break;
                    case ReportType.BookType:
                        reportName = "BaoCaoTheoTheLoaiThang";
                        break;
                    case ReportType.Reader:
                        reportName = "BaoCaoTheoDocGiaThang";
                        break;
                }

                saveFile.FileName = $@"{reportName}{dtp.Value.Month}";
                saveFile.Filter = "Excel File|*.xlsx";
                DialogResult dgResult = saveFile.ShowDialog();
                if (dgResult == DialogResult.OK)
                {
                    //gọi hàm ToExcel() với tham số là dtgDSHS và filename từ SaveFileDialog
                    ToExcel(dtgv, saveFile.FileName);
                }
            }
        }
        private void ToExcel(DataGridView dataGridView1, string fileName)
        {
            string sheetName = $"BaoCaoThang{dtp.Value.Month}";
            //Khai báo thư viện hỗ trợ Microsoft.Office.Interop.Excel
            Microsoft.Office.Interop.Excel.Application excel;
            Microsoft.Office.Interop.Excel.Workbook workbook;
            Microsoft.Office.Interop.Excel.Worksheet worksheet;
            try
            {
                //Tạo đối tượng COM.
                excel = new Microsoft.Office.Interop.Excel.Application();
                excel.Visible = false;
                excel.DisplayAlerts = false;
                //tạo mới một Workbooks bằng phương thức add()
                workbook = excel.Workbooks.Add(Type.Missing);
                worksheet = (Microsoft.Office.Interop.Excel.Worksheet)workbook.Sheets["Sheet1"];
                //đặt tên cho sheet
                worksheet.Name = sheetName;

                //Create header
                Microsoft.Office.Interop.Excel.Range headerRange = worksheet.Range["A1", "D1"];
                headerRange.Merge();
                headerRange.Value = lbTitleName.Text;
                headerRange.Font.Size = 18;
                headerRange.Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.LightGreen);
                //Center header text
                headerRange.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                headerRange.VerticalAlignment = Microsoft.Office.Interop.Excel.XlVAlign.xlVAlignCenter;
                Microsoft.Office.Interop.Excel.Range contentRange = worksheet.Range["A2", $"D{dataGridView1.RowCount + 2}"]; // A2 đến D(n + 2)
                contentRange.Font.Size = 14;

                headerRange.Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                headerRange.Borders.Weight = Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin;

                // Vẽ border cho mọi cell trong contentRange
                contentRange.Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                contentRange.Borders.Weight = Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin;

                // export header trong DataGridView
                for (int i = 0; i < dataGridView1.ColumnCount; i++)
                {
                    worksheet.Cells[2, i + 1] = dataGridView1.Columns[i].HeaderText;
                }
                // export nội dung trong DataGridView
                for (int i = 0; i < dataGridView1.RowCount; i++)
                {
                    for (int j = 0; j < dataGridView1.ColumnCount; j++)
                    {
                        worksheet.Cells[i + 3, j + 1] = dataGridView1.Rows[i].Cells[j].Value.ToString();
                    }
                }
                // Autofit cho các cột
                Microsoft.Office.Interop.Excel.Range columns = worksheet.UsedRange.Columns;
                columns.AutoFit();
                // sử dụng phương thức SaveAs() để lưu workbook với filename
                workbook.SaveAs(fileName);
                //đóng workbook
                workbook.Close();
                excel.Quit();
                MessageBox.Show("Xuất dữ liệu ra Excel thành công!");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Có lỗi xảy ra!\nError: {ex.Data.ToString()}", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                workbook = null;
                worksheet = null;
            }
        }

        private void dateTimePicker1_ValueChanged_1(object sender, EventArgs e)
        {

        }

        public bool CreateReportFile(int month, int year, string fileName)
        {
            if (dtgv.Rows.Count == 0)
            {
                return true;
            }
            else
            {
                string reportName = "";

                switch (reportType)
                {
                    case ReportType.Book:
                        reportName = "BaoCaoTheoSachMuonThang";
                        break;
                    case ReportType.BookType:
                        reportName = "BaoCaoTheoTheLoaiThang";
                        break;
                    case ReportType.Reader:
                        reportName = "BaoCaoTheoDocGiaThang";
                        break;
                }
                //ToExcel(dtgv, fileName);
            }
            return true;
        }

        private void cmbType_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cmbType.SelectedItem.ToString())
            {
                case "Thể loại":
                    reportType = ReportType.BookType;
                    break;
                case "Sách":
                    reportType = ReportType.Book;
                    break;
                case "Độc giả":
                    reportType = ReportType.Reader;
                    break;
            }
            ChangeDtgvLayout(reportType);
            CreateReport();
        }

        private void CreateReport()
        {
            dtgv.Rows.Clear();
            switch (cmbType.SelectedItem.ToString())
            {
                case "Thể loại":
                    CategoryReport();
                    break;
                case "Sách":
                    BookReport();
                    break;
                case "Độc giả":
                    ReaderReport();
                    break;
            }
        }

        private void BookReport()
        {
            reportByBook.Clear();

            /*string categoryReportCmd = $@"SELECT TenTheLoai, COUNT(THELOAI.MaTheLoai) AS 'So Luot Muon'
                FROM THELOAI, CUONSACH, SACH, DAUSACH, PHIEUMUON, CTPHIEUMUON
                WHERE CTPHIEUMUON.MaCuonSach = CUONSACH.MaCuonSach AND CUONSACH.MaSach = SACH.MaSach
		                AND SACH.MaDauSach = DAUSACH.MaDauSach AND DAUSACH.MaTheLoai = THELOAI.MaTheLoai
			                AND CTPHIEUMUON.MaPhieuMuonSach = PHIEUMUON.MaPhieuMuonSach
				                AND MONTH(NgMuon) = {dtp.Value.Month.ToString()}
                GROUP BY TenTheLoai, THELOAI.MaTheLoai
                ORDER BY [So Luot Muon] DESC";*/
            string bookReportCmd = $@"SELECT DAUSACH.MaDauSach, TenDauSach, COUNT(DAUSACH.MaDauSach) AS 'SO LUOT MUON'
                FROM THELOAI, CUONSACH, SACH, DAUSACH, PHIEUMUON, CTPHIEUMUON
                WHERE CTPHIEUMUON.MaCuonSach = CUONSACH.MaCuonSach AND CUONSACH.MaSach = SACH.MaSach
		                AND SACH.MaDauSach = DAUSACH.MaDauSach AND DAUSACH.MaTheLoai = THELOAI.MaTheLoai
			                AND CTPHIEUMUON.MaPhieuMuonSach = PHIEUMUON.MaPhieuMuonSach
				                AND MONTH(NgMuon) = {dtp.Value.Month.ToString()}
                GROUP BY DAUSACH.MaDauSach, TenDauSach
                ORDER BY [So Luot Muon] DESC";

            SqlConnection conn = new SqlConnection(DatabaseInfo.connectionString);
            conn.Open();
            SqlCommand cmd = new SqlCommand(bookReportCmd, conn);
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    reportByBook.Add(new ReportByBook(reader.GetString(0), reader.GetString(1), reader.GetInt32(2)));
                }
            }
            int stt = 1;
            float totalNumOfBorrowings = 0;
            foreach (ReportByBook report in reportByBook)
            {
                report.stt = stt;
                totalNumOfBorrowings += report.numsOfBorrowings;
                stt++;
            }

            lbTotalBorrow.Text = totalNumOfBorrowings.ToString();

            binding = new BindingSource();
            binding.DataSource = reportByBook;
            dtgv.DataSource = binding;

            if (dtgv.Rows.Count != 0)
            {
                dtgv.SelectedRows[0].Selected = false;
                lbInform.Visible = false;
            }
            else
            {
                lbInform.Visible = true;
                lbInform.Text = $"Không có quyển sách nào được mượn trong tháng {dtp.Value.Month}";
                lbInform.Location = new Point((this.Width - lbInform.Width) / 2, lbInform.Location.Y);
            }
        }

        private void ReaderReport()
        {
            reportByReader.Clear();

            string readerReportCmd = $@"SELECT DOCGIA.MaDocGia, HoTen, COUNT(DOCGIA.MaDocGia) AS 'SO LUOT MUON'
                FROM THELOAI, CUONSACH, SACH, DAUSACH, PHIEUMUON, CTPHIEUMUON, DOCGIA
                WHERE CTPHIEUMUON.MaCuonSach = CUONSACH.MaCuonSach AND CUONSACH.MaSach = SACH.MaSach
		                AND SACH.MaDauSach = DAUSACH.MaDauSach AND DAUSACH.MaTheLoai = THELOAI.MaTheLoai
			                AND CTPHIEUMUON.MaPhieuMuonSach = PHIEUMUON.MaPhieuMuonSach AND PHIEUMUON.MaDocGia = DOCGIA.MaDocGia
				                AND MONTH(NgMuon) = 11
                GROUP BY DOCGIA.MaDocGia, HoTen
                ORDER BY [So Luot Muon] DESC";
            SqlConnection conn = new SqlConnection(DatabaseInfo.connectionString);
            conn.Open();
            SqlCommand cmd = new SqlCommand(readerReportCmd, conn);
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    reportByReader.Add(new ReportByReader(reader.GetString(0), reader.GetString(1), reader.GetInt32(2)));
                }
            }
            int stt = 1;
            float totalNumOfBorrowings = 0;
            foreach (ReportByReader report in reportByReader)
            {
                report.stt = stt;
                totalNumOfBorrowings += report.numsOfBorrowings;
                stt++;
            }

            lbTotalBorrow.Text = totalNumOfBorrowings.ToString();

            binding = new BindingSource();
            binding.DataSource = reportByReader;
            dtgv.DataSource = binding;

            if (dtgv.Rows.Count != 0)
            {
                dtgv.SelectedRows[0].Selected = false;
                lbInform.Visible = false;
            }
            else
            {
                lbInform.Visible = true;
                lbInform.Text = $"Không có quyển sách nào được mượn trong tháng {dtp.Value.Month}";
                lbInform.Location = new Point((this.Width - lbInform.Width) / 2, lbInform.Location.Y);
            }
        }
    }
}
