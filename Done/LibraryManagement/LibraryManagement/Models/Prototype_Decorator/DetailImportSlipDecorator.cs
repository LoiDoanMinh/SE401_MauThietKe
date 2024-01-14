using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Models.Prototype_Decorator
{
    class DetailImportSlipDecorator
    {
        private readonly IDetailImportSlip _detailImportSlip;

        public DetailImportSlipDecorator(IDetailImportSlip detailImportSlip)
        {
            _detailImportSlip = detailImportSlip;
        }

        public void AddBookVolumes(Book book, int quantity, DetailImportSlip detailSlip)
        {
            _detailImportSlip.AddBookVolumes(book, quantity, detailSlip);
        }

        public void updateDetaiImportSlip(string importSlipCode)
        {
            _detailImportSlip.updateDetaiImportSlip(importSlipCode);
        }
    }
}
