using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using LibraryManagement.Class;
namespace LibraryManagement.Class
{
    public class SearchByMSStrategy : ISearchStrategy
    {
        SqlConnection connection;
        SqlCommand command;
        System.Data.DataTable table = new System.Data.DataTable();
        string str = $@"{LibraryManagement.Models.DatabaseInfo.connectionString}";
        SqlDataAdapter adapter = new SqlDataAdapter();
        public System.Data.DataTable fillter(System.Data.DataTable _sreachResult, string s1)
        {
            // Khởi tạo và mở kết nối
            using (connection = new SqlConnection(str))
            {
                connection.Open();

                // Sử dụng connection để tạo command
                command = connection.CreateCommand();
                command.CommandText = "Select ROW_NUMBER() OVER (ORDER BY t.MaSach) AS [Số thứ tự],t.masach as [Mã Cuốn Sách],t.TenDauSach as [Tên Sách],t.TenTheLoai as [Thể Loại],t.TenTacGia as [Tác Giả],t.TinhTrang as [Tình Trạng] from TraCuu as t,sach as s,cuonsach as cs where s.MaSach='" + s1 + "' and cs.masach=s.masach and t.masach=cs.macuonsach";

                // Thực thi command
                command.ExecuteNonQuery();

                // Làm việc với dữ liệu và đổ vào DataTable
                table.Clear();
                adapter.SelectCommand = command;
                adapter.Fill(table);
            } // Kết thúc sử dụng connection, tự động đóng kết nối

            return table;
        }
    }
}
