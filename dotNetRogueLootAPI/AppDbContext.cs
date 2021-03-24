using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dotNetRogueLootAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace dotNetRogueLootAPI
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {

        }

        public DbSet<WeaponType> WeaponTypes { get; set; }
        public DbSet<WeaponRarity> WeaponRarities { get; set; }
    }
}
