using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Models.State
{
    public class AvailableState : BookState
    {
        public override string HandleBorrowRequest()
        {
            return "\n" + $@"UPDATE CUONSACH SET TinhTrang = 0 WHERE MaCuonSach = '{base._context.id}'";
        }
        public override string HandleReturnRequest()
        {
            return "";
        }
        public override string HandleBorrowRequest(string bookID) 
        {
            return "\n" + $@"UPDATE CUONSACH SET TinhTrang = 0 WHERE MaCuonSach = '{bookID}'";
        }
        public override string HandleReturnRequest(string bookID)
        {
            return "";
        }
    }
}
