using System;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeuralOwl.Front
{
    public class AnimatedPanel
    {
        private static float currentSize;
        public static Panel currentPanel;
        private static float timer = 0;
        private static bool isOpened = false;
        private static bool isInProcess = false;

        public static void Toggle(Panel panel, int size)
        {
            if (isInProcess)
                return;
            isInProcess = true;
            if (!isOpened)
            {
                currentPanel = panel;
                currentSize = size;
            }
            isOpened = currentPanel.Size.Height == 0;
            timer = 0;
            var animation = new Timer() { Interval = 1 };
            animation.Tick += PlayAnimation;
            animation.Start();
        }

        private static void PlayAnimation(object sender, EventArgs e)
        {
            if (timer == 0)
                timer = 0;
            if (timer > .999)
            {
                var t = (Timer)sender;
                isInProcess = false;
                t.Stop();
            }
            if (!isOpened)
                currentPanel.Height = (int)((1f - timer) * currentSize);
            else
                currentPanel.Height = (int)(timer * currentSize);
            currentPanel.Invalidate();
            timer += (1f - timer) * .2f;
            //Console.WriteLine(timer);
        }
    }
}
