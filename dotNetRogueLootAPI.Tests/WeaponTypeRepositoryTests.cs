using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using dotNetRogueLootAPI.Models;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace dotNetRogueLootAPI.Tests
{
    public class WeaponTypeRepositoryTests
    {
        private readonly DbContextOptions<AppDbContext> _dbContextOptions;

        public WeaponTypeRepositoryTests()
        {
            _dbContextOptions = new DbContextOptionsBuilder<AppDbContext>().UseInMemoryDatabase("dotNetRogue_WeaponTypeTests").Options;
        }

        [Theory]
        [InlineData(4)]
        public async Task GettingAllTypes_ReturnsList(int expected)
        {
            await using var dbContext = new AppDbContext(_dbContextOptions);
            await dbContext.Database.EnsureDeletedAsync();

            dbContext.WeaponTypes.AddRange(new List<WeaponType>()
            {
                new WeaponType("Battleaxe", 35, 1),
                new WeaponType("Bow", 15, 20),
                new WeaponType("Greatsword", 30, 2),
                new WeaponType("Sword", 10, 10)
            });
            await dbContext.SaveChangesAsync();

            var repository = new WeaponTypeRepository(dbContext);
            var result = repository.GetAllTypes();

            Assert.Equal(expected, result.ToList().Count);
        }

        [Theory]
        [InlineData("Battleaxe", 35, 1)]
        public async void GettingWeaponTypeByName_ValidInput_ReturnsEntity(string name, int damage, int dodge)
        {
            await using var dbContext = new AppDbContext(_dbContextOptions);
            await dbContext.Database.EnsureDeletedAsync();

            dbContext.WeaponTypes.AddRange(new List<WeaponType>()
            {
                new WeaponType("Battleaxe", 35, 1),
                new WeaponType("Bow", 15, 20),
                new WeaponType("Greatsword", 30, 2),
                new WeaponType("Sword", 10, 10)
            });
            await dbContext.SaveChangesAsync();
            var repository = new WeaponTypeRepository(dbContext);

            var result = repository.GetTypeByName(name);

            Assert.NotNull(result);
            Assert.Equal(damage, result.Damage);
            Assert.Equal(dodge, result.DodgeChance);
        }

        [Theory]
        [InlineData("Gun")]
        public async void GettingWeaponTypeByName_InvalidInput_ReturnsNull(string name)
        {
            await using var dbContext = new AppDbContext(_dbContextOptions);
            await dbContext.Database.EnsureDeletedAsync();

            dbContext.WeaponTypes.AddRange(new List<WeaponType>()
            {
                new WeaponType("Battleaxe", 35, 1),
                new WeaponType("Bow", 15, 20),
                new WeaponType("Greatsword", 30, 2),
                new WeaponType("Sword", 10, 10)
            });
            await dbContext.SaveChangesAsync();
            var repository = new WeaponTypeRepository(dbContext);

            var result = repository.GetTypeByName(name);

            Assert.Null(result);
        }
    }
}
