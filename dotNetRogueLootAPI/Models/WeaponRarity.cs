﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace dotNetRogueLootAPI.Models
{
    public class WeaponRarity
    {
        public WeaponRarity()
        {
            
        }
        public WeaponRarity(string name, int appearChance, double statModMul, int amountOfEffects)
        {
            RarityName = name;
            AppearChance = appearChance;
            StatModMul = statModMul;
            AmountOfEffects = amountOfEffects;
        }
        [Key]
        public string RarityName { get; private set; }
        public int AppearChance { get; private set; }
        public double StatModMul { get; private set; }
        public int AmountOfEffects { get; private set; }
    }
}
