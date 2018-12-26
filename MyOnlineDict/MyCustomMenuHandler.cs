using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CefSharp;
using CefSharp.WinForms;
using System.Windows.Forms;
using System.Threading;

namespace MyOnlineDict
{
    public class MyCustomMenuHandler : IContextMenuHandler
    {
        readonly ChromiumWebBrowser _browser;
        readonly FrmMain _frmMain;
        readonly List<MenuBrowser> _lstMenuBrowser;
        //int _last_command = 0;
        
        public MyCustomMenuHandler(FrmMain frmMain, ChromiumWebBrowser browser , List<MenuBrowser> lstMenuBrowser)
        {
            _frmMain = frmMain;
            _browser = browser;
            _lstMenuBrowser = lstMenuBrowser;
            _browser.MenuHandler = this;

        }
        public void OnBeforeContextMenu(IWebBrowser browserControl, IBrowser browser, IFrame frame, IContextMenuParams parameters, IMenuModel model)
        {
            //_last_command = 0;
            // Remove any existent option using the Clear method of the model
            //model.Clear();
            //model.AddItem(CefMenuCommand.Back, "Back");
            //model.AddItem(CefMenuCommand.Forward, "Forward");
            //model.AddItem(CefMenuCommand.Print, "Print...");
            //model.AddItem(CefMenuCommand.ViewSource, "View Page Source");
            model.Remove(CefMenuCommand.Copy);
            // You can add a separator in case that there are more items on the list
            if (model.Count > 0)
            {
                model.AddSeparator();
            }

            model.AddItem((CefMenuCommand)ContextMenuCommand.CMD_COPY, "Copy");
            model.AddSeparator();
            // Add a new item to the list using the AddItem method of the model
            model.AddItem((CefMenuCommand)ContextMenuCommand.CMD_MY_COPY, "Only Copy");
            // Add a separator
            model.AddSeparator();
            foreach (MenuBrowser menuBrowser in _lstMenuBrowser)
            {
                string nname;
                if (string.IsNullOrEmpty(menuBrowser.Shortcut))
                    nname = menuBrowser.Name;
                else nname = menuBrowser.Name + "  [" + menuBrowser.Shortcut + "]";
                model.AddItem((CefMenuCommand)menuBrowser.Command, nname);
                model.AddSeparator();
            }
            //model.AddItem((CefMenuCommand)ContextMenuCommand.CMD_TRANSLATE_EN_TO_AR, "Translate EN-> AR");
            //model.AddSeparator();
            //model.AddItem((CefMenuCommand)ContextMenuCommand.CMD_TRANSLATE_DE_TO_AR, "Translate DE-> AR");

        }

        public bool OnContextMenuCommand(IWebBrowser browserControl, IBrowser browser, IFrame frame, IContextMenuParams parameters, CefMenuCommand commandId, CefEventFlags eventFlags)
        {
            if (commandId == CefMenuCommand.Back)
            {
                if (browser.CanGoBack)
                    browser.GoBack();
                return true;
            }
            else if (commandId == CefMenuCommand.Forward)
            {
                if (browser.CanGoForward)
                    browser.GoForward();
                return true;
            }
            else if (commandId == CefMenuCommand.Print)
            {
                browser.Print();
                return true;
            }
            else if (commandId == CefMenuCommand.ViewSource)
            {
                browserControl.ViewSource();
                return true;
            }
            else if (commandId == (CefMenuCommand)ContextMenuCommand.CMD_MY_COPY) // mycopy
            {
                _frmMain.last_command = ContextMenuCommand.CMD_MY_COPY;
                _frmMain.isCopyWithoutTranslate = true;
                string oldClipboard = Clipboard.GetText();
                //browserControl.Copy();
                //Application.DoEvents();
                //_frmMain.isCopyWithoutTranslate = true;
                //frame.Copy();
                short i = 0;
                while(i <= 8)
                {
                    frame.Copy();
                    browserControl.ExecuteScriptAsync("document.execCommand(\"copy\");");
                    string tmpClipboard = Clipboard.GetText();
                    if (tmpClipboard != oldClipboard)
                        break;
                    Thread.Sleep(1);
                    i++;                    
                }
                
                return true;
            }

            else if (commandId == (CefMenuCommand)ContextMenuCommand.CMD_COPY) //copy
            {
                _frmMain.last_command = ContextMenuCommand.CMD_COPY;
                _frmMain.isCopyWithoutTranslate = false;
                //_browser.Copy();
                frame.Copy();
                //_frmMain.isCopyWithoutTranslate = false;
                return true;
            }else
            {
                foreach(MenuBrowser l_menuBrowser in _lstMenuBrowser)
                {
                    if((CefMenuCommand)l_menuBrowser.Command == commandId)
                    {
                        _frmMain.last_command = l_menuBrowser.Command;
                        _frmMain.isCopyWithoutTranslate = true;
                        _browser.Copy();
                        return true;
                    }
                }
            }

            // Return false should ignore the selected option of the user !
            //return false;
            return true;
        }

        public void OnContextMenuDismissed(IWebBrowser browserControl, IBrowser browser, IFrame frame)
        {
            
        }

        public bool RunContextMenu(IWebBrowser browserControl, IBrowser browser, IFrame frame, IContextMenuParams parameters, IMenuModel model, IRunContextMenuCallback callback)
        {
            return false;
        }
    }
}
