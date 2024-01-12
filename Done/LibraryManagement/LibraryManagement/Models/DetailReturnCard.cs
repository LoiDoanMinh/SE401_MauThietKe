using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Windows;

namespace LibraryManagement.Models
{
    public class DetailReturnCard
    {
        public int stt { get; set; }
        public string id { get; set; }
        public string returnCardId;
        public string borrowCardId;
        public string bookId { get; set; }
        public string bookName { get; set; }
        public int borrowDays { get; set; }
        public int lateDays { get; set; }
        public long fine { get; set; }

        public DetailReturnCard(string id, string bookId, string bookName, string returnCardId, string borrowCardId, int borrowDays, int lateDays, long fine)
        {
            this.id = id;
            this.bookId = bookId;
            this.bookName = bookName;
            this.returnCardId = returnCardId;
            this.borrowCardId = borrowCardId;
            this.borrowDays = borrowDays;
            this.lateDays = lateDays;
            this.fine = fine;
        }

        public DetailReturnCard(int stt, string id, string bookId, string bookName, string returnCardId, string borrowCardId, int borrowDays, long fine)
        {
            this.stt = stt;
            this.id = id;
            this.bookId = bookId;
            this.bookName = bookName;
            this.returnCardId = returnCardId;
            this.borrowCardId = borrowCardId;
            this.borrowDays = borrowDays;
            this.lateDays = lateDays;
            this.fine = fine;
        }

        public static DetailReturnCard GetDetailReturnCard(string id)
        {
            try
            {
                DetailReturnCard detail = null;
                SqlConnection conn = new SqlConnection(DatabaseInfo.connectionString);
                conn.Open();
                SqlCommand cmd = new SqlCommand(DatabaseInfo.GetDetailReturnCardById(id), conn);
                using (SqlDataReader reader = cmd.ExecuteReader())
                    while (reader.Read())
                        detail = new DetailReturnCard(reader.GetString(0), reader.GetString(1), reader.GetString(2), reader.GetString(3), reader.GetString(4), reader.GetInt32(5), reader.GetInt32(5), (long)reader.GetDecimal(7));
                return detail;
            }
            catch
            {
                return null;
            }
        }

        public static bool DeleteDetailReturnCard(DetailReturnCard detail, bool deleteCard)
        {
            try
            {
                SqlConnection conn = new SqlConnection(DatabaseInfo.connectionString);
                conn.Open();
                SqlCommand cmd = new SqlCommand(DatabaseInfo.DeleteDetailReturnCardById(detail, DetailBorrowCard.GetIdByBorrowCardIdAndBookId(detail.borrowCardId, detail.bookId), deleteCard), conn);
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
