using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Models.Prototype_Decorator
{
    interface IDetailImportSlip
    {
        void AddBookVolumes(Book book, int quantity, DetailImportSlip detailSlip);
        void updateDetaiImportSlip(string importSlipCode);


    }
}
