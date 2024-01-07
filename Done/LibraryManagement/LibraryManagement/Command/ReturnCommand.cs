using DemoDesign;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Command
{
    public class ReturnCommand : ICommand
    {
        private BorrowReturnBook form;

        public ReturnCommand(BorrowReturnBook form)
        {
            this.form = form;
        }

        public void Execute()
        {
            form.CreateReturnCardMethod();
        }
    }
}
