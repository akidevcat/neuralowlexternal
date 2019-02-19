using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using NeuralOwl.Back.CsgoExternal.Math;

namespace NeuralOwl.Back.CsgoExternal.Game
{
    public class Entity : CsgoBehaviour
    {
        public bool Dormant { get => ReadBoolean(0xED); }
        public int Index { get => ReadInt32(0x64); }
        public int GlowIndex { get => ReadInt32(Netvars.m_iGlowIndex); }
        public int SpottedByMask { get => ReadInt32(Netvars.m_bSpottedByMask); }
        public Flags Flags { get => (Flags)ReadInt32(Netvars.m_fFlags); }
        public ClassIDs ClassId
        {
            get
            {
                var classId = (IntPtr)ReadInt32(0x8);
                classId = (IntPtr)reader.ReadInt32(classId + 0x8);
                classId = (IntPtr)reader.ReadInt32(classId + 0x1);
                return (ClassIDs)reader.ReadInt32(classId + 0x14);
            }
        }
        public Color ClearRender
        {
            get => ReadColor(Netvars.m_clrRender);
            set => reader.WriteColor(address + Netvars.m_clrRender, value);
        }
        public Vector3 Velocity { get => ReadVector3(Netvars.m_vecVelocity); }
        public Vector3 Position { get => ReadVector3(Netvars.m_vecOrigin); }

        public Entity(IntPtr address, MemoryReader reader, int memorySize = CsgoStructs.szEntity) : base(address, reader, memorySize) { }

        public bool CheckVisibility(int playerId) => (ReadInt32(Netvars.m_bSpottedByMask) & (1 << playerId - 1)) > 0;

        public static Entity FindClosestEntity(Entity[] array, Entity entity)
        {
            var closestDst = double.PositiveInfinity;
            Entity closestEnt = null;
            foreach (Entity ent in array)
            {
                if (ent.address == entity.address)
                    continue;
                double dst = (Vector3.Distance(entity.Position, ent.Position));
                if (dst < closestDst)
                {
                    closestEnt = ent;
                    closestDst = dst;
                }

            }
            return closestEnt;
        }
        public static Player FindClosestPlayer(Player[] array, Player player, bool enemiesOnly = false)
        {
            var closestDst = double.PositiveInfinity;
            Player closestPlr = null;
            foreach (Player plr in array)
            {
                if (plr.address == player.address)
                    continue;
                if (enemiesOnly && plr.Team == player.Team)
                    continue;
                double dst = (Vector3.Distance(player.Position, plr.Position));
                if (dst < closestDst)
                {
                    closestPlr = plr;
                    closestDst = dst;
                }
                
            }
            return closestPlr;
        }
    }
}
