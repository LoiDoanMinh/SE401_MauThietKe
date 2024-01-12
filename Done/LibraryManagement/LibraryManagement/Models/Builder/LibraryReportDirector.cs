using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Models.Builder
{
    public class LibraryReportDirector
    {
        private LibraryReportBuilder builder;

        public LibraryReportDirector(LibraryReportBuilder builder)
        {
            this.builder = builder;
        }

        public void BuildReport(string header, string fileName, string sheetName)
        {
            this.builder.AddHeader(header);
            this.builder.AddFileName(fileName);
            this.builder.AddSheetName(sheetName);
        }
    }

}
