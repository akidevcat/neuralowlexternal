using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using NeuralOwl.Back.CsgoExternal.Math;

namespace NeuralOwl.Back.CsgoExternal.Game
{
    public abstract class CsgoBehaviour
    {
        public IntPtr address { get; protected set; }
        protected MemoryReader reader;
        protected byte[] data;

        public CsgoBehaviour(IntPtr address, MemoryReader reader, int memorySize = 0)
        {
            this.address = address;
            this.reader = reader;
            if (memorySize > 0)
                this.data = reader.ReadRaw(address, memorySize);
        }

        public static bool operator ==(CsgoBehaviour left, CsgoBehaviour right)
        {
            if (ReferenceEquals(null, left) && ReferenceEquals(right, null))
                return true;
            if (ReferenceEquals(left, null) || ReferenceEquals(right, null))
                return false;
            return left.address == right.address;
        }
        public static bool operator !=(CsgoBehaviour left, CsgoBehaviour right)
        {
            if (ReferenceEquals(left, null) && ReferenceEquals(right, null))
                return false;
            if (ReferenceEquals(left, null) || ReferenceEquals(right, null))
                return true;
            return left.address != right.address;
        }

        public bool ReadBoolean(int offset) => BitConverter.ToBoolean(data, offset);
        public byte[] ReadRaw (int offset, int length)
        {
            var temp = new byte[length];
            Buffer.BlockCopy(data, offset, temp, 0, length);
            return temp;
        }
        public int ReadInt32(int offset) => BitConverter.ToInt32(data, offset);
        public short ReadShort(int offset) => BitConverter.ToInt16(data, offset);
        public float ReadFloat(int offset) => BitConverter.ToSingle(data, offset);
        public float[] ReadFloatArray(int offset, int length)
        {
            var temp = new float[length];
            Buffer.BlockCopy(data, offset, temp, 0, length * 4);
            return temp;
        }
        public long ReadLong(int offset) => BitConverter.ToInt64(data, offset);
        public string ReadStringASCII(int offset, int size) => Encoding.ASCII.GetString(data, offset, size);
        public string ReadStringUnicode(int offset, int size) => Encoding.Unicode.GetString(data, offset, size);
        public Vector3 ReadVector3(int offset)
        {
            var xyz = ReadFloatArray(offset, 3);
            return new Vector3(xyz[0], xyz[1], xyz[2]);
        }
        public Vector2 ReadVector2(int offset)
        {
            var xy = ReadFloatArray(offset, 2);
            return new Vector2(xy[0], xy[1]);
        }
        public Color ReadColor(int offset)
        {
            var raw = ReadRaw(offset, 16);
            var color = new Color(BitConverter.ToInt32(raw, 0),
                                  BitConverter.ToInt32(raw, 4),
                                  BitConverter.ToInt32(raw, 8),
                                  BitConverter.ToInt32(raw, 12));
            return color;
        }
    }
}
