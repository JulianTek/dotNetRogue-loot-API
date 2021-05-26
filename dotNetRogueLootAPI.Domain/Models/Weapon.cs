using System.Collections.Generic;

namespace dotNetRogueLootAPI.Domain.Models
{
    public class Weapon
    {
        public Weapon(string name, WeaponType type, Dictionary<string, int> stats, WeaponRarity rarity, List<Effect> effects, int sellValue)
        {
            Name = name;
            Type = type;
            Stats = stats;
            Rarity = rarity;
            Effects = effects;
            SellValue = sellValue;
        }

        public string Name { get; private set; }
        public WeaponType Type { get; private set; }
        public Dictionary<string, int> Stats { get; private set; }
        public WeaponRarity Rarity { get; private set; }
        public List<Effect> Effects { get; private set; }
        public int SellValue { get; private set; }
    }
}
