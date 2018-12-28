using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MyOnlineDict.Shell32;
using MyOnlineDict.Win32;
using System.Diagnostics;
using System.Text.RegularExpressions;
using CefSharp;
using mshtml;
using CefSharp.WinForms;
using System.Threading;
using System.IO;
using System.Net;
//using MyOnlineDict.Hook;

namespace MyOnlineDict
{
    public partial class FrmMain : Form
    {
        const ushort WordHistorySize = 30;
        string[] arrWordHistory = new string[WordHistorySize];
        int historyIndex = -1;
        int wordHistoryCount = 0;
        bool isWordFromHistory = false;
        IntPtr _ClipboardViewerNext;
        bool isFirstRun = true;
        public bool isCopyWithoutTranslate = false;
        public int last_command = 0;
        DateTime last_date_time = DateTime.MinValue;
        //internal ChromiumWebBrowser WebbrsrToCopyFrom;
        List<MyBrowserInfo> lstMyBrowserInfo = new List<MyBrowserInfo>();
        public List<MenuBrowser> lstMenuBrowser = new List<MenuBrowser>();
        List<CtrlBrowser> lstCtrlBrowser = new List<CtrlBrowser>();


        public FrmMain()
        {
            CefSharp.CefSettings settings = new CefSharp.CefSettings();
            settings.CachePath = Path.GetDirectoryName(Application.ExecutablePath) + @"\\cache";
            CefSharp.Cef.Initialize(settings);

            InitializeComponent();
            mainMenu.Renderer = new CutomToolStripMenuRenderer();
            tabCtrlMain.DrawMode = TabDrawMode.OwnerDrawFixed;
            //CefSharp.BrowserSettings st = new CefSharp.BrowserSettings();
            //st.ApplicationCache = CefSharp.CefState.Enabled;
            //webbrsrVerbformen.BrowserSettings=st;

            //CefSharp.RequestContextSettings requestContextSettings = new CefSharp.RequestContextSettings();
            //requestContextSettings.PersistSessionCookies = true;
            //requestContextSettings.PersistUserPreferences = true;
            //requestContextSettings.CachePath = "D:\\chro\\";
            //webbrsrVerbformen.RequestContext = new CefSharp.RequestContext(requestContextSettings);
        }

