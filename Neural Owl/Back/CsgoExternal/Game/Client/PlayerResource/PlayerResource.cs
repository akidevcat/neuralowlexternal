using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeuralOwl.Back.CsgoExternal.Game
{
    public class PlayerResource : CsgoBehaviour
    {
        private int playerCount;

        public PlayerResource(IntPtr address, MemoryReader reader, int playerCount = 10) : base(address, reader, Netvars.m_iCompetitiveWins + playerCount * CsgoStructs.szPlayerResourcePerPlayer)
        {
            this.playerCount = playerCount;
        }

        public Ranks GetPlayerRank(int id) => id >= playerCount ? Ranks.Unranked : (Ranks)ReadInt32(Netvars.m_iCompetitiveRanking + 0x4 * id);
        public int GetPlayerWins(int id) => id >= playerCount ? -1 : ReadInt32(Netvars.m_iCompetitiveWins + 0x4 * id);
    }
}
