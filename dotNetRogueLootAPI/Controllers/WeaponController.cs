using dotNetRogueLootAPI.Application;
using dotNetRogueLootAPI.Application.Interfaces;
using dotNetRogueLootAPI.Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace dotNetRogueLootAPI.Presentation.Controllers
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
