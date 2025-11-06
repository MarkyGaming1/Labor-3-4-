using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Labor3
{
    public partial class Form1 : Form
    {
        private const string BLOCKED_WORDS_STRING = "porn,gambling,torrent";
        private bool IsUrlbloced(string url)
        {
        string lowerUrl = url.ToLower();
            string[] blockedWords = BLOCKED_WORDS_STRING.Split(',');
            foreach (string word in blockedWords)
            {
                if (lowerUrl.Contains(word))
                {
                    return true;
                }
            }
            return false;
        }
        string url;
        public Form1()
        {
            InitializeComponent();
            webBrowser1.ScriptErrorsSuppressed = true;
            url = toolStripTextBox1.Text;
            SetIE11Mode();
            webView21.Source = new Uri("https://www.google.com");

        }


        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            webBrowser1.GoForward();
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            url = toolStripTextBox1.Text;
            if (IsUrlbloced(url))
            {
                MessageBox.Show("Access to this site is blocked.", "Blocked", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            webBrowser1.Navigate(url);
        }

        private void back_Click(object sender, EventArgs e)
        {
            webBrowser1.GoBack();
        }

        private void home_Click(object sender, EventArgs e)
        {
            webBrowser1.GoHome();
        }

        private void toolStripTextBox1_Click(object sender, EventArgs e)
        {

        }

        private void toolStripTextBox1_Enter(object sender, EventArgs e)
        {

        }
        private void toolStripTextBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                url = toolStripTextBox1.Text;
                if (IsUrlbloced(url))
                {
                    MessageBox.Show("Access to this site is blocked.", "Blocked", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                webBrowser1.Navigate(url);
            }

        }

        private void toolStripTextBox2_Click(object sender, EventArgs e)
        {

        }
        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            if (e.Url.Equals(webBrowser1.Url))
            {
                toolStripTextBox2.Text = webBrowser1.Url.AbsoluteUri;
            }
        }

        public static void SetIE11Mode()
        {
            string featureControlRegKey = @"Software\Microsoft\Internet Explorer\Main\FeatureControl\FEATURE_BROWSER_EMULATION";
            string appName = Path.GetFileName(AppDomain.CurrentDomain.FriendlyName);

            try
            {
                using (RegistryKey registryKey = Registry.CurrentUser.OpenSubKey(featureControlRegKey, true))
                {
                    if (registryKey != null)
                    {
                        registryKey.SetValue(appName, 11001, RegistryValueKind.DWord);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Hiba a registry beállítása közben: " + ex.Message);
            }
        }

        private void webView21_Click(object sender, EventArgs e)
        {

        }
    }
}



