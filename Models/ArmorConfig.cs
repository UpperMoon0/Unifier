using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ModLoader;

namespace Unifier.Models
{
    // Armor configuration class to store all armor settings
    public class ArmorConfig
    {
        // Identification
        public Func<int, bool> IsHelmet { get; internal set; }
        public Func<int, bool> IsChestplate { get; internal set; }
        public Func<int, bool> IsLeggings { get; internal set; }
        
        // Effects
        public Action<Player> ApplyHelmetEffects { get; internal set; }
        public Action<Player> ApplyChestplateEffects { get; internal set; }
        public Action<Player> ApplyLeggingsEffects { get; internal set; }
        public Action<Player> ApplySetEffects { get; internal set; }
        
        // Tooltips
        public List<string> HelmetTooltips { get; internal set; }
        public List<string> ChestplateTooltips { get; internal set; }
        public List<string> LeggingsTooltips { get; internal set; }
        public string SetBonusDescription { get; internal set; }
        
        // Set bonuses
        public float AmmoConservationChance { get; internal set; }
        
        // Damage type effects
        public Dictionary<DamageClass, DamageTypeEffect> DamageTypeEffects { get; internal set; } = new Dictionary<DamageClass, DamageTypeEffect>();
        
        public bool IsArmorPiece(int itemType)
        {
            return IsHelmet(itemType) || IsChestplate(itemType) || IsLeggings(itemType);
        }
    }
}