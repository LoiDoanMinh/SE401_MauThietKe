using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Models.AbstractFactory
{
    public class BorrowReceiptFactory : SlipFactory
    {
        private Receipt receipt = new Receipt();

        public Receipt CreateReceipt(int stt, string id, string readerId, string readerName, string borrowDate, string returnDate)
        {
            return new BorrowCard(stt, id, readerId, readerName, borrowDate, returnDate);
        }

        public void SetDetails(string details)
        {
            receipt.Details = $"Borrow Receipt - {details}";
        }

        public void SetAmount(double amount)
        {
            receipt.Amount = amount;
        }
    }

    public class ReturnReceiptFactory : SlipFactory
    {
        private Receipt receipt = new Receipt();

        public Receipt CreateReceipt(int stt, string id, string readerId, string readerName, string returnDate, long fineThisPeriod)
        {
            return new ReturnCard(stt, id, readerId, readerName, returnDate, fineThisPeriod);
        }

        public void SetDetails(string details)
        {
            receipt.Details = $"Return Receipt - {details}";
        }

        public void SetAmount(double amount)
        {
            receipt.Amount = amount;
        }
    }

    public class FineReceiptFactory : SlipFactory
    {
        private Receipt receipt = new Receipt();

        public Receipt CreateReceipt(int stt, string id, string readerId, string readerName, string borrowDate, string returnDate)
        {
            return receipt;
        }

        public void SetDetails(string details)
        {
            receipt.Details = $"Fine Receipt - {details}";
        }

        public void SetAmount(double amount)
        {
            receipt.Amount = amount;
        }
    }
}
