using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

using NeuralOwl.Back.CsgoExternal.Game;
using NeuralOwl.Back.CsgoExternal.Math;

namespace NeuralOwl.Back.CsgoExternal
{
    public class MemoryReader
    {
        #region Const
        const int Const_PROCESS_WM_READ = 0x0010;
        const int Const_PROCESS_VM_WRITE = 0x0020;
        const int Const_PROCESS_VM_OPERATION = 0x0008;
        const int Const_PROCESS_ALL_ACCESS = 0x1F0FFF;
        #endregion

        #region DllImport
        [DllImport("kernel32.dll")]
        static extern IntPtr OpenProcess(int dwDesiredAccess, bool bInheritHandle, int dwProcessId);

        [DllImport("kernel32.dll")]
        static extern bool ReadProcessMemory(int hProcess, int lpBaseAddress, byte[] lpBuffer, int dwSize, ref int lpNumberOfBytesRead);

        [DllImport("kernel32.dll", SetLastError = true)]
        static extern bool WriteProcessMemory(int hProcess, int lpBaseAddress, byte[] lpBuffer, int dwSize, ref int lpNumberOfBytesWritten);
        #endregion

        private ProcessPointers Pointers;
        private MemoryReaderCache Cache;

        public MemoryReader(ProcessPointers processPointers)
        {
            Pointers = processPointers;
            Pointers.pOpenProcess = OpenProcess(Const_PROCESS_ALL_ACCESS, false, processPointers.idProcess);
            //Check for wrong pointer
            if (Pointers.pOpenProcess == IntPtr.Zero)
                throw new OpenProcessOwlException();

            Cache = new MemoryReaderCache();
        }

        public void Update() => Cache.Update();

        #region Readers
        public byte[] ReadRaw(IntPtr address, int length)
        {
            byte[] buffer;
            
            buffer = Cache.GetValue(address);
            if (buffer != null)
                if (buffer.Length >= length)
                {
                    Array.Resize(ref buffer, length);
                    return buffer;
                }


            buffer = new byte[length];
            int temp = 0;

            ReadProcessMemory((int)Pointers.pOpenProcess, (int)address, buffer, buffer.Length, ref temp);
            Cache.AddValue(address, buffer);

            return buffer;
        }
        public long ReadInt64(IntPtr address)
        {
            byte[] buffer;

            buffer = Cache.GetValue(address);
            if (buffer != null)
                if (buffer.Length >= 8)
                {
                    Array.Resize(ref buffer, 8);
                    return BitConverter.ToInt64(buffer, 0);
                }

            buffer = new byte[8];
            int temp = 0;

            ReadProcessMemory((int)Pointers.pOpenProcess, (int)address, buffer, buffer.Length, ref temp);
            Cache.AddValue(address, buffer);

            return BitConverter.ToInt64(buffer, 0);
        }
        public IntPtr ReadIntPtr(IntPtr address)
        {
            byte[] buffer;

            buffer = Cache.GetValue(address);
            if (buffer != null)
                if (buffer.Length >= 4)
                {
                    Array.Resize(ref buffer, 4);
                    return (IntPtr)BitConverter.ToInt32(buffer, 0);
                }

            buffer = new byte[4];
            int temp = 0;

            ReadProcessMemory((int)Pointers.pOpenProcess, (int)address, buffer, buffer.Length, ref temp);
            Cache.AddValue(address, buffer);

            return (IntPtr)BitConverter.ToInt32(buffer, 0);
        }
        public int ReadInt32(IntPtr address)
        {
            byte[] buffer;

            buffer = Cache.GetValue(address);
            if (buffer != null)
                if (buffer.Length >= 4)
                {
                    Array.Resize(ref buffer, 4);
                    return BitConverter.ToInt32(buffer, 0);
                }

            buffer = new byte[4];
            int temp = 0;

            ReadProcessMemory((int)Pointers.pOpenProcess, (int)address, buffer, buffer.Length, ref temp);
            Cache.AddValue(address, buffer);

            return BitConverter.ToInt32(buffer, 0);
        }
        public float ReadFloat(IntPtr address)
        {
            byte[] buffer;

            buffer = Cache.GetValue(address);
            if (buffer != null)
                if (buffer.Length >= 4)
                {
                    Array.Resize(ref buffer, 4);
                    return BitConverter.ToSingle(buffer, 0);
                }

            buffer = new byte[4];
            int temp = 0;

            ReadProcessMemory((int)Pointers.pOpenProcess, (int)address, buffer, buffer.Length, ref temp);
            Cache.AddValue(address, buffer);

            return BitConverter.ToSingle(buffer, 0);
        }
        public float ReadFloatUncached(IntPtr address)
        {
            var buffer = new byte[4];
            int temp = 0;

            ReadProcessMemory((int)Pointers.pOpenProcess, (int)address, buffer, buffer.Length, ref temp);
            Cache.AddValue(address, buffer);

            return BitConverter.ToSingle(buffer, 0);
        }
        public float[] ReadFloatArray(IntPtr address, int length)
        {
            byte[] buffer;

            buffer = Cache.GetValue(address);
            if (buffer != null)
            {
                if (buffer.Length >= 4 * length)
                {
                    var floatArray = new float[length];
                    Buffer.BlockCopy(buffer, 0, floatArray, 0, length); // length * 4 ?

                    return floatArray;
                }
            }

            int temp = 0;
            buffer = new byte[4 * length];

            ReadProcessMemory((int)Pointers.pOpenProcess, (int)address, buffer, buffer.Length, ref temp);
            Cache.AddValue(address, buffer);

            var readFloatArray = new float[length];
            Buffer.BlockCopy(buffer, 0, readFloatArray, 0, buffer.Length);

            return readFloatArray;
        }
        public string ReadStringASCII(IntPtr address, int byteSize)
        {
            byte[] buffer;

            buffer = Cache.GetValue(address);
            if (buffer != null)
                if (buffer.Length >= byteSize)
                {
                    Array.Resize(ref buffer, byteSize);
                    return Encoding.ASCII.GetString(buffer);
                }

            int temp = 0;
            buffer = new byte[byteSize];

            ReadProcessMemory((int)Pointers.pOpenProcess, (int)address, buffer, buffer.Length, ref temp);
            Cache.AddValue(address, buffer);

            return Encoding.ASCII.GetString(buffer);
        }
        public string ReadStringUnicode(IntPtr address, int byteSize)
        {
            byte[] buffer;

            buffer = Cache.GetValue(address);
            if (buffer != null)
                if (buffer.Length >= byteSize)
                {
                    Array.Resize(ref buffer, byteSize);
                    return Encoding.Unicode.GetString(buffer);
                }

            int temp = 0;
            buffer = new byte[byteSize];

            ReadProcessMemory((int)Pointers.pOpenProcess, (int)address, buffer, buffer.Length, ref temp);
            Cache.AddValue(address, buffer);

            return Encoding.Unicode.GetString(buffer);
        }
        /*
        public Vector3 ReadVector3(IntPtr address)
        {
            byte[] buffer;
            buffer = GetValue(address);
            if (buffer != null)
            {
                if (buffer.Length == 12)
                    return ByteToVector3(buffer);
                else
                    return Vector3.Zero;
            }

            int temp = 0;
            buffer = new byte[12];

            ReadProcessMemory((int)processHandle, (int)address, buffer, buffer.Length, ref temp);
            AddValue(address, buffer);

            return ByteToVector3(buffer);
        }
        */
        public bool ReadBoolean(IntPtr address)
        {
            byte[] buffer;

            buffer = Cache.GetValue(address);
            if (buffer != null)
                if (buffer.Length >= 1)
                {
                    Array.Resize(ref buffer, 1);
                    return BitConverter.ToBoolean(buffer, 0);
                }

            int temp = 0;
            buffer = new byte[1];

            ReadProcessMemory((int)Pointers.pOpenProcess, (int)address, buffer, buffer.Length, ref temp);
            Cache.AddValue(address, buffer);

            return BitConverter.ToBoolean(buffer, 0);
        }
        public Vector2 ReadVector2(IntPtr address)
        {
            var xyz = ReadFloatArray(address, 2);
            return new Vector2(xyz[0], xyz[1]);
        }
        public Vector3 ReadVector3(IntPtr address)
        {
            var xyz = ReadFloatArray(address, 3);
            return new Vector3(xyz[0], xyz[1], xyz[2]);
        }

