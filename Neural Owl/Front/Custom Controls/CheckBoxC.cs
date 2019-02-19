using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace NeuralOwl.Front.CustomControls
{
    class CheckBoxC : CheckBox
    {
        public CheckBoxC()
        {
            this.SetStyle(ControlStyles.UserPaint, true);
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
        }

        protected override void OnPaint(PaintEventArgs pevent)
        {
            base.OnPaint(pevent);
            if (this.Checked)
            {
                pevent.Graphics.FillRectangle(new SolidBrush(Color.Blue), new Rectangle(0, 0, 16, 16));
            }
            else
            {
                pevent.Graphics.FillRectangle(new SolidBrush(Color.Red), new Rectangle(0, 0, 16, 16));
            }
        }
    }
}