        private void ReloadDicts()
        {
            lstMyBrowserInfo.Clear();
            foreach (var mb in lstMenuBrowser)
            {
                if (mb.FrmTranslateModal != null)
                {
                    try { mb.FrmTranslateModal.webbrsr.Dispose(); } catch { }
                    try { mb.FrmTranslateModal.Dispose(); } catch { }
                    mb.FrmTranslateModal = null;
                }
            }
            lstMenuBrowser.Clear();

            int command = 29502;
            const string MY_SEPARATOR = "@@@@@@@@";
            string path = Path.GetDirectoryName(Application.ExecutablePath);
            var lines = File.ReadAllLines(Path.Combine(path, "mydicts.txt"));
            bool isInRightClickDict = false;
            string error = string.Empty;
            foreach (string line in lines)
            {
                if (string.IsNullOrEmpty(line)) continue;
                if (line.StartsWith("#")) continue;
                if (line.StartsWith("[right_click_dict]", StringComparison.CurrentCultureIgnoreCase))
                {
                    isInRightClickDict = true;
                    continue;
                }
                if (!line.Contains("%WORD%")) error = error + Environment.NewLine + "LINE:" + line + " conatins no %WORD%";
                string[] ar = line.Split(new string[] { MY_SEPARATOR }, StringSplitOptions.RemoveEmptyEntries);
                if (isInRightClickDict)
                {
                    MenuBrowser menuBrowser = new MenuBrowser();
                    menuBrowser.Command = command++;
                    menuBrowser.Url = ar[0];
                    if (ar.Length >= 2)
                        menuBrowser.Name = ar[1];
                    else
                    {
                        try
                        {
                            Uri uri = new Uri(menuBrowser.Url);
                            menuBrowser.Name = uri.Host;
                        }
                        catch
                        {
                        }
                    }

                    if (ar.Length >= 2 && ar[2].StartsWith("f", StringComparison.CurrentCultureIgnoreCase))
                        menuBrowser.Shortcut = ar[2].ToUpper();
                    lstMenuBrowser.Add(menuBrowser);


                }
                else
                {
                    MyBrowserInfo info = new MyBrowserInfo();
                    info.Url = ar[0];
                    if (ar.Length >= 2)
                        info.Name = ar[1];
                    else
                    {
                        try
                        {
                            Uri uri = new Uri(info.Url);
                            info.Name = uri.Host;
                        }
                        catch
                        {
                        }
                    }
                    for (int i = 2; i < ar.Length; i++)
                    {
                        string[] ar2 = ar[i].Split(new string[] { "=" }, StringSplitOptions.RemoveEmptyEntries);
                        if (ar2[0].Equals("scrolldown", StringComparison.CurrentCultureIgnoreCase))
                            info.ScrollDown = Convert.ToInt32(ar2[1]);
                        //else if (ar2[0].Equals("scrollleft", StringComparison.CurrentCultureIgnoreCase))
                        //    info.ScrollLeft = Convert.ToInt32(ar2[1]);
                        else if (ar2[0].Equals("scrollright", StringComparison.CurrentCultureIgnoreCase))
                            info.ScrollRight = Convert.ToInt32(ar2[1]);
                        else if (ar2[0].Equals("zoomlevel", StringComparison.CurrentCultureIgnoreCase))
                            info.Zoom = Convert.ToInt32(ar2[1]);
                        else throw new Exception("Error in line:" + line);
                    }
                    lstMyBrowserInfo.Add(info);
                }
            }
            this.SuspendLayout();
            pnlShortcuts.SuspendLayout();
            pnlShortcuts.Controls.Clear();
            MyLabel lblMyCopy = new MyLabel();
            lblMyCopy.AutoSize = true;
            lblMyCopy.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            lblMyCopy.Padding = new System.Windows.Forms.Padding(2);
            lblMyCopy.Text = "Only Copy = F2";
            lblMyCopy.MouseClick += LblMyCopy_MouseClick; ;
            lblMyCopy.Cursor = Cursors.Hand;

            pnlShortcuts.Controls.Add(lblMyCopy);

            foreach (MenuBrowser l_menuBrowser in lstMenuBrowser)
            {
                if (!string.IsNullOrEmpty(l_menuBrowser.Shortcut) && l_menuBrowser.Shortcut.StartsWith("f", StringComparison.CurrentCultureIgnoreCase))
                {
                    MyLabel lbl = new MyLabel();
                    lbl.AutoSize = true;
                    lbl.Text = l_menuBrowser.Name + " [" + l_menuBrowser.Shortcut + "]";
                    //mainMenu.Items.Add(lbl.Text);
                    lbl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
                    lbl.Padding = new System.Windows.Forms.Padding(2);
                    lbl.Margin = new Padding(1);
                    lbl.Tag = l_menuBrowser;
                    lbl.MouseClick += Lbl_MouseClick;
                    lbl.MouseDoubleClick += Lbl_MouseDoubleClick;
                    lbl.Cursor = Cursors.Hand;
                    pnlShortcuts.Controls.Add(lbl);
                }
            }
            pnlShortcuts.ResumeLayout();

            tabCtrlMain.SuspendLayout();
            foreach (var br in lstCtrlBrowser) { br.Dispose(); }
            lstCtrlBrowser.Clear();
            tabCtrlMain.TabPages.Clear();
            foreach (MyBrowserInfo myBrowserInfo in lstMyBrowserInfo)
            {
                TabPage tabPage = new TabPage(myBrowserInfo.Name);
                CtrlBrowser ctrlBrowser = new CtrlBrowser(myBrowserInfo);
                ctrlBrowser.Dock = DockStyle.Fill;
                //ctrlBrowser.myBrowserInfo = myBrowserInfo;
                ctrlBrowser.lstMenuBrowser = lstMenuBrowser;
                MyCustomMenuHandler myCustomMenuHandler = new MyCustomMenuHandler(this, ctrlBrowser.webBrowser, lstMenuBrowser);

                ctrlBrowser.myCustomMenuHandler = myCustomMenuHandler;
                ctrlBrowser.webBrowser.KeyboardHandler = new MyKeyboardHandler(this, ctrlBrowser);
                tabPage.Controls.Add(ctrlBrowser);
                tabCtrlMain.TabPages.Add(tabPage);
                lstCtrlBrowser.Add(ctrlBrowser);

            }
            tabCtrlMain.ResumeLayout();
            this.ResumeLayout();
            if (!string.IsNullOrEmpty(error)) Helper.ERRORMSG(error);
        }

        private void Lbl_MouseDoubleClick(object sender, MouseEventArgs e)
        {

        }

