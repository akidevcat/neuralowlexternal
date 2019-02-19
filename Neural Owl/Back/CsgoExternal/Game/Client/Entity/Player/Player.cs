using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using NeuralOwl.Back.CsgoExternal.Math;

namespace NeuralOwl.Back.CsgoExternal.Game
{
    public class Player : Entity
    {
        public bool Scoped { get => ReadBoolean(Netvars.m_bIsScoped); }
        public bool Dead { get => Health <= 0; }
        public bool Protected { get => ReadBoolean(Netvars.m_bGunGameImmunity); }
        public bool Reloading { get => ReadBoolean(Netvars.m_bInReload); }
        public bool Defusing { get => ReadBoolean(Netvars.m_bIsDefusing); }
        public bool HasDefuser { get => ReadBoolean(Netvars.m_bHasDefuser); }
        public bool HasHelmet { get => ReadBoolean(Netvars.m_bHasHelmet); }
        public bool Spotted
        {
            get => ReadBoolean(Netvars.m_bSpotted);
            set => reader.WriteBoolean(address + Netvars.m_bSpotted, value);
        }
        public int Health { get => ReadInt32(Netvars.m_iHealth); }
        public int Armor { get => ReadInt32(Netvars.m_ArmorValue); }
        public int Team { get => ReadInt32(Netvars.m_iTeamNum); }
        public int ShotsFired { get => ReadInt32(Netvars.m_iShotsFired); }
        public int ActiveWeaponID { get => Dead ? -1 : ReadInt32(Netvars.m_hActiveWeapon) & 0xFFF; }
        public Vector3 ViewOffset { get => ReadVector3(Netvars.m_vecViewOffset); }
        public float ViewOffsetZ { get => ReadFloat(Netvars.m_vecViewOffset + 0x8); }
        public Vector3 ViewPosition { get => ViewOffset + Position; }

        public Player(IntPtr address, MemoryReader reader, int memorySize = CsgoStructs.szPlayer) : base(address, reader, memorySize) { }

        public Vector3 GetBonePosition(int bone)
        {
            var matrix = (IntPtr)ReadInt32(Netvars.m_dwBoneMatrix);
            //return reader.ReadVector3(matrix + 0x30 * bone); //todo fix
            return new Vector3(reader.ReadFloat(matrix + 0x30 * bone + 0xC),
                               reader.ReadFloat(matrix + 0x30 * bone + 0x1C),
                               reader.ReadFloat(matrix + 0x30 * bone + 0x2C));
        }
    }
}
