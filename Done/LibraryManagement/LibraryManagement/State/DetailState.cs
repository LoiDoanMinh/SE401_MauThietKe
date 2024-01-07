using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.State
{
    public interface DetailState
    {
        string handle(string id, string phieu_id, int type);
    }
}
