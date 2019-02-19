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
    public partial class DimForm : Form
    {
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x80;
                return cp;
            }
        }

        public DimForm()
        {
            SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            this.ShowInTaskbar = false;
            WindowState = FormWindowState.Maximized;
            this.Opacity = .9;
            InitializeComponent();
            this.Show();
        }

        private void DimForm_Load(object sender, EventArgs e)
        {

        }
    }
}
