using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

using NeuralOwl.Back.Main;
using NeuralOwl.Configuration;
using NeuralOwl.Back.CsgoExternal;
using NeuralOwl.Back.CsgoExternal.Game;
using NeuralOwl.Back.CsgoExternal.Math;

namespace NeuralOwl.Back.CheatModules
{
    public abstract class CheatModule
    {
        [DllImport("User32.dll")]
        public static extern short GetAsyncKeyState(Keys vKey);

        public CheatModule(int msTimeout) => new Thread(() => Initialize(msTimeout)).Start();

        private void Initialize(int msTimeout)
        {
            Thread.CurrentThread.IsBackground = true;
            Thread.CurrentThread.Priority = ThreadPriority.Highest;

            while (true)
            {
                Thread.Sleep(msTimeout);

                if (CheatMain.ingameTick <= 0)
                    continue;

                Update();
            }
        }

        internal abstract void Update();
    }
}
