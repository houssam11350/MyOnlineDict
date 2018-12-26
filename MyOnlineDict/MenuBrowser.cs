using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyOnlineDict
{
    public class MenuBrowser
    {
        public int Command { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
        public string Shortcut { get; set; }
        public FrmTranslateModal FrmTranslateModal { get; set; }
    }
}
