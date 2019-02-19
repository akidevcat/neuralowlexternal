using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using NeuralOwl.Configuration;

namespace NeuralOwl.Front.Forms.Main
{
    public partial class PreferencesForm : Form
    {
        const int WM_NCLBUTTONDOWN = 0xA1;
        const int HT_CAPTION = 0x2;

        private void MoveWindow(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Win32.ReleaseCapture();
                Win32.SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        public PreferencesForm(Form f)
        {
            Owner = f;
            InitializeComponent();
            Hide();
        }

        public void ShowFade()
        {
            Opacity = 0;
            Show();
            Update();
            for (double a = 0; a <= 1.0; a += 0.005)
            {
                Opacity = a;
                System.Threading.Thread.Sleep(1);
            }
        }

        private void PreferencesForm_Load(object sender, EventArgs e)
        {
            TopMost = true;
            ToggleButton.Text = ((Keys)Config.Preferences.ToggleKey).ToString();
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            for (double a = 1.0; a >= 0; a -= 0.005)
            {
                Opacity = a;
                System.Threading.Thread.Sleep(1);
            }
            Opacity = 0;
            Hide();
        }

        private bool AwaitingKeyPress = false;
        private void ToggleButton_Click(object sender, EventArgs e)
        {
            AwaitingKeyPress = !AwaitingKeyPress;
        }
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (AwaitingKeyPress)
            {
                Config.Preferences.ToggleKey = (int)keyData;
                ToggleButton.Text = keyData.ToString();
                AwaitingKeyPress = false;
                Config.Save();
                return true;
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }
    }
}
