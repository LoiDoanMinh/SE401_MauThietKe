using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.State
{
    public class CreateReturnCardState : DetailState
    {
        public string handle(string id = "", string phieu_id = "", int type = 0)
        {
            string msg = "";
            if (type == 0)
            {
                msg = $"Tạo phiếu trả {phieu_id} thành công!";
            }

            return msg;
        }
    }
}
