using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeuralOwl.Back.CsgoExternal.Game
{
    public class RadarBase : CsgoBehaviour
    {
        public RadarBase(IntPtr address, MemoryReader reader) : base(address, reader, CsgoStructs.szRadarBase) { }

        public string GetPlayerNickname(int id)
        {
            id += 1; //There's 1 fake struct
            var ptr = ReadInt32(0x6C);
            var raw = reader.ReadRaw((IntPtr)ptr + (0x168 * id) + 0x18, 64);
            return Encoding.UTF8.GetString(raw).TrimEnd('\0');
        }
        public int GetPlayerUserID(int id)
        {
            id += 1; 
            var ptr = ReadInt32(0x6C);
            var raw = reader.ReadRaw((IntPtr)ptr + (0x168 * id) + 0x18 + 8, 64);
            return BitConverter.ToInt32(raw, 0);
        }
    }
}
