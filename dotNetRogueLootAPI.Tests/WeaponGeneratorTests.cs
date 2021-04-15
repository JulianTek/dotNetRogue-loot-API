using System;
using System.Collections.Generic;
using System.Text;
using dotNetRogueLootAPI.Models;
using dotNetRogueLootAPI.Models.Interfaces;
using Microsoft.EntityFrameworkCore;
using Moq;
using Xunit;

namespace dotNetRogueLootAPI.Tests
{
    public class WeaponGeneratorTests
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
        public void Generating_Price_Doesnt_Exceed_Minimum_Or_Maximum()
        {
            SetupMock();
            WeaponManager weaponManager = new WeaponManager(RarityMock.Object, TypeMock.Object, EffectMock.Object);

            for (int i = 0; i < 1000; i++)
            {
                var weapon = weaponManager.GenerateWeapon();
                Assert.InRange(weapon.SellValue, 10, 1140);
                // The theoretical minimum and maximum prices
            }
        }

        [Fact]
        public void Generating_Attack_Doesnt_Exceed_Minimum_Or_Maximum()
        {
            SetupMock();
            WeaponManager weaponManager = new WeaponManager(RarityMock.Object, TypeMock.Object, EffectMock.Object);

            for (int i = 0; i < 1000; i++)
            {
                var weapon = weaponManager.GenerateWeapon();
                Assert.InRange(weapon.Stats["Attack"], weapon.Type.Damage - 5, (weapon.Type.Damage + 5) * 5);
            }
        }

        [Fact]
        public void Generating_Dodge_Doesnt_Exceed_Minimum_Or_Maximum()
        {
            SetupMock();
            WeaponManager weaponManager = new WeaponManager(RarityMock.Object, TypeMock.Object, EffectMock.Object);

            for (int i = 0; i < 1000; i++)
            {
                var weapon = weaponManager.GenerateWeapon();
                if (weapon.Stats["Dodge"] != 0)
                {
                    Assert.InRange(weapon.Stats["Dodge"], weapon.Type.DodgeChance - 5, (weapon.Type.DodgeChance + 3) * 5);
                }

            }
        }

        [Fact]
        public void Generating_Speed_Doesnt_Exceed_Minimum_Or_Maximum()
        {
            SetupMock();
            WeaponManager weaponManager = new WeaponManager(RarityMock.Object, TypeMock.Object, EffectMock.Object);

            for (int i = 0; i < 1000; i++)
            {
                var weapon = weaponManager.GenerateWeapon();
                Assert.InRange(weapon.Stats["Speed"], 10, 28);
            }
        }

        [Fact]
        public void Generating_Defense_Doesnt_Exceed_Minimum_Or_Maximum()
        {
            SetupMock();
            WeaponManager weaponManager = new WeaponManager(RarityMock.Object, TypeMock.Object, EffectMock.Object);

            for (int i = 0; i < 1000; i++)
            {
                var weapon = weaponManager.GenerateWeapon();
                Assert.InRange(weapon.Stats["Defense"], 1, 50);
            }
        }

        [Fact]
        public void Generating_Coolness_Doesnt_Exceed_Minimum_Or_Maximum()
        {
            SetupMock();
            WeaponManager weaponManager = new WeaponManager(RarityMock.Object, TypeMock.Object, EffectMock.Object);

            for (int i = 0; i < 1000; i++)
            {
                var weapon = weaponManager.GenerateWeapon();
                Assert.InRange(weapon.Stats["Coolness"], 1, 3);
            }
        }
    }
}
