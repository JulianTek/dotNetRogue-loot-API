using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dotNetRogueLootAPI.Models.Interfaces;

namespace dotNetRogueLootAPI.Models
{
    public class WeaponManager
    {
        public WeaponManager(IWeaponRarityRepository rarity, IWeaponTypeRepository type, IEffectRepository effect)
        {
            _rarities = rarity.GetAllRarities().ToList();
            _types = type.GetAllTypes().ToList();
            _effectGenerator = new EffectGenerator(effect);
        }

        private readonly Random _rnd = new Random();
        private readonly EffectGenerator _effectGenerator;
        private readonly List<WeaponRarity> _rarities;

        private readonly List<WeaponType> _types;

        public Weapon GenerateWeapon()
        {
            var type = GenerateWeaponType();
            var rarity = GenerateRarity();
            var effects = _effectGenerator.GenerateEffects(rarity.AmountOfEffects, rarity.StatModMul);
            var stats = GenerateStats(type, rarity.StatModMul);
            return new Weapon(GenerateWeaponName(rarity, type, effects), type, stats, rarity,
                effects,
                GeneratePrice(stats["Coolness"], rarity.StatModMul, rarity.AmountOfEffects));
        }

        public string GenerateWeaponName(WeaponRarity rarity, WeaponType type, List<Effect> effects)
        {
            var name = $"{rarity.RarityName}";
            if (effects.Count != 0)
            {
                name = $"{name} {effects[_rnd.Next(0, effects.Count - 1)].WeaponNameFix}";
            }

            name = $"{name} {type.Name}";
            return name;
        }
        public WeaponRarity GenerateRarity()
        {
            // Converting it to a list will make tweaking values a lot easier, since I won't have to make any changes here
            var rarityChances = _rarities.Select(rarity => rarity.AppearChance).OrderBy(chance => chance).ToList();

            var rarityNum = _rnd.Next(1, 101);

            if (rarityNum <= rarityChances[0])
            {
                return _rarities[0];
            }
            if (rarityNum <= rarityChances[1] + rarityChances[0])
            {
                return _rarities[1];
            }
            if (rarityNum <= rarityChances[2] + rarityChances[1] + rarityChances[0])
            {
                return _rarities[2];
            }
            if (rarityNum <= rarityChances[3] + rarityChances[2] + rarityChances[1] + rarityChances[0])
            {
                return _rarities[3];
            }

            return _rarities[4];
        }

        public WeaponType GenerateWeaponType()
        {
            return _types[_rnd.Next(0, _types.Count - 1)];
        }

        public Dictionary<string, int> GenerateStats(WeaponType type, double raritymul)
        {
            // Defense is a number between 1 and 50, when damage calculations are run these will be seen as a percentile reduction
            // Currently still a random number, with everything getting equal chances. Eventually I want to make better rarity tied to better stats
            var stats = new Dictionary<string, int>()
            {
                {"Attack", (int)Math.Round(type.Damage + _rnd.Next(-5, 6) * raritymul) },
                {"Dodge", (int)Math.Round(type.DodgeChance + _rnd.Next(-5, 4) * raritymul) },
                {"Speed", _rnd.Next(10, 29) },
                {"Defense", _rnd.Next(1, 51)},
                {"Coolness", _rnd.Next(1, 4) }
            };
            return stats;
        }

        public int GeneratePrice(int coolness, double raritymul, int amountOfEffects)
        {
            var basePrice =(int) Math.Round(_rnd.Next(10, 20) * raritymul);
            if (amountOfEffects > 1)
            {
                var modifiedPrice = basePrice * _rnd.Next(1, amountOfEffects);
                return modifiedPrice * coolness;
            }

            return basePrice * coolness;


        }
    }
}
