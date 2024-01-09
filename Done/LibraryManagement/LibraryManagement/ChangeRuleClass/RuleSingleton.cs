using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;
using System.Data.SqlClient;
using LibraryManagement.Class;
namespace LibraryManagement.ChangeRuleClass
{

    public class RuleSingleton
    {
        SqlConnection connection;
        SqlCommand command;
        System.Data.DataTable table = new System.Data.DataTable();
        string str = $@"{LibraryManagement.Models.DatabaseInfo.connectionString}";
        SqlDataAdapter adapter = new SqlDataAdapter();

        private int _duration;
        private int _minAge;
        private int _maxAge;
        private int _cirulationTime;
        private int _maxBorrowDay;
        private int _maxBorrowBook;
        private float _fine;

        public int Duration
        {
            get { return _duration; }
            set { _duration = value; }
        }

        public int MinAge
        {
            get { return _minAge; }
            set { _minAge = value; }
        }

        public int MaxAge
        {
            get { return _maxAge; }
            set { _maxAge = value; }
        }

        public int CirulationTime
        {
            get { return _cirulationTime; }
            set { _cirulationTime = value; }
        }

        public int MaxBorrowDay
        {
            get { return _maxBorrowDay; }
            set { _maxBorrowDay = value; }
        }

        public int MaxBorrowBook
        {
            get { return _maxBorrowBook; }
            set { _maxBorrowBook = value; }
        }

        public float Fine
        {
            get { return _fine; }
            set { _fine = value; }
        }
        private static readonly object lockObject = new object();
        private static volatile RuleSingleton uniqueInstance;
        private RuleSingleton()
        {
            using (connection = new SqlConnection(str))
            {
                connection.Open();

                // Sử dụng connection để tạo command
                command = connection.CreateCommand();
                command.CommandText = "select ThoiHanThe,TuoiToiThieu,TuoiToiDa,ThoiGianLuuHanh,SoNgayMuonMax,SoSachMuonMax,format(MucThuTienPhat,'#.') from ThamSo ";
                // Thực thi command
                command.ExecuteNonQuery();

                // Làm việc với dữ liệu và đổ vào DataTable
                table.Clear();
                adapter.SelectCommand = command;
                adapter.Fill(table);

                Duration = int.Parse(table.Rows[0].ItemArray[0].ToString());

                CirulationTime = int.Parse(table.Rows[0].ItemArray[3].ToString());


                MaxAge = int.Parse(table.Rows[0].ItemArray[2].ToString());

                MinAge = int.Parse(table.Rows[0].ItemArray[1].ToString());

                MaxBorrowDay = int.Parse(table.Rows[0].ItemArray[4].ToString());

                MaxBorrowBook = int.Parse(table.Rows[0].ItemArray[5].ToString());

                Fine = float.Parse(table.Rows[0].ItemArray[6].ToString());

            } // Kết thúc sử dụng connection, tự động đóng kết nối

        }
        public static RuleSingleton GetInstance()
        {

            if (uniqueInstance == null)
            {
                lock (lockObject)
                {
                    if (uniqueInstance == null)
                    {
                        uniqueInstance = new RuleSingleton();

                    }
                }
            }
            return uniqueInstance;
        }
    }
}
