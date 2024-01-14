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
    class DetailImportSlip : IDetailImportSlip
    {
        public String detailImportSlipCode;
        public long amount;
        public float unitPrice;
        public float price;
        public Book book { get; set; }
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
        public DetailImportSlip(long amount, float unitPrice, Book book)
        {

            this.amount = amount;
            this.unitPrice = unitPrice;
            this.book = book;
        }
        public DetailImportSlip() { }
        public DetailImportSlip(String detailImportSlipCode)
        {

            this.detailImportSlipCode = detailImportSlipCode;
        }
        public void AddBookVolumes(Book book, int quantity, DetailImportSlip detailSlip)
        {
            book.CreateBookVolumes(book, quantity, detailSlip);
        }

        public void updateDetaiImportSlip(string importSlipCode)
        {
            string deleteBookVolumes = "DELETE FROM CUONSACH WHERE MaCTPN = '" + this.detailImportSlipCode + "'";
            ketnoiNonQuery(deleteBookVolumes);
            string updateDetailSlip = "UPDATE  CT_PHIEUNHAP SET MaPhieuNhapSach = '" + importSlipCode + "', MaSach = '" + book.BookCode + "', SoLuong = " + this.amount + ", DonGia = " + unitPrice.ToString() + "" +
                            "WHERE MaCTPN = '" + detailImportSlipCode + "'";
            ketnoiNonQuery(updateDetailSlip);
        }
    }
}
