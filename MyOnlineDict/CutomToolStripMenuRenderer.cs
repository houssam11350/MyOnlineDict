using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyOnlineDict
{
    public class CutomToolStripMenuRenderer : ToolStripProfessionalRenderer
    {
        protected override void OnRenderMenuItemBackground(ToolStripItemRenderEventArgs e)
        {
            if (e.Item.Enabled)
                base.OnRenderMenuItemBackground(e);
            else
            {
                Rectangle rc = new Rectangle(Point.Empty, e.Item.Size);
                //Color colorItem = SystemColors.ControlDark;
                //using (SolidBrush brush = new SolidBrush(colorItem))
                e.Graphics.FillRectangle(SystemBrushes.ControlDark, rc);
                //e.Graphics.DrawString("S", e.Item.Font, SystemBrushes.ControlLight, rc);
            }

        }

        protected override void OnRenderButtonBackground(ToolStripItemRenderEventArgs e)
        {
            if (e.Item.Enabled)
                base.OnRenderMenuItemBackground(e);

        }
    }
}