        private void LblMyCopy_MouseClick(object sender, MouseEventArgs e)
        {
            int index = tabCtrlMain.SelectedIndex;
            if (index < 0 && index >= lstCtrlBrowser.Count) return;

            CtrlBrowser ctrlBrowser = lstCtrlBrowser[index];
            if (ctrlBrowser.GetCanCopy())
            {
                this.last_command = ContextMenuCommand.CMD_MY_COPY;
                this.isCopyWithoutTranslate = true;
                ctrlBrowser.webBrowser.Copy();

            }
        }

        private void Lbl_MouseClick(object sender, MouseEventArgs e)
        {
            MyLabel lbl = (MyLabel)sender;
            int index = tabCtrlMain.SelectedIndex;
            if (index < 0 && index >= lstCtrlBrowser.Count) return;
            MenuBrowser menuBrowser = (MenuBrowser)lbl.Tag;
            CtrlBrowser ctrlBrowser = lstCtrlBrowser[index];
            if (!ctrlBrowser.GetIsLoadedForFirstTime()) return;
            int i = 0;
            while (!ctrlBrowser.GetCanCopy() && i < 400)
            {
                Thread.Sleep(10);
                i++;
            }
            if (ctrlBrowser.GetCanCopy())
            {
                this.last_command = menuBrowser.Command;
                this.isCopyWithoutTranslate = true;
                ctrlBrowser.webBrowser.Copy();

            }
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            // HookManager.KeyDown += HookManager_KeyDown;

            _ClipboardViewerNext = Win32.User32.SetClipboardViewer(this.Handle);
            //isLoaded = true;
            ActiveControl = txtWord;
            ReloadDicts();
        }
        private bool KeyIsDown(Keys key)
        {
            return (User32.GetAsyncKeyState(key) < 0);
        }
        /*bool _IsCTRL_C = false;
        string _MyClip;
        private void HookManager_KeyDown(object sender, KeyEventArgs e)
        {
            Debug.WriteLine((e.Modifiers | Keys.Control) + "=" + e.Modifiers + " " + e.KeyCode);
            if ((e.Modifiers | Keys.Control) > 0 && e.KeyCode == Keys.C)
            {
                if(_IsCTRL_C) MessageBox.Show(_MyClip);
                _IsCTRL_C = true;
                _MyClip = Clipboard.GetText(TextDataFormat.Text);


            }
            else
                _IsCTRL_C = false;
        }
        */
        protected override void WndProc(ref Message m)
        {
            // Debug.WriteLine("m={0}", m.ToString());
            switch ((Win32.Msgs)m.Msg)
            {
                // The WM_DRAWCLIPBOARD message is sent to the first window 
                // in the clipboard viewer chain when the content of the 
                // clipboard changes. This enables a clipboard viewer 
                // window to display the new content of the clipboard. 
                //msg=0x2a2 hwnd=0x70614 wparam=0x0 lparam=0x0 result=0x0: m={0}
                //case Msgs.WM_MY_MSG_1:

                //  break;
                //msg=0x319 hwnd=0x705ee wparam=0x13063a lparam=0xffffffff80010000 result=0x0: m={0}
                case Msgs.WM_MY_MSG_MOUSE_BUTTON_4_5:
                    // Debug.WriteLine("m={0}", m.ToString());
                    int index = tabCtrlMain.SelectedIndex;
                    ChromiumWebBrowser webbrsr = lstCtrlBrowser[index].webBrowser;
                    last_command = ContextMenuCommand.CMD_MY_COPY;
                    isCopyWithoutTranslate = true;
                    webbrsr.Copy();
                    break;
                case Win32.Msgs.WM_DRAWCLIPBOARD:
                    //lblTextCopied.Visible = true;
                    string txtFromclipboard = Clipboard.GetText();
                    txtFromclipboard = txtFromclipboard.TrimStart(
                        Convert.ToChar(8226) // bulltet
                        , '\t', ' ');
                    lblTextCopied.Text = txtFromclipboard;
                    if (last_date_time == DateTime.MinValue)
                        last_date_time = DateTime.Now;
                    else
                    {
                        double diff = (DateTime.Now - last_date_time).TotalMilliseconds;
                        last_date_time = DateTime.Now;
                        if (diff < 200)
                        {
                            Win32.User32.SendMessage(_ClipboardViewerNext, m.Msg, m.WParam, m.LParam);
                            return;
                        }
                    }

                    //MessageBox.Show(string.Format("WM_DRAWCLIPBOARD , msg={0} , hWind={1} ,lparam={2} , wparam={3} ", m.Msg, m.HWnd, m.LParam, m.WParam));
                    // Debug.WriteLine("WindowProc DRAWCLIPBOARD: " + m.Msg, "WndProc");
                    MenuBrowser lMenuBrowser = GetMenuBrowserForCommand(last_command);
                    if (isCopyWithoutTranslate && lMenuBrowser != null)
                    {
                        string tmp_word = txtFromclipboard;
                        if (lMenuBrowser.FrmTranslateModal == null)
                        {
                            lMenuBrowser.FrmTranslateModal = new FrmTranslateModal(this);
                            lMenuBrowser.FrmTranslateModal.frmMain = this;
                        }

                        lMenuBrowser.FrmTranslateModal.Translate(lMenuBrowser, tmp_word);
                        lMenuBrowser.FrmTranslateModal.Show(this);
                    }
                    else if (isCopyWithoutTranslate && last_command == ContextMenuCommand.CMD_MY_COPY)
                    {
                        //WebbrsrToCopyFrom.Copy();
                    }
                    else
                   if (chkClipboardWatch.Checked && Control.ModifierKeys != Keys.Shift)
                    {
                        txtWord.Text = txtFromclipboard;
                        goTranslate();
                    }
                    else
                    {
                        // Win32.User32.SendMessage(_ClipboardViewerNext, m.Msg, m.WParam, m.LParam);
                    }
                    Win32.User32.SendMessage(_ClipboardViewerNext, m.Msg, m.WParam, m.LParam);
                    last_command = 0;
                    isCopyWithoutTranslate = false;
                    break;
                //
                // The WM_CHANGECBCHAIN message is sent to the first window 
                // in the clipboard viewer chain when a window is being 
                // removed from the chain. 
                //
                case Win32.Msgs.WM_CHANGECBCHAIN:
                    // Debug.WriteLine("WM_CHANGECBCHAIN: lParam: " + m.LParam, "WndProc");

                    // When a clipboard viewer window receives the WM_CHANGECBCHAIN message, 
                    // it should call the SendMessage function to pass the message to the 
                    // next window in the chain, unless the next window is the window 
                    // being removed. In this case, the clipboard viewer should save 
                    // the handle specified by the lParam parameter as the next window in the chain. 

                    //
                    // wParam is the Handle to the window being removed from 
                    // the clipboard viewer chain 
                    // lParam is the Handle to the next window in the chain 
                    // following the window being removed. 
                    if (m.WParam == _ClipboardViewerNext)
                    {
                        //
                        // If wParam is the next clipboard viewer then it
                        // is being removed so update pointer to the next
                        // window in the clipboard chain
                        _ClipboardViewerNext = m.LParam;
                    }
                    else
                    {
                        Win32.User32.SendMessage(_ClipboardViewerNext, m.Msg, m.WParam, m.LParam);
                    }
                    break;
                default:
                    //
                    // Let the form process the messages that we are
                    // not interested in
                    base.WndProc(ref m);
                    break;
            }
        }

