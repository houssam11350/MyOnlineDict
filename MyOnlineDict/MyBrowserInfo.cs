using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyOnlineDict
{
    public class MyBrowserInfo
    {
        public string Name { get; set; }
        public string Url { get; set; }
        public int ScrollDown { get; set; } = 0;
        public int ScrollRight { get; set; } = 0;
        //public int ScrollLeft { get; set; } = 0;
        public int Zoom { get; set; } = 100;
    }
}
