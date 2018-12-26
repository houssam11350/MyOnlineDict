using System;
using System.Windows.Forms;
using System.Data;
using System.Data.OleDb;
using Microsoft.Win32;
using System.IO;

namespace System
{
    public class Helper
    {

        //public static void MSG(string msg)
        //{
        //    System.Windows.Forms.MessageBox.Show(msg);
        //}

        public static void HandleException(Exception e)
        {
            string s = "Message= " + e.Message + "\n";
            s += "Source= " + e.Source + "\n";
            s += "Stack Trace= " + e.StackTrace + "\n";
            Exception inner = e.InnerException;
            MessageBox.Show(s);
            while (inner != null)
            {
                string ss = "Message= " + inner.Message + "\n";
                ss += "Source= " + inner.Source + "\n";
                ss += "Stack Trace= " + inner.StackTrace + "\n";
                MessageBox.Show(ss);
                inner = inner.InnerException;
            }
        }

        public static void ERRORMSG(string _Msg)
        {
            string _Caption = "My Online Dict";
            System.Windows.Forms.MessageBox.Show(_Msg, _Caption,
                System.Windows.Forms.MessageBoxButtons.OK,
                System.Windows.Forms.MessageBoxIcon.Error,
                System.Windows.Forms.MessageBoxDefaultButton.Button1);
        }
        public static void OKMSG(string _Msg)
        {
            string _Caption = "My Online Dict";
            System.Windows.Forms.MessageBox.Show(_Msg, _Caption,
                System.Windows.Forms.MessageBoxButtons.OK,
                System.Windows.Forms.MessageBoxIcon.Information,
                System.Windows.Forms.MessageBoxDefaultButton.Button1);
        }


    }

}
