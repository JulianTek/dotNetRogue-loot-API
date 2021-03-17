using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotNetRogueLootAPI.Models
{
    public class WeaponManager
    {
        private readonly Random _rnd = new Random();
        private EffectGenerator _effectGenerator = new EffectGenerator();
        private List<WeaponRarity> rarities = new List<WeaponRarity>()
        {
            new WeaponRarity("Common", 66, 1, 0),
            new WeaponRarity("Uncommon", 19, 1.5, 0),
            new WeaponRarity("Rare", 10, 2, 1),
            new WeaponRarity("Legendary", 4, 3.3, 2),
            new WeaponRarity("Mythical", 1, 5, 4)
        };

        private List<WeaponType> types = new List<WeaponType>()
        {
            new WeaponType("Sword", 10, 10),
            new WeaponType("Greatsword", 30, 2),
            new WeaponType("Bow", 15, 20),
            new WeaponType("Crossbow", 25,15),
            new WeaponType("Battleaxe", 35, 1)
        };

        public Weapon GenerateWeapon()
        {
            WeaponType type = GenerateWeaponType();
            WeaponRarity rarity = GenerateRarity();
            return new Weapon("test", GenerateStats(type), rarity, _effectGenerator.GenerateEffects(rarity.AmountOfEffects, rarity.StatModMul));
        }

        public WeaponRarity GenerateRarity()
        {
            int rarityNum = _rnd.Next(1, 101);

            if (rarityNum <= 66)
            {
                return this.rarities[0];
            }
            else if (rarityNum <= 85)
            {
                return rarities[1];
            }
            else if (rarityNum <= 95)
            {
                return rarities[2];
            }
            else if (rarityNum <= 99)
            {
                return rarities[3];
            }

            return rarities[4];
        }

        public WeaponType GenerateWeaponType()
        {
            return types[_rnd.Next(0, 5)];
        }

        public Dictionary<string, double> GenerateStats(WeaponType type)
        {
            Dictionary<string, double> stats = new Dictionary<string, double>()
            {
                {"Attack", type.Damage + _rnd.Next(-5, 6) },
                {"Dodge", type.DodgeChance + _rnd.Next(-5, 4) }
            };
            return stats;
        }
    }
}
