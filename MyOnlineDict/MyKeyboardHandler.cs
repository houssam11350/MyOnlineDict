using CefSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Windows;
using System.Windows.Input;
using System.Windows.Forms;


namespace MyOnlineDict
{
    public class MyKeyboardHandler : IKeyboardHandler
    {
        private readonly FrmMain _frmMain;
        private readonly CtrlBrowser _ctrlBrowser;
        //private readonly List<MenuBrowser> _lstMenuBrowser;

        public MyKeyboardHandler(FrmMain frmMain, CtrlBrowser ctrlBrowser)
        {
            _frmMain = frmMain;
            _ctrlBrowser = ctrlBrowser;
        }

        //bool OnKeyEventww(IWebBrowser browser, KeyType type, int code, int modifiers, bool isSystemKey,
        //                       bool isAfterJavaScript)
        //{
        //    //var routedEvent = UIElement.KeyDownEvent;
        //    switch (type)
        //    {
        //        case KeyType.RawKeyDown:
        //        case KeyType.KeyDown:
        //            //routedEvent = isAfterJavaScript ? Keyboard.KeyDownEvent : Keyboard.PreviewKeyDownEvent;
        //            break;
        //        case KeyType.KeyUp:
        //            //routedEvent = isAfterJavaScript ? Keyboard.KeyUpEvent : Keyboard.PreviewKeyUpEvent;
        //            break;
        //        case KeyType.Char:
        //            // perhaps TextInputEvent ?
        //            break;
        //        default:
        //            /*Debug.Fail*/
        //            Trace.TraceWarning("Unsupported key event type: " + type);
        //            return false;
        //    }

        //    //if (type == KeyType.KeyUp)
        //    //host.Dispatcher.InvokeAsync(CommandManager.InvalidateRequerySuggested,
        //    //                            DispatcherPriority.ApplicationIdle);

        //    //return host.Dispatcher.Invoke(() =>
        //    //{
        //    //    var kb = Keyboard.PrimaryDevice;
        //    //    var ps = PresentationSource.FromDependencyObject(host);
        //    //    var ts = 0;
        //    //    var key = KeyInterop.KeyFromVirtualKey(code);

        //    //    var e = new KeyEventArgs(kb, ps, ts, key);
        //    //    e.RoutedEvent = routedEvent;

        //    //    Debug.WriteLine("Raising {0} {1}+{{{2}}}", routedEvent, key, Keyboard.Modifiers);
        //    //    host.RaiseEvent(e);

        //    //    return e.Handled;
        //    //});
        //    return true;
        //}

        bool IKeyboardHandler.OnKeyEvent(IWebBrowser browserControl, IBrowser browser, KeyType type, int windowsKeyCode, int nativeKeyCode, CefEventFlags modifiers, bool isSystemKey)
        {
            return false;
        }

        bool IKeyboardHandler.OnPreKeyEvent(IWebBrowser browserControl, IBrowser browser, KeyType type, int windowsKeyCode, int nativeKeyCode, CefEventFlags modifiers, bool isSystemKey, ref bool isKeyboardShortcut)
        {
            //    browserControl.Copy();
            /* double change = 0.1;
                Task<double> task = browser.GetZoomLevelAsync();
                task.ContinueWith(previous =>
                {
                    if (previous.IsCompleted)
                    {
                        double currentLevel = previous.Result;
                        browser.SetZoomLevel(currentLevel + change);
                    }
                    else
                    {
                        throw new InvalidOperationException("Unexpected failure of calling CEF->GetZoomLevelAsync", previous.Exception);
                    }
                }, TaskContinuationOptions.ExecuteSynchronously);
                return true;*/

            //Debug.WriteLine("KeyType= {0} ,windowsKeyCode = {1} , modifiers={2}", type, windowsKeyCode, modifiers);
            if (modifiers.HasFlag(CefEventFlags.ControlDown) && windowsKeyCode == (int)Keys.Add)
            {
                _ctrlBrowser.tsZoomPlus_Click(this, EventArgs.Empty);
                return true;

            }
            if (modifiers.HasFlag(CefEventFlags.ControlDown) && windowsKeyCode == (int)Keys.Subtract)
            {
                _ctrlBrowser.tsZoomMinus_Click(this, EventArgs.Empty);
                return true;
            }
            if (modifiers == CefEventFlags.ControlDown && windowsKeyCode == (int)Keys.C)
            {
                _frmMain.last_command = ContextMenuCommand.CMD_COPY;
                _frmMain.isCopyWithoutTranslate = false;
                browserControl.Copy();
                return true;
            }
            else if (windowsKeyCode == (int)Keys.F2 && type != KeyType.Char)
            {
                _frmMain.last_command = ContextMenuCommand.CMD_MY_COPY;
                _frmMain.isCopyWithoutTranslate = true;
                browserControl.Copy();
                return true;
            }
            else
            {
                if (type != KeyType.Char)
                {
                    string kkey = string.Empty;
                    if (windowsKeyCode == (int)Keys.F1) kkey = "f1";
                    //else if (windowsKeyCode == (int)Keys.F2) kkey = "f2";
                    else if (windowsKeyCode == (int)Keys.F3) kkey = "f3";
                    else if (windowsKeyCode == (int)Keys.F4) kkey = "f4";
                    else if (windowsKeyCode == (int)Keys.F5) kkey = "f5";
                    else if (windowsKeyCode == (int)Keys.F6) kkey = "f6";
                    else if (windowsKeyCode == (int)Keys.F7) kkey = "f7";
                    else if (windowsKeyCode == (int)Keys.F8) kkey = "f8";
                    else if (windowsKeyCode == (int)Keys.F9) kkey = "f9";
                    else if (windowsKeyCode == (int)Keys.F10) kkey = "f10";
                    else if (windowsKeyCode == (int)Keys.F11) kkey = "f11";
                    else if (windowsKeyCode == (int)Keys.F12) kkey = "f12";
                    MenuBrowser mb = GetMenuBrowserForShortcut(kkey);
                    if (mb != null)
                    {
                        _frmMain.last_command = mb.Command;
                        _frmMain.isCopyWithoutTranslate = true;
                        browserControl.Copy();
                        return true;
                    }
                }

            }
            isKeyboardShortcut = false;
            //true: Event is handeld
            return false;
        }
        private MenuBrowser GetMenuBrowserForShortcut(string key)
        {
            foreach (MenuBrowser mb in _frmMain.lstMenuBrowser)
                if (key.Equals(mb.Shortcut, StringComparison.CurrentCultureIgnoreCase))
                    return mb;
            return null;
        }
    }
}
