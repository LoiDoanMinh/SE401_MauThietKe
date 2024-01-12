using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LibraryManagement.Models.Builder
{
    public class LibraryReportBuilder
    {
        private string header = "";
        private string fileName = "";
        private string sheetName = "";
        public LibraryReportBuilder()
        {
            
        }
        public void AddHeader(string header)
        {
            this.header = header;
        }
        public void AddFileName(string fileName)
        {
            this.fileName = fileName;
        }
        public void AddSheetName(string sheetName)
        {
            this.sheetName = sheetName;
        }
        public void CreateReport(DataGridView dataGridView1)
        {
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
                worksheet.Name = this.sheetName;

                //Create header
                Microsoft.Office.Interop.Excel.Range headerRange = worksheet.Range["A1", "D1"];
                headerRange.Merge();
                headerRange.Value = this.header;
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
                workbook.SaveAs(this.fileName);
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
    }
}
