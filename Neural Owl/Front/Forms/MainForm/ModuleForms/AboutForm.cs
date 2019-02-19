using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NeuralOwl.Front.Forms.Main
{
    public partial class AboutForm : Form
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

        public AboutForm(Form f)
        {
            Owner = f;
            InitializeComponent();
            Hide();
        }

        private void AboutForm_Load(object sender, EventArgs e)
        {
            TopMost = true;
            
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
    }
}
