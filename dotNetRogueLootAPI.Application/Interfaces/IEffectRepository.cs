using System.Collections.Generic;
using dotNetRogueLootAPI.Domain.Models;

namespace dotNetRogueLootAPI.Application.Interfaces
{
    public interface IEffectRepository
    {
        public Effect GetEffectByName(string name);
        public IEnumerable<Effect> GetEffects();
        public IEnumerable<string> GetEffectNames();
    }
}
