using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryManagement.Class;
namespace LibraryManagement.Class
{
    public class BookFinding
    {
        private System.Data.DataTable _searchResult;
        private ISearchStrategy _searchStrategy;
        public void SetSearchStrategy(ISearchStrategy value)
        {
            _searchStrategy = value;
        }
        public System.Data.DataTable getSearchResult()
        {
            return _searchResult;
        }
        public void setSearchResult(System.Data.DataTable value)
        {
            _searchResult = value;
        }
        public BookFinding()
        {

        }
        public BookFinding(ISearchStrategy searchStrategy)
        {
            _searchStrategy = searchStrategy;
        }
        public System.Data.DataTable GetSearchStrategyResult(string s1)
        {
            return _searchStrategy.fillter(_searchResult, s1);
        }
    }
}
