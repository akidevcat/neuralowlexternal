using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeuralOwl.Back.CsgoExternal.Game
{
    public class GlowObjectManager : CsgoBehaviour
    {
        private int entityCount;

        public GlowObjectManager(IntPtr address, MemoryReader reader, int entityCount = 64) : base(address, reader, entityCount * CsgoStructs.szGlowObjectManagerPerEntity)
        {
            this.entityCount = entityCount;
        }

        public GlowObject FindGlowObjectByID(int glowID) => glowID >= entityCount ? null : ReadRaw(glowID * CsgoStructs.szGlowObjectManagerPerEntity + 0x4, 0x2C);
        public void WriteGlowObjectByID(int glowID, GlowObject glObj) => reader.WriteRaw(address + glowID * CsgoStructs.szGlowObjectManagerPerEntity + 0x4, glObj);
    }
}
