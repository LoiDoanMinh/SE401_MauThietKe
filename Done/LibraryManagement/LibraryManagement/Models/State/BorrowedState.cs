using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Models.State
{
    public class BorrowedState : BookState
    {
        public override string HandleBorrowRequest() { return ""; }
        public override string HandleReturnRequest()
        {
            return "\n" + $@"UPDATE CUONSACH SET TinhTrang = 1 WHERE MaCuonSach = '{base._context.id}'";
        }
        public override string HandleBorrowRequest(string bookID) { return ""; }
        public override string HandleReturnRequest(string bookID)
        {
            return "\n" + $@"UPDATE CUONSACH SET TinhTrang = 1 WHERE MaCuonSach = '{bookID}'";
        }

    }
}
