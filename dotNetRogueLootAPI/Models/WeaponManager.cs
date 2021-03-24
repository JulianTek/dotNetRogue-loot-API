using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dotNetRogueLootAPI.Models.Interfaces;

namespace dotNetRogueLootAPI.Models
{
    public class WeaponManager
    {
        public WeaponManager(IWeaponRarityRepository rarity, IWeaponTypeRepository type)
        {
            _rarities = rarity.GetAllRarities().ToList();
            _types = type.GetAllTypes().ToList();
        }

        private readonly Random _rnd = new Random();
        private readonly EffectGenerator _effectGenerator = new EffectGenerator();
        private readonly List<WeaponRarity> _rarities;

        private readonly List<WeaponType> _types;

        public Weapon GenerateWeapon()
        {
            WeaponType type = GenerateWeaponType();
            WeaponRarity rarity = GenerateRarity();
            return new Weapon("test", GenerateStats(type), rarity, _effectGenerator.GenerateEffects(rarity.AmountOfEffects, rarity.StatModMul));
        }

        public WeaponRarity GenerateRarity()
        {
            // Converting it to a list will make tweaking values a lot easier, since I won't have to make any changes here
            var rarityChances = _rarities.Select(rarity => rarity.AppearChance).ToList();

            var rarityNum = _rnd.Next(1, 101);

            if (rarityNum <= rarityChances[0])
            {
                return _rarities[0];
            }
            if (rarityNum <= rarityChances[1])
            {
                return _rarities[1];
            }
            if (rarityNum <= rarityChances[2])
            {
                return _rarities[2];
            }
            if (rarityNum <= rarityChances[3])
            {
                return _rarities[3];
            }

            return _rarities[4];
        }

        public WeaponType GenerateWeaponType()
        {
            return _types[_rnd.Next(0, 5)];
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
