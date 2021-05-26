using System.ComponentModel.DataAnnotations;

namespace dotNetRogueLootAPI.Domain.Models
{
    public class WeaponType
    {
        public WeaponType(string name, int damage, int dodgeChance)
        {
            Name = name;
            Damage = damage;
            DodgeChance = dodgeChance;
        }

        public WeaponType()
        {
            
        }
        
        [Key]
        public string Name { get; private set; }
        public int Damage { get; private set; }
        public int DodgeChance { get; private set; }
    }
}
