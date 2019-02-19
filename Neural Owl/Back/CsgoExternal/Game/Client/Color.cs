using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeuralOwl.Back.CsgoExternal.Game
{
    [Serializable]
    public struct Color
    {
        public float r, g, b, a;

        #region Colors
        public static readonly Color Empty = new Color(0,0,0,1f);
        #endregion

        public Color(float r, float g, float b, float a)
        {
            this.r = r;
            this.g = g;
            this.b = b;
            this.a = a;
        }

        public Color(byte[] rgba)
        {
            var temp = new byte[4];
            Buffer.BlockCopy(rgba, 0, temp, 0, 4);
            this.r = BitConverter.ToSingle(temp, 0);
            Buffer.BlockCopy(rgba, 0x4, temp, 0, 4);
            this.g = BitConverter.ToSingle(temp, 0);
            Buffer.BlockCopy(rgba, 0x8, temp, 0, 4);
            this.b = BitConverter.ToSingle(temp, 0);
            Buffer.BlockCopy(rgba, 0xC, temp, 0, 4);
            this.a = BitConverter.ToSingle(temp, 0);
        }

        public override string ToString()
        {
            return string.Format("{0} {1} {2} {3}", r,g,b,a);
        }

        public static bool operator ==(Color c1, Color c2)
        {
            return c1.r == c2.r && c1.g == c2.g && c1.b == c2.b && c1.a == c2.a;
        }
        public static bool operator !=(Color c1, Color c2)
        {
            return c1.r != c2.r || c1.g != c2.g || c1.b != c2.b || c1.a != c2.a;
        }

        public static implicit operator byte[] (Color c)
        {
            var buffer = new byte[16];
            Buffer.BlockCopy(BitConverter.GetBytes(c.r), 0, buffer, 0, 4);
            Buffer.BlockCopy(BitConverter.GetBytes(c.g), 0, buffer, 4, 4);
            Buffer.BlockCopy(BitConverter.GetBytes(c.b), 0, buffer, 8, 4);
            Buffer.BlockCopy(BitConverter.GetBytes(c.a), 0, buffer, 12, 4);
            return buffer;
        }
        public static implicit operator Color (System.Drawing.Color c) => new Color(c.R / 255f, c.G / 255f, c.B / 255f, c.A / 255f);
        public static implicit operator System.Drawing.Color(Color c) => System.Drawing.Color.FromArgb((int)(c.a * 255f), (int)(c.r * 255f), (int)(c.g * 255f), (int)(c.b * 255f));
    }
}