        private MenuBrowser GetMenuBrowserForCommand(int p_command)
        {
            foreach (MenuBrowser loop_MenuBrowser in lstMenuBrowser)
                if (loop_MenuBrowser.Command == p_command)
                    return loop_MenuBrowser;
            return null;
        }

        private void FrmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            //try { HookManager.KeyDown -= HookManager_KeyDown; }catch { }
            try
            {
                Win32.User32.ChangeClipboardChain(this.Handle, _ClipboardViewerNext);
            }
            catch { }

            e.Cancel = false;
            foreach (var l_ctrlBrowser in lstCtrlBrowser)
            {
                try
                {
                    l_ctrlBrowser.webBrowser.Dispose();
                }
                catch { }
            }
            foreach (var mb in lstMenuBrowser)
            {
                if (mb.FrmTranslateModal != null)
                {
                    try { mb.FrmTranslateModal.webbrsr.Dispose(); } catch { }
                    try { mb.FrmTranslateModal.Dispose(); } catch { }
                    mb.FrmTranslateModal = null;
                }
            }

            try
            {
                Cef.Shutdown();
            }
            catch { }
            try
            {
                Application.Exit();
            }
            catch { }
            try
            {
                Environment.Exit(0);
            }
            catch { }
        }
        private void btnTranslate_Click(object sender, EventArgs e)
        {
            isCopyWithoutTranslate = false;
            goTranslate();
        }

