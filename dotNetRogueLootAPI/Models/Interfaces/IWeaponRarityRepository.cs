using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotNetRogueLootAPI.Models.Interfaces
{
    public interface IWeaponRarityRepository
    {
        public IEnumerable<WeaponRarity> GetAllRarities();
    }
}
