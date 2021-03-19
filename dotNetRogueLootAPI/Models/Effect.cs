using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotNetRogueLootAPI.Models
{
    public class Effect
    {
        public Effect(string effectName, string weaponNameFix, int bonusDamage, int bonusHealing, int extraHits)
        {
            EffectName = effectName;
            WeaponNameFix = weaponNameFix;
            BonusDamage = bonusDamage;
            BonusHealing = bonusHealing;
            ExtraHits = extraHits;
        }

        public string EffectName { get; private set; }
        public string WeaponNameFix { get; private set; }
        public int BonusDamage { get; private set; }
        public int BonusHealing { get; private set; }
        public int ExtraHits { get; private set; }
    }
}