        private void goTranslate()
        {
            if (isFirstRun)
            {
                isFirstRun = false;
                txtWord.Clear();
                txtWord.SelectAll();
                txtWord.Focus();
                return;
            }
            string word = txtWord.Text;
            if (string.IsNullOrWhiteSpace(word) || string.IsNullOrEmpty(word))
                return;
            if (!isWordFromHistory)
            {
                AddWordToHistory(word);
                MakeNextPrevEnable();
            }
            if (this.WindowState == FormWindowState.Minimized) return;
            int index = tabCtrlMain.SelectedIndex;
            if (index >= lstCtrlBrowser.Count || index < 0) return;
            CtrlBrowser ctrlBrowser = lstCtrlBrowser[index];
            ctrlBrowser.GoTranslate(word);
            if (User32.GetForegroundWindow() != this.Handle)
                User32.MyFlashWindowEx(this.Handle);

        }

        private void AddWordToHistory(string word)
        {
            if (wordHistoryCount == WordHistorySize) // history is full
            {
                if (arrWordHistory[wordHistoryCount - 1] == word)
                {
                }
                else
                {
                    for (int i = 0; i < WordHistorySize - 1; i++)
                        arrWordHistory[i] = arrWordHistory[i + 1];
                    //wordHistoryCount--;
                    //historyIndex--;
                    arrWordHistory[wordHistoryCount - 1] = word;
                }
                historyIndex = wordHistoryCount - 1;
            }
            else
            {
                if (wordHistoryCount > 0 && arrWordHistory[wordHistoryCount - 1] == word)
                {
                    historyIndex = wordHistoryCount - 1;
                }
                else
                {
                    wordHistoryCount++;
                    historyIndex = wordHistoryCount - 1;
                    arrWordHistory[historyIndex] = word;
                }
            }
        }

        private void MakeNextPrevEnable()
        {
            if (wordHistoryCount == 0 || wordHistoryCount == 1)
            {
                tsPrevWord.Enabled = false;
                tsNextWord.Enabled = false;
            }
            else
            {
                if (historyIndex == -1 || historyIndex == 0)
                    tsPrevWord.Enabled = false;
                else
                    tsPrevWord.Enabled = true;

                if (historyIndex == wordHistoryCount - 1)
                    tsNextWord.Enabled = false;
                else
                    tsNextWord.Enabled = true;
            }
        }

        private void tabctrlBrowsers_SelectedIndexChanged(object sender, EventArgs e)
        {
            goTranslate();
        }
        private void RemoveWord(TextBox box)
        {
            string text = Regex.Replace(box.Text.Substring(0, box.SelectionStart), @"(^\W)?\w*\W*$", "");
            box.Text = text + box.Text.Substring(box.SelectionStart);
            box.SelectionStart = text.Length;
        }

