namespace MyOnlineDict
{
    partial class FrmMain
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMain));
            this.pnlTop = new System.Windows.Forms.Panel();
            this.pnlShortcuts = new System.Windows.Forms.FlowLayoutPanel();
            this.lblTextCopied = new System.Windows.Forms.Label();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnTranslate = new System.Windows.Forms.Button();
            this.txtWord = new MyOnlineDict.TextBoxEx();
            this.label1 = new System.Windows.Forms.Label();
            this.chkClipboardWatch = new System.Windows.Forms.CheckBox();
            this.pnlFill = new System.Windows.Forms.Panel();
            this.tabCtrlMain = new System.Windows.Forms.TabControl();
            this.mainMenu = new System.Windows.Forms.MenuStrip();
            this.dictToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsOpenDictFile = new System.Windows.Forms.ToolStripMenuItem();
            this.reloadDictionariesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsDeleteCache = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.tsCheckForUpdate = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripTextBox1 = new System.Windows.Forms.ToolStripTextBox();
            this.tsPrevWord = new System.Windows.Forms.ToolStripMenuItem();
            this.tsNextWord = new System.Windows.Forms.ToolStripMenuItem();
            this.pnlTop.SuspendLayout();
            this.pnlFill.SuspendLayout();
            this.mainMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlTop
            // 
            this.pnlTop.Controls.Add(this.pnlShortcuts);
            this.pnlTop.Controls.Add(this.lblTextCopied);
            this.pnlTop.Controls.Add(this.btnClear);
            this.pnlTop.Controls.Add(this.btnTranslate);
            this.pnlTop.Controls.Add(this.txtWord);
            this.pnlTop.Controls.Add(this.label1);
            this.pnlTop.Controls.Add(this.chkClipboardWatch);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Location = new System.Drawing.Point(0, 24);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Size = new System.Drawing.Size(826, 78);
            this.pnlTop.TabIndex = 0;
            // 
            // pnlShortcuts
            // 
            this.pnlShortcuts.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlShortcuts.Location = new System.Drawing.Point(7, 30);
            this.pnlShortcuts.Name = "pnlShortcuts";
            this.pnlShortcuts.Size = new System.Drawing.Size(807, 21);
            this.pnlShortcuts.TabIndex = 7;
            // 
            // lblTextCopied
            // 
            this.lblTextCopied.AutoSize = true;
            this.lblTextCopied.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.lblTextCopied.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblTextCopied.Location = new System.Drawing.Point(9, 54);
            this.lblTextCopied.Name = "lblTextCopied";
            this.lblTextCopied.Padding = new System.Windows.Forms.Padding(2);
            this.lblTextCopied.Size = new System.Drawing.Size(6, 19);
            this.lblTextCopied.TabIndex = 6;
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(578, 4);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(42, 23);
            this.btnClear.TabIndex = 4;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnTranslate
            // 
            this.btnTranslate.Location = new System.Drawing.Point(623, 3);
            this.btnTranslate.Name = "btnTranslate";
            this.btnTranslate.Size = new System.Drawing.Size(67, 23);
            this.btnTranslate.TabIndex = 3;
            this.btnTranslate.Text = "Translate";
            this.btnTranslate.UseVisualStyleBackColor = true;
            this.btnTranslate.Click += new System.EventHandler(this.btnTranslate_Click);
            // 
            // txtWord
            // 
            this.txtWord.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtWord.Location = new System.Drawing.Point(145, 4);
            this.txtWord.Name = "txtWord";
            this.txtWord.Size = new System.Drawing.Size(427, 24);
            this.txtWord.TabIndex = 2;
            this.txtWord.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtWord_KeyDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(112, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(36, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Word:";
            // 
            // chkClipboardWatch
            // 
            this.chkClipboardWatch.AutoSize = true;
            this.chkClipboardWatch.Checked = true;
            this.chkClipboardWatch.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkClipboardWatch.FlatAppearance.BorderSize = 5;
            this.chkClipboardWatch.Location = new System.Drawing.Point(7, 8);
            this.chkClipboardWatch.Name = "chkClipboardWatch";
            this.chkClipboardWatch.Size = new System.Drawing.Size(105, 17);
            this.chkClipboardWatch.TabIndex = 0;
            this.chkClipboardWatch.Text = "Clipboard Watch";
            this.chkClipboardWatch.UseVisualStyleBackColor = true;
            // 
            // pnlFill
            // 
            this.pnlFill.Controls.Add(this.tabCtrlMain);
            this.pnlFill.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlFill.Location = new System.Drawing.Point(0, 102);
            this.pnlFill.Name = "pnlFill";
            this.pnlFill.Size = new System.Drawing.Size(826, 324);
            this.pnlFill.TabIndex = 1;
            // 
            // tabCtrlMain
            // 
            this.tabCtrlMain.Appearance = System.Windows.Forms.TabAppearance.FlatButtons;
            this.tabCtrlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabCtrlMain.Location = new System.Drawing.Point(0, 0);
            this.tabCtrlMain.Name = "tabCtrlMain";
            this.tabCtrlMain.SelectedIndex = 0;
            this.tabCtrlMain.Size = new System.Drawing.Size(826, 324);
            this.tabCtrlMain.TabIndex = 1;
            this.tabCtrlMain.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.tabCtrlMain_DrawItem);
            this.tabCtrlMain.SelectedIndexChanged += new System.EventHandler(this.tabctrlBrowsers_SelectedIndexChanged);
            // 
            // mainMenu
            // 
            this.mainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.dictToolStripMenuItem,
            this.toolStripMenuItem1,
            this.toolStripTextBox1,
            this.tsPrevWord,
            this.tsNextWord});
            this.mainMenu.Location = new System.Drawing.Point(0, 0);
            this.mainMenu.Name = "mainMenu";
            this.mainMenu.Size = new System.Drawing.Size(826, 24);
            this.mainMenu.TabIndex = 2;
            this.mainMenu.Text = "menuStrip1";
            // 
            // dictToolStripMenuItem
            // 
            this.dictToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsOpenDictFile,
            this.reloadDictionariesToolStripMenuItem,
            this.tsDeleteCache,
            this.exitToolStripMenuItem});
            this.dictToolStripMenuItem.Name = "dictToolStripMenuItem";
            this.dictToolStripMenuItem.Size = new System.Drawing.Size(40, 20);
            this.dictToolStripMenuItem.Text = "Dict";
            // 
            // tsOpenDictFile
            // 
            this.tsOpenDictFile.Name = "tsOpenDictFile";
            this.tsOpenDictFile.Size = new System.Drawing.Size(175, 22);
            this.tsOpenDictFile.Text = "Open Dict File";
            this.tsOpenDictFile.Click += new System.EventHandler(this.tsOpenDictFile_Click);
            // 
            // reloadDictionariesToolStripMenuItem
            // 
            this.reloadDictionariesToolStripMenuItem.Name = "reloadDictionariesToolStripMenuItem";
            this.reloadDictionariesToolStripMenuItem.Size = new System.Drawing.Size(175, 22);
            this.reloadDictionariesToolStripMenuItem.Text = "Reload Dictionaries";
            this.reloadDictionariesToolStripMenuItem.Click += new System.EventHandler(this.reloadDictionariesToolStripMenuItem_Click);
            // 
            // tsDeleteCache
            // 
            this.tsDeleteCache.Name = "tsDeleteCache";
            this.tsDeleteCache.Size = new System.Drawing.Size(175, 22);
            this.tsDeleteCache.Text = "Delete Cache";
            this.tsDeleteCache.Click += new System.EventHandler(this.tsDeleteCache_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(175, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsCheckForUpdate,
            this.aboutToolStripMenuItem});
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(44, 20);
            this.toolStripMenuItem1.Text = "Help";
            // 
            // tsCheckForUpdate
            // 
            this.tsCheckForUpdate.Name = "tsCheckForUpdate";
            this.tsCheckForUpdate.Size = new System.Drawing.Size(166, 22);
            this.tsCheckForUpdate.Text = "Check for Update";
            this.tsCheckForUpdate.Click += new System.EventHandler(this.tsCheckForUpdate_Click);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(166, 22);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // toolStripTextBox1
            // 
            this.toolStripTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.toolStripTextBox1.Enabled = false;
            this.toolStripTextBox1.Name = "toolStripTextBox1";
            this.toolStripTextBox1.ReadOnly = true;
            this.toolStripTextBox1.Size = new System.Drawing.Size(50, 20);
            // 
            // tsPrevWord
            // 
            this.tsPrevWord.Enabled = false;
            this.tsPrevWord.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tsPrevWord.Name = "tsPrevWord";
            this.tsPrevWord.Size = new System.Drawing.Size(27, 20);
            this.tsPrevWord.Text = "<";
            this.tsPrevWord.Click += new System.EventHandler(this.btnPrevWord_Click);
            // 
            // tsNextWord
            // 
            this.tsNextWord.Enabled = false;
            this.tsNextWord.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tsNextWord.Name = "tsNextWord";
            this.tsNextWord.Size = new System.Drawing.Size(27, 20);
            this.tsNextWord.Text = ">";
            this.tsNextWord.Click += new System.EventHandler(this.btnNextWord_Click);
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(826, 426);
            this.Controls.Add(this.pnlFill);
            this.Controls.Add(this.pnlTop);
            this.Controls.Add(this.mainMenu);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.mainMenu;
            this.Name = "FrmMain";
            this.Text = "My Online Dict";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmMain_FormClosing);
            this.Load += new System.EventHandler(this.FrmMain_Load);
            this.SizeChanged += new System.EventHandler(this.FrmMain_SizeChanged);
            this.Resize += new System.EventHandler(this.FrmMain_Resize);
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            this.pnlFill.ResumeLayout(false);
            this.mainMenu.ResumeLayout(false);
            this.mainMenu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnlTop;
        private System.Windows.Forms.Panel pnlFill;
        private System.Windows.Forms.CheckBox chkClipboardWatch;
        private System.Windows.Forms.Button btnTranslate;
        private TextBoxEx txtWord;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabControl tabCtrlMain;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Label lblTextCopied;
        private System.Windows.Forms.FlowLayoutPanel pnlShortcuts;
        private System.Windows.Forms.MenuStrip mainMenu;
        private System.Windows.Forms.ToolStripMenuItem dictToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem reloadDictionariesToolStripMenuItem;
        private System.Windows.Forms.ToolStripTextBox toolStripTextBox1;
        private System.Windows.Forms.ToolStripMenuItem tsPrevWord;
        private System.Windows.Forms.ToolStripMenuItem tsNextWord;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tsCheckForUpdate;
        private System.Windows.Forms.ToolStripMenuItem tsDeleteCache;
        private System.Windows.Forms.ToolStripMenuItem tsOpenDictFile;
    }
}

