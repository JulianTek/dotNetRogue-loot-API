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
            List<Effect> effects = new List<Effect>();
            // The numbers here are temporary while I figure out the balancing
            for (int i = 0; i < numberOfEffects; i++)
            {
                Effect effect = new Effect("test", "test", _rnd.Next(5, 11)*rarityMul, _rnd.Next(0, 11)*rarityMul, _rnd.Next(0,4));
                effects.Add(effect);
            }

            return effects;
        }
    }
}
