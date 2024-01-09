using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Models.AbstractFactory
{
    public class Receipt
    {
        public int stt { get; set; }
        public string id { get; set; }
        public string readerId { get; set; }
        public string readerName { get; set; }
        public string returnDate { get; set; }
        public string Details;
        public double Amount;
    }
}
