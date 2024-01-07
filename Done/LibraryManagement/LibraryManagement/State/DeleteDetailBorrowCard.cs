using LibraryManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace LibraryManagement.State
{
    public class DeleteDetailBorrowCard : DetailState
    {
        public string handle(string id = "", string phieu_id = "", int type = 0)
        {
            string msg = "";
            if (type == 0)
            {
                msg = $"Xóa chi tiết phiếu mượn {id} thành công!";
            }
            else if (type == 1)
            {
                msg = $"Bạn có muốn xóa chi tiết phiếu mượn {id} không?";
            }
            else if (type == 2)
            {
                msg = $"Nếu xóa chi tiết phiếu mượn {id} thì hệ thống sẽ xóa phiếu mượn {phieu_id}.";
            }

            return msg;
        }
    }
}
