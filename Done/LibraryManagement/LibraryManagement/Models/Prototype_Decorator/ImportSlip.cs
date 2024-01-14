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
    class ImportSlip
    {
        public string importSlipCode;
        public DateTime importDate;
        public float price;
        public List<IDetailImportSlip> listDetailImport;
        public void addDetailImportSlip(string importSlipCode, DetailImportSlip detail)
        {
            string slipCode = importSlipCode;
            string bookCode = detail.book.BookCode;
            long amount = detail.amount;
            float unitPrice = detail.unitPrice;
            string query = "INSERT INTO CT_PHIEUNHAP (MaPhieuNhapSach, MaSach, SoLuong, DonGia) VALUES ('" + slipCode + "', '" + bookCode + "', " + amount + ", " + unitPrice + ")";
            ketnoiNonQuery(query);
        }
        public void deleteDetailImportSlip(DetailImportSlip detail)
        {
            string deleteBookVolume = "DELETE FROM CUONSACH WHERE MaCTPN = '" + detail.detailImportSlipCode + "'";
            ketnoiNonQuery(deleteBookVolume);
            string deleteDetailSlip = "DELETE FROM CT_PHIEUNHAP WHERE MaCTPN = '" + detail.detailImportSlipCode + "'";
            ketnoiNonQuery(deleteDetailSlip);
        }

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
    }
}
