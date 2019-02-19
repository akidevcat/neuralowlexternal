using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeuralOwl.Back.CsgoExternal.Game
{
    public class Weapon : Entity
    {
        public Weapons WeaponID { get => (Weapons)ReadShort(Netvars.m_iItemDefinitionIndex); }

        public Weapon(IntPtr address, MemoryReader reader, int memorySize = CsgoStructs.szWeapon) : base(address, reader, memorySize) { }
    }
}
