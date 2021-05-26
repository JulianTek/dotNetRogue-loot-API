using System.Collections.Generic;
using dotNetRogueLootAPI.Application.Interfaces;
using dotNetRogueLootAPI.Domain.Models;

namespace dotNetRogueLootAPI.Application.Repositories
{
    public class WeaponTypeRepository : IWeaponTypeRepository
    {
        public WeaponTypeRepository(IAppDbContext context)
        {
            _context = context;
        }
        private readonly IAppDbContext _context;

        public IEnumerable<WeaponType> GetAllTypes()
        {
            return _context.WeaponTypes;
        }

        public WeaponType GetTypeByName(string name)
        {
            if (_context.WeaponTypes.Find(name) != null)
            {
                return _context.WeaponTypes.Find(name);
            }

            return null;
        }
    }
}
