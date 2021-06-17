using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using dotNetRogueLootAPI.Domain.Models;
using dotNetRogueLootAPI.IntegrationTests.Common;
using dotNetRogueLootAPI.Presentation;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace dotNetRogueLootAPI.IntegrationTests
{
    public class WeaponControllerTests : IntegrationTestBase
    {
        public WeaponControllerTests(PresentationWebAppFactory<Startup> factory): base(factory)
        { }

        private async void GetDbContextAndFillDb()
        {
            var dbContext = GetDbContext();
            var types = new List<WeaponType>()
            {
                new WeaponType("Battleaxe", 35, 1),
                new WeaponType("Bow", 15, 20),
                new WeaponType("Greatsword", 30, 2),
                new WeaponType("Sword", 10, 10)
            };
            var rarities = new List<WeaponRarity>()
            {
                new WeaponRarity("Common", 66, 1, 0),
                new WeaponRarity("Uncommon", 19, 1.5, 0),
                new WeaponRarity("Rare", 10, 2, 1),
                new WeaponRarity("Legendary", 4, 3.3, 2),
                new WeaponRarity("Heroic", 1, 5, 4)
            };
            var effects = new List<Effect>()
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
            };
            await dbContext.WeaponTypes.AddRangeAsync(types);
            await dbContext.WeaponRarities.AddRangeAsync(rarities);
            await dbContext.Effects.AddRangeAsync(effects);
            await dbContext.SaveChangesAsync();
        }

        [Fact]
        public async Task GeneratingRandomWeapon_ReturnsOk_AndWeaponJson()
        { 
            GetDbContextAndFillDb();
            var client = CreateHttpClient();
            for (int i = 0; i < 99; i++)
            {
                var response = await client.GetAsync("/Weapon");
                var weapon = response.DeserializeAsJsonAsync<Weapon>();

                Assert.Equal(HttpStatusCode.OK, response.StatusCode);
                Assert.NotNull(weapon);
            }
        }
    }
}
