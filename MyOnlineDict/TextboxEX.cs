using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyOnlineDict
{
    class TextBoxEx : TextBox
    {
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == (Keys.Control | Keys.Back))
            {
                //SendKeys.Send("^+{LEFT}{BACKSPACE}");
                //return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
    }
}
