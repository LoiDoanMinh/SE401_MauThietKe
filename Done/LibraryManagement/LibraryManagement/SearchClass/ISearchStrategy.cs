using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryManagement.Class;
namespace LibraryManagement.Class
{
    public interface ISearchStrategy
    {
        System.Data.DataTable fillter(System.Data.DataTable _sreachResult, string s1);

    }
}
