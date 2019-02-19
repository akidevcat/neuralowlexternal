using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeuralOwl.Back.CsgoExternal.Game
{
    public enum GameStates
    {
        None = 0,
        Challenge = 1,
        Connected = 2,
        New = 3,
        Respawn = 4,
        Spawn = 5,
        Full = 6,
        ChangeLevel = 7
    }
}
