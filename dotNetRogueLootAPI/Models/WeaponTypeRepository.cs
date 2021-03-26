using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dotNetRogueLootAPI.Models.Interfaces;

namespace dotNetRogueLootAPI.Models
{
    public class WeaponTypeRepository : IWeaponTypeRepository
    {
        public WeaponTypeRepository(AppDbContext context)
        {
            _context = context;
        }
        private readonly AppDbContext _context;

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
