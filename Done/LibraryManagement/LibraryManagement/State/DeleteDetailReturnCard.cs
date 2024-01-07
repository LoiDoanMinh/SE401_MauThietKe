using LibraryManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace LibraryManagement.State
{
    public class DeleteDetailReturnCard : DetailState
    {
        public string handle(string id = "", string phieu_id = "", int type = 0)
        {
            string msg = "";
            if (type == 0)
            {
                msg = $"Xóa chi tiết phiếu trả {id} thành công!";
            }
            else if (type == 1)
            {
                msg = $"Bạn có muốn xóa chi tiết phiếu trả {id} không?";
            }
            else if(type == 2) 
            {
                msg = $"Nếu xóa chi tiết phiếu trả {id} thì hệ thống sẽ xóa phiếu trả {phieu_id}.\nBạn có muốn xóa chi tiết phiếu trả {id} không?";
            }
            else if (type == 3)
            {
                msg = $"Sách này đã được trả. Nếu xóa chi tiết phiếu mượn {id} thì hệ thống sẽ xóa thông tin phiếu trả đi kèm.";
            }

            return msg;
        }
    }
}
