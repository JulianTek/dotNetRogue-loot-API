using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using dotNetRogueLootAPI.Domain.Models;
using dotNetRogueLootAPI.IntegrationTests.Common;
using dotNetRogueLootAPI.Presentation;
using Xunit;

namespace dotNetRogueLootAPI.IntegrationTests
{
    public class WeaponControllerTests : IntegrationTestBase
    {
        public WeaponControllerTests(PresentationWebAppFactory<Startup> factory): base(factory)
        { }

        [Fact]
        public async Task GeneratingRandomWeapon_ReturnsOk_AndWeaponJson()
        {
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
