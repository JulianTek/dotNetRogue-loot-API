using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dotNetRogueLootAPI.Models;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace dotNetRogueLootAPI.Tests
{
    public class EffectRepositoryTests
    {
        private readonly DbContextOptions<AppDbContext> _dbContextOptions;

        public EffectRepositoryTests()
        {
            _dbContextOptions = new DbContextOptionsBuilder<AppDbContext>().UseInMemoryDatabase("dotNetRogueLocal_EffectTests").Options;
        }

        [Theory]
        [InlineData(9)]
        public async Task GetAll_ReturnsList(int expectedCount)
        {
            await using var dbContext = new AppDbContext(_dbContextOptions);
            await dbContext.Database.EnsureDeletedAsync();

            await dbContext.Effects.AddRangeAsync(new List<Effect>()
            {
                new Effect("Burn", "flaming", 1, 0, 5),
                new Effect("Burn lifesteal", "burning life stealing", 1, 1, 5),
                new Effect("Destructive", "destructive", 6, 0, 2),
                new Effect("Healing", "healing", 0, 5, 0),
                new Effect("Lifesteal", "life stealing", 3, 3, 0),
                new Effect("Lightning", "shocking", 6, 0, 2),
                new Effect("Poison", "poisonous", 5, 0, 1),
                new Effect("Poison lifesteal", "poisonous life stealing", 5, 5, 2),
                new Effect("Powerful", "powerful", 5, 5, 0)
            });
            await dbContext.SaveChangesAsync();
            var repository = new EffectRepository(dbContext);

            var result = repository.GetEffects();

            Assert.Equal(expectedCount, result.ToList().Count);
        }

        [Theory]
        [InlineData(9)]
        public async Task GetAllNames_ReturnsList(int expectedCount)
        {
            await using var dbContext = new AppDbContext(_dbContextOptions);
            await dbContext.Database.EnsureDeletedAsync();

            await dbContext.Effects.AddRangeAsync(new List<Effect>()
            {
                new Effect("Burn", "flaming", 1, 0, 5),
                new Effect("Burn lifesteal", "burning life stealing", 1, 1, 5),
                new Effect("Destructive", "destructive", 6, 0, 2),
                new Effect("Healing", "healing", 0, 5, 0),
                new Effect("Lifesteal", "life stealing", 3, 3, 0),
                new Effect("Lightning", "shocking", 6, 0, 2),
                new Effect("Poison", "poisonous", 5, 0, 1),
                new Effect("Poison lifesteal", "poisonous life stealing", 5, 5, 2),
                new Effect("Powerful", "powerful", 5, 5, 0)
            });
            await dbContext.SaveChangesAsync();
            var repository = new EffectRepository(dbContext);

            var result = repository.GetEffectNames();

            Assert.Equal(expectedCount, result.ToList().Count);
        }

        [Theory]
        [InlineData("Burn", "flaming", 1, 0, 5)]
        public async Task GetEffect_ValidInput_ReturnsEntity(string name, string prefix, int bonusDmg, int bonusHeal, int extraHit)
        {
            await using var dbContext = new AppDbContext(_dbContextOptions);
            await dbContext.Database.EnsureDeletedAsync();

            await dbContext.Effects.AddRangeAsync(new List<Effect>()
            {
                new Effect("Burn", "flaming", 1, 0, 5),
                new Effect("Burn lifesteal", "burning life stealing", 1, 1, 5),
                new Effect("Destructive", "destructive", 6, 0, 2),
                new Effect("Healing", "healing", 0, 5, 0),
                new Effect("Lifesteal", "life stealing", 3, 3, 0),
                new Effect("Lightning", "shocking", 6, 0, 2),
                new Effect("Poison", "poisonous", 5, 0, 1),
                new Effect("Poison lifesteal", "poisonous life stealing", 5, 5, 2),
                new Effect("Powerful", "powerful", 5, 5, 0)
            });
            await dbContext.SaveChangesAsync();
            var repository = new EffectRepository(dbContext);

            var result = repository.GetEffectByName(name);

            Assert.NotNull(result);
            Assert.Equal(name, result.EffectName);
            Assert.Equal(prefix, result.WeaponNameFix);
            Assert.Equal(bonusDmg, result.BonusDamage);
            Assert.Equal(bonusHeal, result.BonusHealing);
            Assert.Equal(extraHit, result.ExtraHits);
        }

        [Theory]
        [InlineData("Loud")]
        public async Task GetEffect_InvalidInput_ReturnsNull(string name)
        {
            await using var dbContext = new AppDbContext(_dbContextOptions);
            await dbContext.Database.EnsureDeletedAsync();

            await dbContext.Effects.AddRangeAsync(new List<Effect>()
            {
                new Effect("Burn", "flaming", 1, 0, 5),
                new Effect("Burn lifesteal", "burning life stealing", 1, 1, 5),
                new Effect("Destructive", "destructive", 6, 0, 2),
                new Effect("Healing", "healing", 0, 5, 0),
                new Effect("Lifesteal", "life stealing", 3, 3, 0),
                new Effect("Lightning", "shocking", 6, 0, 2),
                new Effect("Poison", "poisonous", 5, 0, 1),
                new Effect("Poison lifesteal", "poisonous life stealing", 5, 5, 2),
                new Effect("Powerful", "powerful", 5, 5, 0)
            });
            await dbContext.SaveChangesAsync();
            var repository = new EffectRepository(dbContext);

            var result = repository.GetEffectByName(name);

            Assert.Null(result);
        }
    }
}
