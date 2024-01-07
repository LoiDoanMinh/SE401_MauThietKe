using DemoDesign;
using LibraryManagement.Forms;
using LibraryManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace LibraryManagement.Command
{
    public class BorrowCommand : ICommand
    {
        private BorrowReturnBook form; 

        public BorrowCommand(BorrowReturnBook form)
        {
            this.form = form;
        }

        public void Execute()
        {
            form.CreateBorrowCardMethod();
        }
    }
}
