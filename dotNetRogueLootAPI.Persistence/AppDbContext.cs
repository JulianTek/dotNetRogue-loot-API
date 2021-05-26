using dotNetRogueLootAPI.Application.Interfaces;
using dotNetRogueLootAPI.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace dotNetRogueLootAPI.Persistence
{
    public class AppDbContext : DbContext, IAppDbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {

        }

        public DbSet<WeaponType> WeaponTypes { get; set; }
        public DbSet<WeaponRarity> WeaponRarities { get; set; }
        public DbSet<Effect> Effects { get; set; }
    }
}
