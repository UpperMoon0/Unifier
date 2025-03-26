using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.DataStructures;
using System.Collections.Generic;
using Unifier.Models;
using Unifier.Builders;

namespace Unifier.Items.GlobalItems
{
    public class WoodArmorChanges : ArmorChanges
    {
        protected override ArmorConfigBuilder SetupArmorConfig(ArmorConfigBuilder builder)
        {
            return builder
                // Helmet configuration
                .WithHelmet(ItemID.WoodHelmet)
                .WithHelmetEffects(player => player.statDefense += 2)
                .WithHelmetTooltips("+5% ranged critical strike chance", "+2 defense")
                
                // Chestplate configuration
                .WithChestplate(ItemID.WoodBreastplate)
                .WithChestplateEffects(player => player.endurance += 0.02f)
                .WithChestplateTooltips("+10% ranged damage", "2% damage reduction")
                
                // Leggings configuration
                .WithLeggings(ItemID.WoodGreaves)
                .WithLeggingsEffects(player => player.moveSpeed += 0.1f)
                .WithLeggingsTooltips("+15% knockback", "+10% movement speed")
                
                // Set bonus configuration
                .WithSetEffects(player => {
                    player.GetDamage(DamageClass.Ranged) += 0.05f;
                    player.GetCritChance(DamageClass.Ranged) += 3f;
                })
                .WithAmmoConservationChance(0.15f)
                .WithSetBonusDescription("5% increased ranged damage, 3% increased ranged critical strike chance, 15% increased critical damage, and 15% chance not to consume ammo")
                
                // Damage type effects
                .WithDamageTypeEffect(
                    DamageClass.Ranged,
                    damageMultiplier: 0.1f,
                    critChanceBonus: 5f,
                    critDamageBonus: 0.15f,
                    knockbackMultiplier: 0.15f,
                    requiredPieces: ArmorPiece.Helmet | ArmorPiece.Chestplate
                );
        }
    }
}
