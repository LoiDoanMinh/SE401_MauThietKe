using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.State
{
    public class CreateBorrowCardState : DetailState
    {
        public string handle(string id = "", string phieu_id = "", int type = 0)
        {
            string msg = "";
            if (type == 0)
            {
                msg = $"Tạo phiếu mượn {phieu_id} thành công!";
            }

            return msg;
        }
    }
}
