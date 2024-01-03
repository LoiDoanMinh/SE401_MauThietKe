using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Models
{
    public class ReportByReader
    {
        public int stt { get; set; }
        public string code { get; set; }
        public string name { get; set; }
        public int numsOfBorrowings { get; set; }
        public ReportByReader() { }

        public ReportByReader(string code, string name, int numsOfBorrowings)
        {
            this.code = code;
            this.name = name;
            this.numsOfBorrowings = numsOfBorrowings;
        }
    }
}
