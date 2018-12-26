using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CefSharp;

namespace MyOnlineDict
{
    public class MyKeyboardHandlerModal : IKeyboardHandler
    {
        private readonly Form _frmParent;
        private readonly FrmMain _frmMain;
        public MyKeyboardHandlerModal(FrmMain frmMain , Form frmParent)
        {
            _frmMain = frmMain;
            _frmParent = frmParent;
        }

        bool IKeyboardHandler.OnKeyEvent(IWebBrowser browserControl, IBrowser browser, KeyType type, int windowsKeyCode, int nativeKeyCode, CefEventFlags modifiers, bool isSystemKey)
        {
            return false;
        }

        bool IKeyboardHandler.OnPreKeyEvent(IWebBrowser browserControl, IBrowser browser, KeyType type, int windowsKeyCode, int nativeKeyCode, CefEventFlags modifiers, bool isSystemKey, ref bool isKeyboardShortcut)
        {
            if (type != KeyType.Char && windowsKeyCode == (int)Keys.Escape)
            {
                //try
                {
                    if (_frmParent != null)
                    {
                        _frmParent.BeginInvoke((MethodInvoker)delegate { _frmParent.Hide(); });
                    }
                }
                //catch { }
                return false;
            }
            else if (type != KeyType.Char && windowsKeyCode == (int)Keys.F2)
            {
                _frmMain.last_command = ContextMenuCommand.CMD_MY_COPY;
                _frmMain.isCopyWithoutTranslate = true;
                browserControl.Copy();
                return true;
            }
                return false;
        }
    }
}
