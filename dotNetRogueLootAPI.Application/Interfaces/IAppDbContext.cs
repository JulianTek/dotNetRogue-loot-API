using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dotNetRogueLootAPI.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace dotNetRogueLootAPI.Application.Interfaces
{
    public interface IAppDbContext : IDbContext
    {
        public DbSet<WeaponType> WeaponTypes { get; set; }
        public DbSet<WeaponRarity> WeaponRarities { get; set; }
        public DbSet<Effect> Effects { get; set; }
    }
}
