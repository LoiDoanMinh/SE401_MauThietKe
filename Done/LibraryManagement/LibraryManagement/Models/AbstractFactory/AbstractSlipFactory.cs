using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Models.AbstractFactory
{
    public abstract class AbstractSlipFactory
    {
        public abstract Receipt CreateReceipt(int stt, string id, string readerId, string readerName, string borrowDate, string returnDate);
        public abstract void SetDetails(string details);
        public abstract void SetAmount(double amount);
    }
}
