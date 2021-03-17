using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotNetRogueLootAPI.Models
{
    public class Effect
    {
        public Effect(string effectName, string weaponNameFix, double bonusDamage, double bonusHealing, double extraHits)
        {
            EffectName = effectName;
            WeaponNameFix = weaponNameFix;
            BonusDamage = bonusDamage;
            BonusHealing = bonusHealing;
            ExtraHits = extraHits;
        }

        public string EffectName { get; private set; }
        public string WeaponNameFix { get; private set; }
        public double BonusDamage { get; private set; }
        public double BonusHealing { get; private set; }
        public double ExtraHits { get; private set; }
    }
}
