using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CefSharp;
using CefSharp.WinForms.Internals;
using System.Globalization;

namespace MyOnlineDict
{
    public partial class CtrlBrowser : UserControl
    {
        public MyBrowserInfo myBrowserInfo;
        public List<MenuBrowser> lstMenuBrowser;
        public MyCustomMenuHandler myCustomMenuHandler;
        public MyKeyboardHandler myKeyboardHandler;
        string word = string.Empty;
        bool _IsZoomSet = false;
        bool _IsLoading = false;
        bool _CanCopy = false;
        bool _IsLoadedForFirstTime = false;
        public CtrlBrowser(MyBrowserInfo pMyBrowserInfo)
        {
            InitializeComponent();
            myBrowserInfo = pMyBrowserInfo;
            //myCustomMenuHandler = pMyCustomMenuHandler;
            webBrowser.MenuHandler = myCustomMenuHandler;
            //webBrowser.Tag = 50;
            //webBrowser.SetZoomLevel(myBrowserInfo.Zoom / 100.0);
            webBrowser.Tag = pMyBrowserInfo;
            tsZoom.Text = myBrowserInfo.Zoom.ToString(CultureInfo.CurrentCulture) + "%";
        }
        public bool GetCanCopy() { return _CanCopy; }
        public bool GetIsLoadedForFirstTime() { return _IsLoadedForFirstTime; }
        public void GoTranslate(string p_word)
        {
            if (!word.Equals(p_word, StringComparison.CurrentCultureIgnoreCase))
            {
                word = p_word;
                string newURL = myBrowserInfo.Url.Replace("%WORD%", word);
                string absUri = new Uri(newURL).AbsoluteUri;
                urlTextBox.Text = absUri;
                webBrowser.Load(absUri);
            }

        }
        private void webBrowser_LoadingStateChanged(object sender, CefSharp.LoadingStateChangedEventArgs e)
        {
            SetCanGoBack(e.CanGoBack);
            SetCanGoForward(e.CanGoForward);

            this.InvokeOnUiThreadIfRequired(() => SetIsLoading(e.IsLoading));
            _CanCopy = !e.IsLoading;
            if (!e.IsLoading)
            {
                _IsLoading = false;
                if (!_IsLoadedForFirstTime) _IsLoadedForFirstTime = true;
                if (myBrowserInfo.ScrollDown != 0)
                    webBrowser.ExecuteScriptAsync("window.scrollTo(0," + myBrowserInfo.ScrollDown + " );");
                if (myBrowserInfo.ScrollRight != 0)
                    webBrowser.ExecuteScriptAsync("window.scrollTo("+ myBrowserInfo.ScrollRight + " ,0);");


                if (!_IsZoomSet)
                {
                    tsZoom.Text = myBrowserInfo.Zoom.ToString(CultureInfo.CurrentCulture) + "%";
                    webBrowser.SetZoomLevel((Convert.ToDouble(myBrowserInfo.Zoom) - 100) / 25.0);
                    _IsZoomSet = true;
                }

            }
        }
        private void SetCanGoBack(bool canGoBack)
        {
            this.InvokeOnUiThreadIfRequired(() => backButton.Enabled = canGoBack);
        }

        private void SetCanGoForward(bool canGoForward)
        {
            this.InvokeOnUiThreadIfRequired(() => forwardButton.Enabled = canGoForward);
        }
        private void SetIsLoading(bool isLoading)
        {
            _IsLoading = isLoading;
            goButton.Text = isLoading ?
                "Stop" :
                "Go";
            goButton.Image = isLoading ?
                Properties.Resources.nav_plain_red :
                Properties.Resources.nav_plain_green;

            HandleToolStripLayout();
        }
        public void HandleToolStripLayout()
        {
            toolStrip1.Refresh();
            toolStrip1.SuspendLayout();
            var width = toolStrip1.Width;
            foreach (ToolStripItem item in toolStrip1.Items)
            {
                if (item != urlTextBox)
                {
                    width -= item.Width - item.Margin.Horizontal;
                }
            }
            urlTextBox.Width = Math.Max(0, width - urlTextBox.Margin.Horizontal - 20);
            toolStrip1.ResumeLayout(true);
            toolStrip1.Refresh();


        }
        private void BackButtonClick(object sender, EventArgs e)
        {
            webBrowser.Back();
        }

        private void ForwardButtonClick(object sender, EventArgs e)
        {
            webBrowser.Forward();
        }
        private void LoadUrl(string url)
        {
            if (!string.IsNullOrEmpty(url) &&  Uri.IsWellFormedUriString(url, UriKind.RelativeOrAbsolute))
            {
                webBrowser.Load(url);
            }
        }

        private void GoButtonClick(object sender, EventArgs e)
        {
            int i = 0;
            if (_IsLoading) webBrowser.Stop();
            while (i <50 && _IsLoading == true)
            {
                System.Threading.Thread.Sleep(10);
                i++;
            }
            LoadUrl(urlTextBox.Text);
        }
        private void webBrowser_IsBrowserInitializedChanged(object sender, IsBrowserInitializedChangedEventArgs e)
        {

        }

        private void webBrowser_AddressChanged(object sender, AddressChangedEventArgs e)
        {
            this.InvokeOnUiThreadIfRequired(() => urlTextBox.Text = e.Address);
        }
        public void tsZoomMinus_Click(object sender, EventArgs e)
        {
            myBrowserInfo.Zoom -= 5;
            if (myBrowserInfo.Zoom < -80) myBrowserInfo.Zoom = -80;
            tsZoom.Text = myBrowserInfo.Zoom.ToString(CultureInfo.CurrentCulture) + "%";
            webBrowser.SetZoomLevel((Convert.ToDouble(myBrowserInfo.Zoom) - 100) / 25.0);
            

        }

        public void tsZoomPlus_Click(object sender, EventArgs e)
        {
            myBrowserInfo.Zoom += 5;
            if (myBrowserInfo.Zoom > 300) myBrowserInfo.Zoom = 300;
            tsZoom.Text = myBrowserInfo.Zoom.ToString(CultureInfo.CurrentCulture) + "%";
            webBrowser.SetZoomLevel((Convert.ToDouble(myBrowserInfo.Zoom) - 100) / 25.0);

        }

        private void toolStrip1_Resize(object sender, EventArgs e)
        {
            HandleToolStripLayout();
        }
    }
}
