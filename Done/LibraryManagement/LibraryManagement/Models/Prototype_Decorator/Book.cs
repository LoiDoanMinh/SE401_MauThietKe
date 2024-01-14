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
    class Book
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
        public string BookCode { get; set; }
        public string Publisher { get; set; }
        public DateTime PublishYear { get; set; }
        public long Amount { get; set; }
        public float Value { get; set; }
        public List<IBookVolumePrototype> ListBookVolume { get; set; }
        public Book(string bookCode)
        {
            this.BookCode = bookCode;
        }
        public void CreateBookVolumes(Book book, int quantity, DetailImportSlip detailSlip)
        {
            IBookVolumePrototype prototype = new ConcreteBookVolume
            {
                State = true // Trạng thái mặc định khi tạo mới
            };
            for (int i = 0; i < quantity; i++)
            {
                ConcreteBookVolume bookClone = (ConcreteBookVolume)prototype.Clone();
                bookClone.Add(book, detailSlip);
            }
        }

    }
}
