using CefSharp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyOnlineDict
{
    public partial class FrmTranslateModal : Form
    {
        //string _word = string.Empty;
        //static FrmTranslateModal_DEtoAR _instance = new FrmTranslateModal_DEtoAR();
        public FrmMain frmMain;
        public FrmTranslateModal(FrmMain pFrmMain)
        {
            InitializeComponent();
            frmMain = pFrmMain;
            webbrsr.KeyboardHandler = new MyKeyboardHandlerModal(frmMain, this);
            webbrsr.MenuHandler = new MyCustomMenuHandlerModal(frmMain, this.webbrsr);
            Height = Screen.PrimaryScreen.WorkingArea.Height - 20;
            //InitializeChromium();
        }
        private void InitializeChromium()
        {
            //CefSharp.CefSettings settings = new CefSharp.CefSettings();
            //settings.CachePath = System.IO.Path.GetDirectoryName(Application.ExecutablePath) + @"\CEF";
            //CefSharp.Cef.Initialize(settings);

        }

        private void FrmTranslateModel_Load(object sender, EventArgs e)
        {
            
        }
        protected override bool ProcessDialogKey(Keys keyData)
        {
            //if (Form.ModifierKeys == Keys.None && keyData == Keys.Escape)
            //{
            //    this.Hide();
            //    return true;
            //}
            return base.ProcessDialogKey(keyData);
        }

        //public void TranslateENtoAR(string word)
        //{
        //    webbrsr.Navigate(new Uri("https://translate.google.com/#en/ar/" + word));
        //}
        public void Translate(MenuBrowser menuBrowser,string word)
        {
            //if (webbrsr.ca) MessageBox.Show("Disp");
            lblDictName.Text = menuBrowser.Name;
            this.Text = menuBrowser.Name;
            string newUrl = menuBrowser.Url.Replace("%WORD%", word);
            txtUrl.Text = newUrl;
            webbrsr.Load(new Uri(newUrl).AbsoluteUri);
        }
        //public static FrmTranslateModal_DEtoAR GetInstance()
        //{
        //    if (_instance == null) _instance = new FrmTranslateModal_DEtoAR();
        //    return _instance;
        //}

        private void FrmTranslateModel_FormClosing(object sender, FormClosingEventArgs e)
        {
            //this.Hide();
            //e.Cancel = true; // this cancels the close event.
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                Hide();
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {

            //webbrsr.Document.Body.Style = "zoom:300%;";
            //var w = (mshtml.IHTMLWindow2)webbrsr.Document.Window.DomWindow;
            //var s = (mshtml.IHTMLScreen2)w.screen;
            //int zoom = s.deviceXDPI * 100 / 96;
            //MessageBox.Show(zoom.ToString());
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        //public static void CloseAndClean()
        //{
        //    if (_instance != null)
        //        _instance.Close();
        //}
    }
}
