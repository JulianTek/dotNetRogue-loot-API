using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dotNetRogueLootAPI.Models;
using dotNetRogueLootAPI.Models.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace dotNetRogueLootAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeaponController : ControllerBase
    {

        public WeaponController(IWeaponRarityRepository rarity, IWeaponTypeRepository type, IEffectRepository effect)
        {
            _weaponManager = new WeaponManager(rarity, type, effect);
        }
        private readonly WeaponManager _weaponManager;

        public Weapon GenerateRandomWeapon()
        {
            return _weaponManager.GenerateWeapon();
        }
    }
}
