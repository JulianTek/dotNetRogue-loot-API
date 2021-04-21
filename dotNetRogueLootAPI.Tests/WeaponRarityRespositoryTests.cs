using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using dotNetRogueLootAPI.Models;
using dotNetRogueLootAPI.Models.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.InMemory;
using Moq;
using Xunit;

namespace dotNetRogueLootAPI.Tests
{
    public class WeaponRarityRespositoryTests
    {
        private readonly DbContextOptions<AppDbContext> _dbContextOptions;

        public WeaponRarityRespositoryTests()
        {
            _dbContextOptions = new DbContextOptionsBuilder<AppDbContext>().UseInMemoryDatabase("dotNetRogue_TestDb").Options;
        }

        [Fact]
        public async void GettingAllRarities_ReturnsList()
        {
            await using var dbContext = new AppDbContext(_dbContextOptions);
            await dbContext.Database.EnsureDeletedAsync();

            dbContext.WeaponRarities.AddRange(new List<WeaponRarity>()
            {
                new WeaponRarity("Common", 66, 1, 0),
                new WeaponRarity("Uncommon", 19, 1.5, 0),
                new WeaponRarity("Rare", 10, 2, 1),
                new WeaponRarity("Legendary", 4, 3.3, 2),
                new WeaponRarity("Heroic", 1, 5, 4)
            });
            await dbContext.SaveChangesAsync();
            var repository = new WeaponRarityRepository(dbContext);

            var result = repository.GetAllRarities();

            Assert.Equal(5, result.ToList().Count);
        }
    }
}
