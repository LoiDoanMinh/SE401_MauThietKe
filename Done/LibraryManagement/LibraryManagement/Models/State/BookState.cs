using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Models.State
{
    public abstract class BookState
    {
        protected Book _context;

        public void SetContext(Book context)
        {
            this._context = context;
        }

        public abstract string HandleBorrowRequest();
        public abstract string HandleBorrowRequest(string id);

        public abstract string HandleReturnRequest();
        public abstract string HandleReturnRequest(string id);
    }
}
