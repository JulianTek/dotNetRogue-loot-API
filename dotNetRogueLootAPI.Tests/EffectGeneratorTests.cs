using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using dotNetRogueLootAPI.Application;
using dotNetRogueLootAPI.Application.Interfaces;
using dotNetRogueLootAPI.Domain.Models;
using Moq;
using Xunit;

namespace dotNetRogueLootAPI.Tests
{
    public class EffectGeneratorTests
    {
        public static Mock<IWeaponRarityRepository> RarityMock = new Mock<IWeaponRarityRepository>();
        public static Mock<IWeaponTypeRepository> TypeMock = new Mock<IWeaponTypeRepository>();
        public static Mock<IEffectRepository> EffectMock = new Mock<IEffectRepository>();

        private void SetupMock()
        {
            EffectMock.Setup(x => x.GetEffects()).Returns(new List<Effect>()
            {
                new Effect("Burn", "flaming", 1, 0, 5),
                new Effect("Burn lifesteal", "burning life stealing", 1, 1 ,5),
                new Effect("Destructive", "destructive", 6, 0, 2),
                new Effect("Healing", "healing", 0, 5, 0),
                new Effect("Lifesteal", "life stealing", 3, 3, 0),
                new Effect("Lightning", "shocking", 6, 0, 2),
                new Effect("Poison", "poisonous", 5, 0, 1),
                new Effect("Poison lifesteal", "poisonous life stealing", 5, 5, 2),
                new Effect("Powerful", "powerful", 5, 5, 0)
            });

            RarityMock.Setup(x => x.GetAllRarities()).Returns(new List<WeaponRarity>()
            {
                new WeaponRarity("Common", 66, 1, 0),
                new WeaponRarity("Uncommon", 19, 1.5, 0),
                new WeaponRarity("Rare", 10, 2, 1),
                new WeaponRarity("Legendary", 4, 3.3, 2),
                new WeaponRarity("Heroic", 1, 5, 4)
            });

            TypeMock.Setup(x => x.GetAllTypes()).Returns(new List<WeaponType>()
            {
                new WeaponType("Battleaxe", 35, 1),
                new WeaponType("Bow", 15, 20),
                new WeaponType("Greatsword", 30, 2),
                new WeaponType("Sword", 10, 10)
            });
        }

        [Fact]
        public void Generated_Weapons_Will_Have_Unique_Effects()
        {
            var weapons = new List<Weapon>();
            var allEffectsAreUnique = true;
            SetupMock();
            WeaponManager weaponManager = new WeaponManager(RarityMock.Object, TypeMock.Object, EffectMock.Object);
            for (var i = 0; i < 1000; i++)
            {
                var weapon = weaponManager.GenerateWeapon();
                if (weapon.Effects.Count > 1)
                {
                    weapons.Add(weapon);
                }
                else
                {
                    i--;
                }
            }

            foreach (Weapon weapon in weapons)
            {
                Effect selectedEffect = new Effect("Test", "test", 100000, 100000, 100000);
                foreach (Effect effect in weapon.Effects)
                {
                    if (effect.EffectName == selectedEffect.EffectName)
                    {
                        allEffectsAreUnique = false;
                    }

                    selectedEffect = effect;
                }
            }

            Assert.True(allEffectsAreUnique);
        }
    }
}
