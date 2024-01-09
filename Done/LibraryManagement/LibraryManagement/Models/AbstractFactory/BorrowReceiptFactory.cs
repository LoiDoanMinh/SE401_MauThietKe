using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Models.AbstractFactory
{
    public class BorrowReceiptFactory : AbstractSlipFactory
    {
        private Receipt receipt = new Receipt();

        public override Receipt CreateReceipt(int stt, string id, string readerId, string readerName, string borrowDate, string returnDate)
        {
            return new BorrowCard(stt, id, readerId, readerName, borrowDate, returnDate);
        }

        public override void SetDetails(string details)
        {
            receipt.Details = $"Borrow Receipt - {details}";
        }

        public override void SetAmount(double amount)
        {
            receipt.Amount = amount;
        }
    }

    public class ReturnReceiptFactory : AbstractSlipFactory
    {
        private Receipt receipt = new Receipt();

        public override Receipt CreateReceipt(int stt, string id, string readerId, string readerName, string borrowDate, string returnDate)
        {
            return null;
        }

        public Receipt CreateReceipt1(int stt, string id, string readerId, string readerName, string returnDate, long fineThisPeriod)
        {
            return new ReturnCard(stt, id, readerId, readerName, returnDate, fineThisPeriod);
        }

        public override void SetDetails(string details)
        {
            receipt.Details = $"Return Receipt - {details}";
        }

        public override void SetAmount(double amount)
        {
            receipt.Amount = amount;
        }
    }

    public class FineReceiptFactory : AbstractSlipFactory
    {
        private Receipt receipt = new Receipt();

        public override Receipt CreateReceipt(int stt, string id, string readerId, string readerName, string borrowDate, string returnDate)
        {
            return receipt;
        }

        public override void SetDetails(string details)
        {
            receipt.Details = $"Fine Receipt - {details}";
        }

        public override void SetAmount(double amount)
        {
            receipt.Amount = amount;
        }
    }
}
