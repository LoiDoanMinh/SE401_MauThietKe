using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using LibraryManagement.Models.AbstractFactory;

namespace LibraryManagement.Models
{
    public class BorrowCard : Receipt
    {
        public string borrowDate { get; set; }
        public bool status { get; set; }
        public List<Book> borrowBooks;

        public BorrowCard()
        {
            id = "";
            readerId = "";
            readerName = "";
            borrowDate = "";
            returnDate = "";
            status = false;
            borrowBooks = new List<Book>();
        }

        public BorrowCard(string id, string readerId, string readerName, string borrowDate, string returnDate)
        {
            this.id = id;
            this.readerId = readerId;
            this.readerName = readerName;
            this.borrowDate = borrowDate;
            this.returnDate = returnDate;
        }

        public BorrowCard(int stt, string id, string readerId, string readerName, string borrowDate, string returnDate)
        {
            this.stt = stt;
            this.id = id;
            this.readerId = readerId;
            this.readerName = readerName;
            this.borrowDate = borrowDate;
            this.returnDate = returnDate;
        }

        public static BorrowCard GetBorrowCard(string id)
        {
            try
            {
                BorrowCard borrowCard = null;
                SqlConnection conn = new SqlConnection(DatabaseInfo.connectionString);
                conn.Open();
                SqlCommand cmd = new SqlCommand(DatabaseInfo.GetBorrowCardById(id), conn);
                using (SqlDataReader reader = cmd.ExecuteReader())
                    while (reader.Read())
                        borrowCard = new BorrowCard(reader.GetString(0), reader.GetString(1), reader.GetString(2), reader.GetDateTime(3).ToString("dd/MM/yyyy"), reader.GetDateTime(4).ToString("dd/MM/yyyy"));

                List<Book> borrowBooks = new List<Book>();
                cmd.CommandText = DatabaseInfo.GetAllDetailBorrowByBorrowCardId(id);
                using (SqlDataReader reader = cmd.ExecuteReader())
                    while (reader.Read())
                        borrowBooks.Add(new Book(reader.GetString(1)));
                conn.Close();

                borrowCard.borrowBooks = borrowBooks;
                return borrowCard;
            }
            catch
            {
                return null;
            }
        }

        public static bool DeleteBorrowCard(string id)
        {
            try
            {
                SqlConnection conn = new SqlConnection(DatabaseInfo.connectionString);
                conn.Open();
                SqlCommand cmd = new SqlCommand(DatabaseInfo.DeleteBorrowCard(id), conn);
                cmd.ExecuteNonQuery();
                conn.Close();

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Xóa chi tiết phiếu thất bại! Vui lòng thử lại!\n(" + ex.Message + ")");
                return false;
            }
        }
    }
}
