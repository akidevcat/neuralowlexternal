using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using NeuralOwl.Back.CsgoExternal.Math;

namespace NeuralOwl.Back.CsgoExternal.Game
{
    public class Client : CsgoBehaviour
    {
        public int ForceAttack
        {
            get => reader.ReadInt32(address + Signatures.dwForceAttack);
            set => reader.WriteInt32(address + Signatures.dwForceAttack, value);
        }
        public int ForceAttack2
        {
            get => reader.ReadInt32(address + Signatures.dwForceAttack2);
            set => reader.WriteInt32(address + Signatures.dwForceAttack, value);
        }
        public int ForceBackward
        {
            get => reader.ReadInt32(address + Signatures.dwForceBackward);
            set => reader.WriteInt32(address + Signatures.dwForceBackward, value);
        }
        public int ForceForward
        {
            get => reader.ReadInt32(address + Signatures.dwForceForward);
            set => reader.WriteInt32(address + Signatures.dwForceForward, value);
        }
        public int ForceJump
        {
            get => reader.ReadInt32(address + Signatures.dwForceJump);
            set => reader.WriteInt32(address + Signatures.dwForceJump, value);
        }
        public int ForceLeft
        {
            get => reader.ReadInt32(address + Signatures.dwForceLeft);
            set => reader.WriteInt32(address + Signatures.dwForceLeft, value);
        }
        public int ForceRight
        {
            get => reader.ReadInt32(address + Signatures.dwForceRight);
            set => reader.WriteInt32(address + Signatures.dwForceRight, value);
        }

        public Client(IntPtr address, MemoryReader reader) : base(address, reader) { }

        public LocalPlayer GetLocalPlayer() => new LocalPlayer(reader.ReadIntPtr(address + Signatures.dwLocalPlayer), reader);
        public EntityList GetEntityList(int entityCount = 64) => new EntityList(address + Signatures.dwEntityList, reader, entityCount);
        public GlowObjectManager GetGlowObjectManager(int entityCount = 256) => new GlowObjectManager(reader.ReadIntPtr(address + Signatures.dwGlowObjectManager), reader, entityCount);
        public PlayerResource GetPlayerResource(int playerCount = 10) => new PlayerResource(reader.ReadIntPtr(address + Signatures.dwPlayerResource), reader, playerCount);
        public RadarBase GetRadarBase() => new RadarBase(reader.ReadIntPtr(address + Signatures.dwRadarBase), reader);
    }
}
