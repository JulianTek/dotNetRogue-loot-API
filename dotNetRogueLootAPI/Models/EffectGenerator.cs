using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dotNetRogueLootAPI.Models.Interfaces;

namespace dotNetRogueLootAPI.Models
{
    public class EffectGenerator
    {
        public EffectGenerator(IEffectRepository effectRepository)
        {
            _effectRepository = effectRepository;
        }
        private readonly Random _rnd = new Random();
        private readonly IEffectRepository _effectRepository;

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
            var effectList = _effectRepository.GetEffects().ToList();
            var baseEffect = effectList[_rnd.Next(0, effectList.Count)];
            var extraModifier = _rnd.Next(0, (int)Math.Round(2 * rarityMultiplier));
            var newDmg = (int) Math.Round(baseEffect.BonusDamage * rarityMultiplier) +
                         _rnd.Next(0, (int) Math.Round(extraModifier * rarityMultiplier));
            var newHealing = (int) Math.Round(baseEffect.BonusHealing * rarityMultiplier) +
                             _rnd.Next(0, (int) Math.Round(extraModifier * rarityMultiplier));
            var newExtraHits = (int) Math.Round(baseEffect.ExtraHits * rarityMultiplier) +
                               _rnd.Next(0, (int) Math.Round(extraModifier * rarityMultiplier));
            return new Effect(baseEffect.EffectName, baseEffect.WeaponNameFix, newDmg, newHealing, newExtraHits);
        }

        public bool ValidateEffectIsUnique(List<Effect> effects, Effect generatedEffect)
        {
            if (effects.Count != 0)
            {
                foreach (var effect in effects)
                {
                    if (effect.EffectName != generatedEffect.EffectName)
                    {
                        return true;
                    }

                    break;
                }

                return false;
            }

            return true;
        }
    }
}
