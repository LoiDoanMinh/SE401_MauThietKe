using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.State
{
    public class StateContext
    {
        private DetailState state;

        public void setState(DetailState state)
        {
            this.state = state;
        }

        public string applyState(string id = "", string phieu_id = "", int type = 0)
        {
            return this.state.handle(id, phieu_id, type);
        }
    }
}
