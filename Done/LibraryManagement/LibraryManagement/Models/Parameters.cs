using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace LibraryManagement.Models
{
    public class Parameters
    {
        public static int maxBorrowDays;
        public static int maxBorrowBooks;
        public static long finePerDay;
        public Parameters()
        {
            
        }
        public static void LoadParam()
        {
            SqlConnection conn = new SqlConnection(DatabaseInfo.connectionString);
            conn.Open();
            SqlCommand cmd = new SqlCommand(DatabaseInfo.parametersQueryCmd, conn);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                maxBorrowDays = (int)reader.GetInt32(4);
                maxBorrowBooks = (int)reader.GetInt32(5);
                finePerDay = (long)reader.GetSqlMoney(6);
            }
        }
    }
}
