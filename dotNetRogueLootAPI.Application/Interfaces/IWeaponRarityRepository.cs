using System.Collections.Generic;
using dotNetRogueLootAPI.Domain.Models;

namespace dotNetRogueLootAPI.Application.Interfaces
{
    public interface IWeaponRarityRepository
    {
        public IEnumerable<WeaponRarity> GetAllRarities();
    }
}
