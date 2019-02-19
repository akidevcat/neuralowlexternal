using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NeuralOwl.Front.Forms.NOO
{
    public partial class NOOForm : Form
    {
        public NOOForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void InfoButton_Click(object sender, EventArgs e)
        {

        }

        private void InfoButton_Draw(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;
            Color color = Color.Blue;
            Color shadow = Color.FromArgb(255, 16, 16, 16);

            //for (int i = 0; i < 8; i++)
             //   using (SolidBrush brush = new SolidBrush(Color.FromArgb(80 - i * 10, shadow)))
              //  {
                //    g.FillEllipse(brush, InfoButton.ClientRectangle.X + i * 2,
                  //                       InfoButton.ClientRectangle.Y + i, 60, 60);
                //}
            //using (SolidBrush brush = new SolidBrush(color))
            //    g.FillEllipse(brush, InfoButton.ClientRectangle.X, InfoButton.ClientRectangle.Y, 60, 60);

            // move to the right to use the same coordinates again for the drawn shape
            //g.TranslateTransform(80, 0);

            for (int i = 0; i < 8; i++)
                using (Pen pen = new Pen(Color.FromArgb(80 - i * 10, shadow), 2.5f))
                {
                    g.DrawEllipse(pen, InfoButton.ClientRectangle.X - 10,
                                       InfoButton.ClientRectangle.Y - 10, InfoButton.Size.Width + i, InfoButton.Size.Height + i);
                }
            //using (Pen pen = new Pen(color))
            //    g.DrawEllipse(pen, InfoButton.ClientRectangle.X, InfoButton.ClientRectangle.Y, 60, 60);
        }
    }
}
