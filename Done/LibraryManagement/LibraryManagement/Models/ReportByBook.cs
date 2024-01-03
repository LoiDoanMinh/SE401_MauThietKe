using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Models
{
    public class ReportByBook
    {
        public int stt { get; set; }
        public string bookName { get; set; }
        public string bookCode { get; set; }
        public int numsOfBorrowings { get; set; }
        public ReportByBook() { }

        public ReportByBook(string bookName, string bookCode, int numsOfBorrowings)
        {
            this.bookName = bookName;
            this.bookCode = bookCode;
            this.numsOfBorrowings = numsOfBorrowings;
        }
    }
}