        private void txtWord_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                isCopyWithoutTranslate = false;
                goTranslate();
            }
            TextBox box = (TextBox)sender;
            if (e.KeyData == (Keys.Back | Keys.Control))
            {
                if (!box.ReadOnly && box.SelectionLength == 0)
                {
                    RemoveWord(box);
                }
                e.SuppressKeyPress = true;
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtWord.Clear();
            txtWord.Focus();
            txtWord.SelectAll();
        }

        private void btnPrevWord_Click(object sender, EventArgs e)
        {
            if (wordHistoryCount == 0 || historyIndex <= 0)
                return;
            historyIndex--;
            txtWord.Text = arrWordHistory[historyIndex];
            MakeNextPrevEnable();
            isWordFromHistory = true;
            goTranslate();
            isWordFromHistory = false;
        }

        private void btnNextWord_Click(object sender, EventArgs e)
        {
            if (historyIndex <= wordHistoryCount - 1)
            {
                historyIndex++;
                txtWord.Text = arrWordHistory[historyIndex];
                MakeNextPrevEnable();
                isWordFromHistory = true;
                goTranslate();
                isWordFromHistory = false;
            }
        }

        private void tabCtrlMain_DrawItem(object sender, DrawItemEventArgs e)
        {
            TabPage page = tabCtrlMain.TabPages[e.Index];
            if (e.State == DrawItemState.Selected)
                e.Graphics.FillRectangle(new SolidBrush(Color.Yellow), e.Bounds);
            else
                e.Graphics.FillRectangle(new SolidBrush(page.BackColor), e.Bounds);

            Rectangle paddedBounds = e.Bounds;
            int yOffset = (e.State == DrawItemState.Selected) ? -2 : 1;
            //paddedBounds.Offset(1, yOffset);
            TextRenderer.DrawText(e.Graphics, page.Text, Font, paddedBounds, page.ForeColor);
        }

        private void FrmMain_Resize(object sender, EventArgs e)
        {
            foreach (CtrlBrowser ctrl in lstCtrlBrowser)
                ctrl.HandleToolStripLayout();
        }

        private void FrmMain_SizeChanged(object sender, EventArgs e)
        {
            foreach (CtrlBrowser ctrl in lstCtrlBrowser)
                ctrl.HandleToolStripLayout();
        }

        private void reloadDictionariesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ReloadDicts();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmAbout frm = new FrmAbout();
            frm.ShowInTaskbar = false;
            frm.ShowDialog(this);
        }

        private void tsCheckForUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                string currentVersion = "1.0.0.0";
                string url = "https://raw.githubusercontent.com/houssam11350/MyOnlineDict/master/currentVersion";
                WebClient client = new WebClient();
                string downloadString = client.DownloadString(url);
                string[] arr = downloadString.Split(new char[] { '.' });
                if (arr.Length != 4)
                    throw new Exception("Invalid reply from the server:" + downloadString);
                int[] int_arr = new int[] { int.Parse(arr[0]), int.Parse(arr[1]) ,
                                        int.Parse(arr[2]) , int.Parse(arr[3])};

                string[] curr = currentVersion.Split(new char[] { '.' });
                int[] curr_arr = new int[] { int.Parse(curr[0]), int.Parse(curr[1]) ,
                                        int.Parse(curr[2]) , int.Parse(curr[3])};

                bool isUpToDate = true;
                for (int i = curr_arr.Length - 1; i >= 0; i--)
                {
                    if (curr_arr[i] < int_arr[i])
                    {
                        Helper.OKMSG(string.Format(
                          "Your Version: {0}. {1} Server Version: {2} {1} Please download last version from: https://github.com/houssam11350/FileOrganizer",
                          currentVersion, Environment.NewLine, downloadString));
                        isUpToDate = false;
                        ProcessStartInfo sInfo = new ProcessStartInfo("https://github.com/houssam11350/MyOnlineDict");
                        Process.Start(sInfo);
                        break;
                    }
                }
                if (isUpToDate)
                    Helper.OKMSG(string.Format(
                         "Your Version: {0}. {1} Server Version: {2} {1} You are uptodate.",
                         currentVersion, Environment.NewLine, downloadString));
            }
            catch
            {
                Helper.ERRORMSG("An error occured during checking updates..");
            }
        }
        public void EmptyFolder(string pathName)
        {
            //bool errors = false;
            DirectoryInfo dir = new DirectoryInfo(pathName);
            foreach (FileInfo fi in dir.EnumerateFiles())
            {
                try
                {
                    fi.IsReadOnly = false;
                    fi.Delete();

                    //Wait for the item to disapear (avoid 'dir not empty' error).
                    while (fi.Exists)
                    {
                        Thread.Sleep(10);
                        fi.Refresh();
                    }
                }
                catch
                {
                    // Debug.WriteLine(e.Message);
                    //errors = true;
                }
            }

            foreach (DirectoryInfo di in dir.EnumerateDirectories())
            {
                try
                {
                    EmptyFolder(di.FullName);
                    di.Delete();

                    //Wait for the item to disapear (avoid 'dir not empty' error).
                    while (di.Exists)
                    {
                        Thread.Sleep(10);
                        di.Refresh();
                    }
                }
                catch
                {
                    //Debug.WriteLine(e.Message);
                    //errors = true;
                }
            }

            // return !errors;
        }
        private void tsDeleteCache_Click(object sender, EventArgs e)
        {
            EmptyFolder(Path.GetDirectoryName(Application.ExecutablePath) + @"\cache\");
            Helper.OKMSG("Done !!!");

        }

        private void tsOpenDictFile_Click(object sender, EventArgs e)
        {
            string filePath = Path.GetDirectoryName(Application.ExecutablePath) + @"\mydicts.txt";
            try
            {
                Process.Start(filePath);
            }
            catch
            {
                Helper.ERRORMSG("Cannot open :" + Environment.NewLine + filePath);

            }
        }
    }
}
