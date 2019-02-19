using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeuralOwl.Back.CsgoExternal.Game
{
    /*
    struct glow_t {
       DWORD dwBase; 
       float r;
       float g;
       float b;
       float m_flGlowAlpha;
       char m_unk[4];
       float m_flUnk;
       float m_flBloomAmount;
       float m_flUnk1;
       bool m_bRenderWhenOccluded;
       bool m_bRenderWhenUnoccluded;
       bool m_bFullBloomRender;
       char m_unk1;
       int m_nFullBloomStencilTestValue;
       int m_nGlowStyle;
       int m_nSplitScreenSlot;
       int m_nNextFreeSlot;
     };
        */

    public struct GlowObject
    {
        public byte[] rawData;

        public Color GlowColor//0x4 - 0x4
        {
            get => new Color(rawData.Take(16).ToArray());
            set => Buffer.BlockCopy(value, 0, rawData, 0, 16);
        }
        public float BloomAmount //0x1C - 0x4
        {
            get => BitConverter.ToSingle(rawData.Skip(0x18).Take(0x4).ToArray(), 0);
            set => Buffer.BlockCopy(BitConverter.GetBytes(value), 0, rawData, 0x18, 0x4);
        }
        public bool RenderWhenOccluded //0x24 - 0x4
        {
            get => BitConverter.ToBoolean(rawData.Skip(0x20).Take(1).ToArray(), 0);
            set => Buffer.BlockCopy(BitConverter.GetBytes(value), 0, rawData, 0x20, 1);
        }
        public bool RenderWhenUnoccluded //0x25 - 0x4
        {
            get => BitConverter.ToBoolean(rawData.Skip(0x21).Take(1).ToArray(), 0);
            set => Buffer.BlockCopy(BitConverter.GetBytes(value), 0, rawData, 0x21, 1);
        }
        public bool FullBloomRender //0x26 - 0x4
        {
            get => BitConverter.ToBoolean(rawData.Skip(0x22).Take(1).ToArray(), 0);
            set => Buffer.BlockCopy(BitConverter.GetBytes(value), 0, rawData, 0x22, 1);
        }
        public int GlowStyle //0x2C - 0x4
        {
            get => BitConverter.ToInt32(rawData.Skip(0x28).Take(4).ToArray(), 0);
            set => Buffer.BlockCopy(BitConverter.GetBytes(value), 0, rawData, 0x28, 0x4);
        }

        public GlowObject(byte[] rawData) => this.rawData = rawData;

        public static implicit operator byte[](GlowObject glObj) => glObj.rawData;
        public static implicit operator GlowObject (byte[] glObj) => new GlowObject(glObj);
    }
}
