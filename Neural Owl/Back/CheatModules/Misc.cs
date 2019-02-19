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
    public class Misc : CheatModule
    {
        public Misc() : base(1) { }

        internal override void Update()
        {
            BhopUpdate();
        }

        private void BhopUpdate()
        {
            if (!Config.Misc.BhopEnabled)
                return;

            if (CheatMain.clientState.State != GameStates.Full)
                return;

            if ((GetAsyncKeyState(Keys.Space) & 0x8000) != 0)
            {
                var localPlayer = CheatMain.client.GetLocalPlayer();
                if (localPlayer.Flags == Flags.FL_ON_GROUND || 
                    localPlayer.Flags == Flags.FL_ON_GROUND_CROUCHED || 
                    localPlayer.Flags == Flags.FL_ON_GROUND_MOVING_TO_CROUCH ||
                    localPlayer.Flags == Flags.FL_ON_GROUND_MOVING_TO_STAND)
                    CheatMain.client.ForceJump = 6;
            }
        }

    }
}
