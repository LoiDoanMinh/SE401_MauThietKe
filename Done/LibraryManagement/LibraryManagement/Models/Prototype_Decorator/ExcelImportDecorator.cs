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
using System.Text.RegularExpressions;
using LibraryManagement.Models;
using System.Threading.Tasks;
namespace LibraryManagement.Models.Prototype_Decorator
{
    class ExcelImportDecorator : DetailImportSlipDecorator
    {
        string chuoiKetNoi = $@"{LibraryManagement.Models.DatabaseInfo.connectionString}";
        private SqlConnection myConnection; // kết nối tới csdl
        private SqlDataAdapter myDataAdapter;   // Vận chuyển csdl qa DataSet
        private DataTable myTable;  // Dùng để lưu bảng lấy từ c#
        SqlCommand myCommand;   // Thực hiện cách lệnh truy vấn
        private void ketnoiNonQuery(string nonquery)
        {
            myConnection = new SqlConnection(chuoiKetNoi);
            myConnection.Open();
            string thuchiencaulenh = nonquery;
            myCommand = new SqlCommand(thuchiencaulenh, myConnection);
            myCommand.ExecuteNonQuery();

        }
        public ExcelImportDecorator(IDetailImportSlip detailImportSlip)
        : base(detailImportSlip)
        {
        }

        // Tính năng mới: Nhập sách từ file Excel
        public void ImportFromExcel(string filePath)
        {
            try
            {
                Microsoft.Office.Interop.Excel.Application xlApp = new Microsoft.Office.Interop.Excel.Application();
                Microsoft.Office.Interop.Excel.Workbook xlWorkbook = xlApp.Workbooks.Open(filePath);
                Microsoft.Office.Interop.Excel._Worksheet xlWorksheet = xlWorkbook.Sheets[1];

                int rows = xlWorksheet.UsedRange.Rows.Count;
                int cols = xlWorksheet.UsedRange.Columns.Count;

                DataTable dtResult = new DataTable();
                for (int c = 1; c <= cols; c++)
                {
                    string colname = xlWorksheet.Cells[1, c].Text;
                    dtResult.Columns.Add(colname);
                }

                for (int r = 2; r <= rows; r++)
                {
                    DataRow dr = dtResult.NewRow();
                    for (int c = 1; c <= cols; c++)
                    {
                        dr[c - 1] = xlWorksheet.Cells[r, c].Text;
                    }
                    dtResult.Rows.Add(dr);
                }

                try
                {
                    for (int i = 0; i < dtResult.Rows.Count; i++)
                    {
                        string bookCode = dtResult.Rows[i]["MaSach"].ToString().Trim();
                        int amount = int.Parse(dtResult.Rows[i]["SoLuong"].ToString().Trim());
                        float unitPrice = int.Parse(dtResult.Rows[i]["DonGia"].ToString().Trim());
                        string importSlipCode = dtResult.Rows[i]["MaPhieuNhapSach"].ToString().Trim();
                        Book book = new LibraryManagement.Models.Prototype_Decorator.Book(bookCode);
                        DetailImportSlip detailImportSlip = new DetailImportSlip(amount, unitPrice, book);
                        ImportSlip importSlip = new ImportSlip();
                        importSlip.addDetailImportSlip(importSlipCode, detailImportSlip);
                        //myConnection.Close();
                    }
                    MessageBox.Show("Nhập sách thành công", "Thông báo");
                    //loadDgv();
                }
                catch
                {
                    MessageBox.Show("Nhập sách thất bại", "Thông báo");
                }
            }
            catch
            {
            }
        }
    }

}
