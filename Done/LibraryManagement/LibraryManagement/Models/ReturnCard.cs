using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Windows;

namespace LibraryManagement.Models
{
    public class ReturnCard
    {
        public int stt { get; set; }
        public string id { get; set; }
        public string readerId { get; set; }
        public string readerName { get; set; }
        public string returnDate { get; set; }
        public long fineThisPeriod { get; set; }
        public BindingList<BorrowedBook> returnBooks;

        public ReturnCard() { returnBooks = new BindingList<BorrowedBook>(); }

        public ReturnCard(string id, string readerId, string readerName, string returnDate, long fineThisPeriod)
        {
            this.id = id;
            this.readerId = readerId;
            this.readerName = readerName;
            this.returnDate = returnDate;
            this.fineThisPeriod = fineThisPeriod;
        }

        public ReturnCard(int stt, string id, string readerId, string readerName, string returnDate, long fineThisPeriod)
        {
            this.stt = stt;
            this.id = id;
            this.readerId = readerId;
            this.readerName = readerName;
            this.returnDate = returnDate;
            this.fineThisPeriod = fineThisPeriod;
        }

        public static ReturnCard GetReturnCard(string id)
        {
            try
            {
                ReturnCard returnCard = null;
                SqlConnection conn = new SqlConnection(DatabaseInfo.connectionString);
                conn.Open();
                SqlCommand cmd = new SqlCommand(DatabaseInfo.GetReturnCardById(id), conn);
                using (SqlDataReader reader = cmd.ExecuteReader())
                    while (reader.Read())
                        returnCard = new ReturnCard(reader.GetString(0), reader.GetString(1), reader.GetString(2), reader.GetDateTime(3).ToString("dd/MM/yyyy"), (long)reader.GetDecimal(4));

                return returnCard;
            }
            catch
            {
                return null;
            }
        }

        public static bool DeleteReturnCard(string id)
        {
            try
            {
                SqlConnection conn = new SqlConnection(DatabaseInfo.connectionString);
                conn.Open();
                SqlCommand cmd = new SqlCommand(DatabaseInfo.DeleteReturnCard(id), conn);
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
