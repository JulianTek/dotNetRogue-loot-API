using System.Collections.Generic;
using dotNetRogueLootAPI.Application.Interfaces;
using dotNetRogueLootAPI.Domain.Models;

namespace dotNetRogueLootAPI.Application.Repositories
{
    public class WeaponRarityRepository : IWeaponRarityRepository
    {

        public WeaponRarityRepository(IAppDbContext context)
        {
            _context = context;
        }
        private readonly IAppDbContext _context;

        public IEnumerable<WeaponRarity> GetAllRarities()
        {
            return _context.WeaponRarities;
        }
    }
}