        public int ReadInt32Uncached(IntPtr address)
        {
            var buffer = new byte[4];
            int temp = 0;

            ReadProcessMemory((int)Pointers.pOpenProcess, (int)address, buffer, buffer.Length, ref temp);

            return BitConverter.ToInt32(buffer, 0);
        }
        #endregion
        #region Writers
        public void WriteRaw(IntPtr address, byte[] value)
        {
            int temp = 0;
            WriteProcessMemory((int)Pointers.pOpenProcess, (int)address, value, value.Length, ref temp);
        }
        public void WriteInt32(IntPtr address, int value)
        {
            int temp = 0;
            byte[] buffer = BitConverter.GetBytes(value);

            WriteProcessMemory((int)Pointers.pOpenProcess, (int)address, buffer, buffer.Length, ref temp);
        }
        public void WriteInt64(IntPtr address, long value)
        {
            int temp = 0;
            byte[] buffer = BitConverter.GetBytes(value);

            WriteProcessMemory((int)Pointers.pOpenProcess, (int)address, buffer, buffer.Length, ref temp);
        }
        public void WriteFloat(IntPtr address, float value)
        {
            int temp = 0;
            byte[] buffer = BitConverter.GetBytes(value);

            WriteProcessMemory((int)Pointers.pOpenProcess, (int)address, buffer, buffer.Length, ref temp);
        }
        public void WriteFloatArray(IntPtr address, float[] value)
        {
            int temp = 0;
            byte[] buffer = new byte[value.Length * 4];
            Buffer.BlockCopy(value, 0, buffer, 0, buffer.Length);

            WriteProcessMemory((int)Pointers.pOpenProcess, (int)address, buffer, buffer.Length, ref temp);
        }
        public void WriteBoolean(IntPtr address, bool value)
        {
            int temp = 0;
            byte[] buffer = BitConverter.GetBytes(value);

            WriteProcessMemory((int)Pointers.pOpenProcess, (int)address, buffer, buffer.Length, ref temp);
        }
        public void WriteVector3(IntPtr address, Vector3 value)
        {
            var temp = new float[3];
            temp[0] = value.x;
            temp[1] = value.y;
            temp[2] = value.z;
            WriteFloatArray(address, temp);
        }
        public void WriteVector2(IntPtr address, Vector2 value)
        {
            var temp = new float[2];
            temp[0] = value.x;
            temp[1] = value.y;
            WriteFloatArray(address, temp);
        }
        public void WriteColor(IntPtr address, Color value)
        {
            WriteRaw(address, value);
        }
        #endregion
    }
}
