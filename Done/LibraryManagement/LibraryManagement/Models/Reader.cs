using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Models
{
    public class Reader
    {
        public string code { get; set; }
        public string name { get; set; }
        public DateTime dateExpried { get; set; }
        public string email;

        public Reader(string code, string name, DateTime dateExpried, string email)
        {
            this.code = code;
            this.name = name;
            this.dateExpried = dateExpried;
            this.email = email;
        }

        public static Reader GetReader(string id)
        {
            try
            {
                Reader r = null;
                SqlConnection conn = new SqlConnection(DatabaseInfo.connectionString);
                conn.Open();
                SqlCommand cmd = new SqlCommand(DatabaseInfo.GetReaderById(id), conn);
                using (SqlDataReader reader = cmd.ExecuteReader())
                    while (reader.Read())
                        r = new Reader(reader.GetString(0), reader.GetString(1), reader.GetDateTime(2), reader.GetString(3));
                return r;
            }
            catch
            {
                return null;
            }
        }
    }
}
