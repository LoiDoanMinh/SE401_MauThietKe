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
    class ConcreteBookVolume : IBookVolumePrototype
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
        public string BookVolumeCode { get; set; }
        public bool State { get; set; }
        public IBookVolumePrototype Clone()
        {
            // Sử dụng shallow copy để tạo ra một bản sao của đối tượng
            return (IBookVolumePrototype)this.MemberwiseClone();
        }

        public void Add(Book book, DetailImportSlip detailSlip)
        {
            string nonquery = "INSERT INTO CUONSACH(MaSach, TinhTrang, MaCTPN) VALUES ('" + book.BookCode + "' , '" + this.State + "', '" + detailSlip.detailImportSlipCode + "')";
            ketnoiNonQuery(nonquery);
        }

    }
}
