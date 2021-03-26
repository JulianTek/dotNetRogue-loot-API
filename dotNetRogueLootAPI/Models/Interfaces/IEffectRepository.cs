using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotNetRogueLootAPI.Models.Interfaces
{
    public interface IEffectRepository
    {
        public Effect GetEffectByName(string name);
        public IEnumerable<Effect> GetEffects();
        public IEnumerable<string> GetEffectNames();
    }
}
