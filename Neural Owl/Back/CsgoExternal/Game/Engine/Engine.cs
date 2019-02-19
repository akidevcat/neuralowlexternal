using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeuralOwl.Back.CsgoExternal.Game
{
    public class Engine : CsgoBehaviour
    {

        public Engine(IntPtr address, MemoryReader reader) : base(address, reader) { }

        public ClientState GetClientState() => new ClientState(reader.ReadIntPtr(address + Signatures.dwClientState), reader);
    }
}
