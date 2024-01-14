using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Models.Prototype_Decorator
{
    interface IBookVolumePrototype
    {
        IBookVolumePrototype Clone();
        void Add(Book book, DetailImportSlip detailSlip);
    }
}
