using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotNetRogueLootAPI.Models
{
    public class EffectGenerator
    {
        private readonly Random _rnd = new Random();

        public List<Effect> GenerateEffects(int numberOfEffects, double rarityMul)
        {
            var effects = new List<Effect>();
            // The numbers here are temporary while I figure out the balancing
            for (var i = 0; i < numberOfEffects; i++)
            {
                var effect = GenerateEffect(rarityMul);
                if (ValidateEffectIsUnique(effects, effect))
                {
                    effects.Add(effect);
                }
                else
                {
                    i--;
                }
            }

            return effects;
        }

        // For now, use static values; possibly add higher base values with higher rarities
        public Effect GenerateEffect(double rarityMultiplier)
        {
            var bonusDamage = (int)Math.Round(_rnd.Next(1, 10) * rarityMultiplier);
            var extraHits = _rnd.Next(0, 3);
            var bonusHealing = (int) Math.Round(_rnd.Next(0, 10) * rarityMultiplier);
            var name = GenerateEffectName(extraHits, bonusHealing);
            return new Effect(name, GenerateEffectPrefix(name), bonusDamage, bonusHealing, extraHits);
        }

        public string GenerateEffectName(int extraHits, int bonusHeal)
        {
            if (bonusHeal != 0)
            {
                return extraHits > 0 ? "Poison Lifesteal" : "Lifesteal";
            }

            return extraHits > 0 ? "Poison" : "Powerful";
        }

        public string GenerateEffectPrefix(string effectName)
        {
            switch (effectName)
            {
                case "Poison Lifesteal":
                    return "poisonous life stealing";
                case "Lifesteal":
                    return "life stealing";
                case "Poison":
                    return "poisonous";
                case "Powerful":
                    return "powerful";
                default:
                    throw new Exception("No such effect name exists");
            }
        }

        public bool ValidateEffectIsUnique(List<Effect> effects, Effect generatedEffect)
        {
            if (effects.Count != 0)
            {
                foreach (var effect in effects)
                {
                    return effect.BonusDamage != generatedEffect.BonusDamage || effect.BonusHealing != generatedEffect.BonusHealing || effect.ExtraHits != generatedEffect.ExtraHits;
                }

                return false;
            }

            return true;
        }
    }
}
