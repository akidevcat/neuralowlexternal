using NeuralOwl.Back.CsgoExternal.Math;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeuralOwl.Back.CsgoExternal.Game
{
    public class EntityList : CsgoBehaviour
    {
        private int entityCount;

        public EntityList(IntPtr address, MemoryReader reader, int entityCount = 64) : base(address, reader, entityCount * CsgoStructs.szEntityListPerEntity)
        {
            this.entityCount = entityCount;
        }

        public Entity FindEntityByID(int entityID)
        {
            if (entityID < 0)
                return null;
            if (entityID >= entityCount)
                return new Entity(reader.ReadIntPtr(address + entityID * CsgoStructs.szEntityListPerEntity), reader);
            //default
            return new Entity((IntPtr)ReadInt32(entityID * CsgoStructs.szEntityListPerEntity), reader);
        }
        public Player FindPlayerByID(int entityID)
        {
            if (entityID < 0)
                return null;
            if (entityID >= entityCount)
                return new Player(reader.ReadIntPtr(address + entityID * CsgoStructs.szEntityListPerEntity), reader);
            //default
            return new Player((IntPtr)ReadInt32(entityID * CsgoStructs.szEntityListPerEntity), reader);
        }
        public Weapon FindWeaponByID(int entityID)
        {
            if (entityID < 0)
                return null;
            if (entityID >= entityCount)
                return new Weapon(reader.ReadIntPtr(address + entityID * CsgoStructs.szEntityListPerEntity), reader);
            //default
            return new Weapon((IntPtr)ReadInt32(entityID * CsgoStructs.szEntityListPerEntity), reader);
        }
        public Entity[] FindAllEntities(bool nonDormantOnly = true)
        {
            var entities = new List<Entity>();
            for (int i = 0; i < entityCount; i++)
            {
                var entityPtr = ReadInt32(i * 0x10);
                if (entityPtr == 0x0)
                    continue;
                var entity = new Entity((IntPtr)ReadInt32(i * 0x10), reader);
                if (nonDormantOnly && entity.Dormant)
                    continue;
                entities.Add(entity);
            }
            return entities.ToArray();
        }
        public Player[] FindAllPlayers(bool nonDormantOnly = true)
        {
            var players = new List<Player>();
            for (int i = 0; i < entityCount; i++)
            {
                var playerPtr = ReadInt32(i * 0x10);
                if (playerPtr == 0x0)
                    continue;
                var player = new Player((IntPtr)ReadInt32(i * 0x10), reader);
                if (nonDormantOnly && player.Dormant)
                    continue;
                if (player.Health <= 0)
                    continue;
                if (player.ClassId == ClassIDs.CCSPlayer)
                    players.Add(player);
            }
            return players.ToArray();
        }
        public Player[] FindVisiblePlayers(LocalPlayer lPlayer)
        {
            var players = new List<Player>();
            for (int i = 0; i < entityCount; i++)
            {
                var playerPtr = ReadInt32(i * 0x10);
                if (playerPtr == 0x0)
                    continue;
                var player = new Player((IntPtr)ReadInt32(i * 0x10), reader);
                if (player.Dormant)
                    continue;
                if (player.Health <= 0)
                    continue;
                if (player.Protected)
                    continue;
                if (!player.CheckVisibility(lPlayer.Index))
                    continue;
                if (player.ClassId == ClassIDs.CCSPlayer)
                    players.Add(player);
            }
            return players.ToArray();
        }
        public Player FindFovPlayer(LocalPlayer lPlayer, Player[] players, Vector2 view, out double fov, bool FFA = false, int bone = 8)
        {
            var lPos = lPlayer.ViewPosition;
            double bestFov = float.MaxValue;
            Player bestTarget = null;
            foreach (var p in players)
            {
                if (!FFA && p.Team == lPlayer.Team)
                    continue;
                var pos = p.GetBonePosition(bone);
                var target = Math3.CalcAngle(lPos, pos);
                var angle = Math3.AngleBetweenVec2(view, target);
                if (angle < bestFov)
                {
                    bestFov = angle;
                    bestTarget = p;
                }
            }
            fov = bestFov;
            return bestTarget;
        }
    }
}
