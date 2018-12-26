using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyOnlineDict
{
    public class MyLabel : System.Windows.Forms.Label
    {
        private const int WM_LBUTTONDBLCLK = 0x203;

        protected override void WndProc(ref Message m)
        {
            if (m.Msg == WM_LBUTTONDBLCLK)
            {
                
            }
            else
            {
                base.WndProc(ref m);
            }
        }
    }
}
