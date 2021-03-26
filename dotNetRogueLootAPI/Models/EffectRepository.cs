using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dotNetRogueLootAPI.Models.Interfaces;

namespace dotNetRogueLootAPI.Models
{
    public class EffectRepository : IEffectRepository
    {
        private readonly AppDbContext _context;
        public EffectRepository(AppDbContext context)
        {
            _context = context;
        }

        public Effect GetEffectByName(string name)
        {
            return _context.Effects.Find(name);
        }

        public IEnumerable<Effect> GetEffects()
        {
            return _context.Effects;
        }

        public IEnumerable<string> GetEffectNames()
        {
            return _context.Effects.Select(x => x.EffectName);
        }
    }
}
