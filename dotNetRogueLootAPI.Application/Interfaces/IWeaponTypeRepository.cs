using System.Collections.Generic;
using dotNetRogueLootAPI.Domain.Models;

namespace dotNetRogueLootAPI.Application.Interfaces
{
    public interface IWeaponTypeRepository
    {
        public IEnumerable<WeaponType> GetAllTypes();
        public WeaponType GetTypeByName(string name);
    }
}
