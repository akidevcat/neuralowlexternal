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
    public partial class MiscForm : Form
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

        public MiscForm(Form f)
        {
            Owner = f;
            InitializeComponent();
            Bunnyhop.Checked = Config.Misc.BhopEnabled;
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

        private void ESPForm_Load(object sender, EventArgs e)
        {
            TopMost = true;
            
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

        private void Bunnyhop_CheckedChanged(object sender, EventArgs e)
        {
            Config.Misc.BhopEnabled = Bunnyhop.Checked;
            Config.Save();
        }
    }
}
