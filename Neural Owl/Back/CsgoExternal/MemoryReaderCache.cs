using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeuralOwl.Back.CsgoExternal
{
    public class ProcessMemoryCell
    {
        public IntPtr Address { get; private set; }
        public byte[] Value { get; private set; }

        public ProcessMemoryCell(IntPtr address, byte[] value)
        {
            this.Address = address;
            this.Value = value;
        }
        public void Write(IntPtr address, byte[] value)
        {
            this.Address = address;
            this.Value = value;
        }
    }

    public class MemoryReaderCache
    {
        #region Const
        private const int Const_ProcessMemoryCacheSize = 4096;
        #endregion

        private uint tick;
        private ProcessMemoryCell[] processCachedMemory;

        public MemoryReaderCache()
        {
            processCachedMemory = new ProcessMemoryCell[Const_ProcessMemoryCacheSize];
        }

        public void Update ()
        {
            if (tick == uint.MaxValue)
                tick = 0;
            else
                tick++;

            Array.Clear(processCachedMemory, 0, processCachedMemory.Length);
        }

        public void AddValue(IntPtr address, byte[] value)
        {
            if (processCachedMemory == null || address == IntPtr.Zero)
                return;
            for (int c = 0; c < processCachedMemory.Length; c++)
            {
                if (processCachedMemory[c] != null && processCachedMemory[c]?.Address != address)
                    continue;
                
                processCachedMemory[c] = new ProcessMemoryCell(address, value);
                return;
            }
            throw new OutOfMemoryReaderCacheOwlException();
        }
        public byte[] GetValue(IntPtr address)
        {
            if (address == IntPtr.Zero)
                return new byte[0];

            foreach (var cell in processCachedMemory)
            {
                if (cell != null && cell.Address == address)
                    return cell.Value;
            }
            return null;
        }
    }
}
