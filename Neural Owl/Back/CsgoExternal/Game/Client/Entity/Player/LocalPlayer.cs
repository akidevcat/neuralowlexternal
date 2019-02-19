using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using NeuralOwl.Back.CsgoExternal.Math;

namespace NeuralOwl.Back.CsgoExternal.Game
{
    public class LocalPlayer : Player
    {
        public int CurrentTick { get => reader.ReadInt32Uncached(address + Netvars.m_nTickBase); }
        public int CrosshairID { get => ReadInt32(Netvars.m_iCrosshairId); }
        public float FlashDuration
        {
            get => ReadFloat(Netvars.m_flFlashDuration);
            set => reader.WriteFloat(address + Netvars.m_flFlashDuration, value);
        }
        public float FlashMaxAlpha
        {
            get => ReadFloat(Netvars.m_flFlashMaxAlpha);
            set => reader.WriteFloat(address + Netvars.m_flFlashMaxAlpha, value);
        }
        public Vector2 ViewPunchAngles { get => ReadVector2(Netvars.m_viewPunchAngle); }
        public Vector2 PunchAngles { get => ReadVector2(Netvars.m_aimPunchAngle); }
        public Vector2 PunchAnglesVelocity { get => ReadVector2(Netvars.m_aimPunchAngleVel); }

        public LocalPlayer(IntPtr address, MemoryReader reader, int memorySize = CsgoStructs.szLocalPlayer) : base(address, reader, memorySize) { }

    }
}
