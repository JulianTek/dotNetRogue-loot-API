using System.Collections.Generic;
using System.Linq;
using dotNetRogueLootAPI.Application.Interfaces;
using dotNetRogueLootAPI.Domain.Models;

namespace dotNetRogueLootAPI.Application.Repositories
{
    public class EffectRepository : IEffectRepository
    {
        private readonly IAppDbContext _context;
        public EffectRepository(IAppDbContext context)
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
