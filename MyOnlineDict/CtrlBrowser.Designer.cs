namespace MyOnlineDict
{
    partial class CtrlBrowser
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.webBrowser = new CefSharp.WinForms.ChromiumWebBrowser();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.backButton = new System.Windows.Forms.ToolStripButton();
            this.forwardButton = new System.Windows.Forms.ToolStripButton();
            this.urlTextBox = new System.Windows.Forms.ToolStripTextBox();
            this.tsZoomPlus = new System.Windows.Forms.ToolStripButton();
            this.tsZoom = new System.Windows.Forms.ToolStripLabel();
            this.tsZoomMinus = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.goButton = new System.Windows.Forms.ToolStripButton();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // webBrowser
            // 
            this.webBrowser.Dock = System.Windows.Forms.DockStyle.Fill;
            this.webBrowser.Location = new System.Drawing.Point(0, 25);
            this.webBrowser.Name = "webBrowser";
            this.webBrowser.Size = new System.Drawing.Size(857, 295);
            this.webBrowser.TabIndex = 0;
            this.webBrowser.UseParentFormMessageInterceptor = true;
            this.webBrowser.LoadingStateChanged += new System.EventHandler<CefSharp.LoadingStateChangedEventArgs>(this.webBrowser_LoadingStateChanged);
            this.webBrowser.AddressChanged += new System.EventHandler<CefSharp.AddressChangedEventArgs>(this.webBrowser_AddressChanged);
            this.webBrowser.IsBrowserInitializedChanged += new System.EventHandler<CefSharp.IsBrowserInitializedChangedEventArgs>(this.webBrowser_IsBrowserInitializedChanged);
            // 
            // toolStrip1
            // 
            this.toolStrip1.AllowMerge = false;
            this.toolStrip1.CanOverflow = false;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.backButton,
            this.forwardButton,
            this.urlTextBox,
            this.tsZoomPlus,
            this.tsZoom,
            this.tsZoomMinus,
            this.toolStripSeparator1,
            this.goButton});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Padding = new System.Windows.Forms.Padding(0);
            this.toolStrip1.Size = new System.Drawing.Size(857, 25);
            this.toolStrip1.Stretch = true;
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Resize += new System.EventHandler(this.toolStrip1_Resize);
            // 
            // backButton
            // 
            this.backButton.Enabled = false;
            this.backButton.Image = global::MyOnlineDict.Properties.Resources.nav_left_green;
            this.backButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.backButton.Name = "backButton";
            this.backButton.Size = new System.Drawing.Size(52, 22);
            this.backButton.Text = "Back";
            this.backButton.Click += new System.EventHandler(this.BackButtonClick);
            // 
            // forwardButton
            // 
            this.forwardButton.Enabled = false;
            this.forwardButton.Image = global::MyOnlineDict.Properties.Resources.nav_right_green;
            this.forwardButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.forwardButton.Name = "forwardButton";
            this.forwardButton.Size = new System.Drawing.Size(70, 22);
            this.forwardButton.Text = "Forward";
            this.forwardButton.Click += new System.EventHandler(this.ForwardButtonClick);
            // 
            // urlTextBox
            // 
            this.urlTextBox.AutoSize = false;
            this.urlTextBox.Name = "urlTextBox";
            this.urlTextBox.Size = new System.Drawing.Size(500, 25);
            // 
            // tsZoomPlus
            // 
            this.tsZoomPlus.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.tsZoomPlus.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsZoomPlus.Image = global::MyOnlineDict.Properties.Resources.zoonOut;
            this.tsZoomPlus.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsZoomPlus.Name = "tsZoomPlus";
            this.tsZoomPlus.Size = new System.Drawing.Size(23, 22);
            this.tsZoomPlus.Text = "Zoom In";
            this.tsZoomPlus.Click += new System.EventHandler(this.tsZoomPlus_Click);
            // 
            // tsZoom
            // 
            this.tsZoom.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.tsZoom.Name = "tsZoom";
            this.tsZoom.Size = new System.Drawing.Size(35, 22);
            this.tsZoom.Text = "100%";
            // 
            // tsZoomMinus
            // 
            this.tsZoomMinus.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.tsZoomMinus.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsZoomMinus.Image = global::MyOnlineDict.Properties.Resources.ZoomIn;
            this.tsZoomMinus.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsZoomMinus.Name = "tsZoomMinus";
            this.tsZoomMinus.Size = new System.Drawing.Size(23, 22);
            this.tsZoomMinus.Text = "Zoom Out";
            this.tsZoomMinus.Click += new System.EventHandler(this.tsZoomMinus_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // goButton
            // 
            this.goButton.Image = global::MyOnlineDict.Properties.Resources.nav_plain_green;
            this.goButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.goButton.Name = "goButton";
            this.goButton.Size = new System.Drawing.Size(42, 22);
            this.goButton.Text = "Go";
            this.goButton.Click += new System.EventHandler(this.GoButtonClick);
            // 
            // CtrlBrowser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.webBrowser);
            this.Controls.Add(this.toolStrip1);
            this.Name = "CtrlBrowser";
            this.Size = new System.Drawing.Size(857, 320);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        public CefSharp.WinForms.ChromiumWebBrowser webBrowser;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton backButton;
        private System.Windows.Forms.ToolStripButton forwardButton;
        private System.Windows.Forms.ToolStripTextBox urlTextBox;
        private System.Windows.Forms.ToolStripButton goButton;
        private System.Windows.Forms.ToolStripButton tsZoomMinus;
        private System.Windows.Forms.ToolStripLabel tsZoom;
        private System.Windows.Forms.ToolStripButton tsZoomPlus;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
    }
}
