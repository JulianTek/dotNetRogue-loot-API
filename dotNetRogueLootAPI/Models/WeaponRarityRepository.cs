﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dotNetRogueLootAPI.Models.Interfaces;

namespace dotNetRogueLootAPI.Models
{
    public class WeaponRarityRepository : IWeaponRarityRepository
    {
        private readonly AppDbContext _context;

        public IEnumerable<WeaponRarity> GetAllRarities()
        {
            return _context.WeaponRarities;
        }
    }
}
