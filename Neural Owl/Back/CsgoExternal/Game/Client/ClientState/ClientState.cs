using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using NeuralOwl.Back.CsgoExternal.Math;

namespace NeuralOwl.Back.CsgoExternal.Game
{
    public class ClientState : CsgoBehaviour
    {
        public bool IsHLTV { get => reader.ReadBoolean(address + Signatures.dwClientState_IsHLTV); }
        public GameStates State { get => (GameStates)reader.ReadInt32(address + Signatures.dwClientState_State); }
        public int MaxPlayer { get => reader.ReadInt32(address + Signatures.dwClientState_MaxPlayer); }
        public Vector2 ViewAngles
        {
            //get => reader.ReadVector2(address + Signatures.dwClientState_ViewAngles); TODO: FIX
            //get => new Vector2(reader.ReadFloat(address + Signatures.dwClientState_ViewAngles),
            //    reader.ReadFloat(address + Signatures.dwClientState_ViewAngles + 0x4));
            get => new Vector2(reader.ReadFloatUncached(address + Signatures.dwClientState_ViewAngles),
                               reader.ReadFloatUncached(address + Signatures.dwClientState_ViewAngles + 0x4));
            set
            {
                if (value.x < 180f && value.x > -180f &&
                    value.y < 180f && value.y > -180f &&
                    !float.IsNaN(value.x) && !float.IsNaN(value.y))
                    reader.WriteVector2(address + Signatures.dwClientState_ViewAngles, value);
            }
        }

        public ClientState(IntPtr address, MemoryReader reader) : base(address, reader) { }

    }
}
