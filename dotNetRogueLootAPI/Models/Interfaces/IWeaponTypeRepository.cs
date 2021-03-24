using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotNetRogueLootAPI.Models.Interfaces
{
    public interface IWeaponTypeRepository
    {
        public IEnumerable<WeaponType> GetAllTypes();
        public WeaponType GetTypeByName(string name);
    }
}
