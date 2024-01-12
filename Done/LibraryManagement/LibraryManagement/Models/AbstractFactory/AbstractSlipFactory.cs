using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Models.AbstractFactory
{
    public class SlipFactory
    {
        public static SlipFactory CreateFactory(string type)
        {
            if(type == "borrow")
            {
                return new BorrowReceiptFactory();
            }
            return new ReturnReceiptFactory();
        }
        public Receipt CreateReceipt(int stt, string id, string readerId, string readerName, string borrowDate, string returnDate)
        {
            return new BorrowCard(stt, id, readerId, readerName, borrowDate, returnDate);
        }
        public Receipt CreateReceipt(int stt, string id, string readerId, string readerName, string returnDate, long fineThisPeriod)
        {
            return new ReturnCard(stt, id, readerId, readerName, returnDate, fineThisPeriod);
        }
    }
}
