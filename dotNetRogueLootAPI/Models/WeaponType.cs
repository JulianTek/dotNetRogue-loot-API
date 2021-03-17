using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotNetRogueLootAPI.Models
{
    public class WeaponType
    {
        public WeaponType(string name, int damage, int dodgeChance)
        {
            Name = name;
            Damage = damage;
            DodgeChance = dodgeChance;
        }
        
        public string Name { get; private set; }
        public int Damage { get; private set; }
        public int DodgeChance { get; private set; }
    }
}
