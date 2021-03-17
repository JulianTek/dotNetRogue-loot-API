using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotNetRogueLootAPI.Models
{
    public class Weapon
    {
        public Weapon(string name, Dictionary<string, double> stats, WeaponRarity rarity, List<Effect> effects)
        {
            Name = name;
            Stats = stats;
            Rarity = rarity;
            Effects = effects;
        }

        public string Name { get; private set; }
        public Dictionary<string, double> Stats { get; private set; }
        public WeaponRarity Rarity { get; private set; }
        public List<Effect> Effects { get; private set; }
        public int SellValue { get; private set; }
    }
}
