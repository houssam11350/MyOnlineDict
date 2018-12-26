using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Win32;
using System.Diagnostics;

namespace MyOnlineDict
{
    public partial class FrmAbout : Form
    {
        public FrmAbout()
        {
            InitializeComponent();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            Close();

        }
         private void pictureBox1_Click(object sender, EventArgs e)
        {
            string url = "";

            string business = "houssam11350@yahoo.com";  // your paypal email
            string description = "Donation";            // '%20' represents a space. remember HTML!
            string country = "DE";                  // AU, US, etc.
            string currency = "USD";                 // AUD, USD, etc.

            url += "https://www.paypal.com/cgi-bin/webscr" +
                "?cmd=" + "_donations" +
                "&business=" + business +
                "&lc=" + country +
                "&item_name=" + description +
                "&currency_code=" + currency +
                "&bn=" + "PP%2dDonationsBF";

            ProcessStartInfo sInfo = new ProcessStartInfo(url);
            Process.Start(sInfo);
        }

         private void FrmAbout_Load(object sender, EventArgs e)
         {
            string currentVersion = "1.0.0.0";
            lblCurrentVersion.Text = currentVersion;
         }

         private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
         {
            ProcessStartInfo sInfo = new ProcessStartInfo("https://github.com/houssam11350/MyOnlineDict");
            Process.Start(sInfo);
        }






    }
}
