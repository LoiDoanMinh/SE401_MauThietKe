using System.Data.SqlClient;

namespace LibraryManagement.Models
{
    public class DetailBorrowCard
    {
        public int stt { get; set; }
        public string id { get; set; }
        public string borrowCardId;
        public string bookId { get; set; }
        public string bookName { get; set; }
        public bool status { get; set; }

        public DetailBorrowCard(int stt, string id, string borrowCardId, string bookId, string bookName, bool status)
        {
            this.stt = stt;
            this.id = id;
            this.borrowCardId = borrowCardId;
            this.bookId = bookId;
            this.bookName = bookName;
            this.status = status;
        }

        public static string GetIdByBorrowCardIdAndBookId(string borrowCardId, string bookId)
        {
            SqlConnection conn = new SqlConnection(DatabaseInfo.connectionString);
            SqlCommand cmd = new SqlCommand(DatabaseInfo.GetDetailBorrowIdByBorrowCardIdAndBookId(borrowCardId, bookId), conn);
            conn.Open();
            return cmd.ExecuteScalar().ToString();
        }
    }
}
