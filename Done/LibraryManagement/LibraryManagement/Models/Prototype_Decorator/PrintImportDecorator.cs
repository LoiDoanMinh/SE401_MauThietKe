using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Models.Prototype_Decorator
{
    class PrintImportDecorator : DetailImportSlipDecorator
    {
        public PrintImportDecorator(IDetailImportSlip detailImportSlip)
       : base(detailImportSlip)
        {
        }

        // Tính năng mới: in danh sách sách vừa nhập ra file excel
        public void exportToExcel(string filePath)
        {

        }
    }
}
