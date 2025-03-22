using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.DataStructures;
using System.Collections.Generic;

namespace Unifier.Items.GlobalItems
{
    public class ArmorChanges : GlobalItem
    {
        public override bool InstancePerEntity => true;

        // Check for individual Wood armor pieces
        private bool IsWearingWoodHelmet(Player player) => player.armor[0].type == ItemID.WoodHelmet;
        private bool IsWearingWoodBreastplate(Player player) => player.armor[1].type == ItemID.WoodBreastplate;
        private bool IsWearingWoodGreaves(Player player) => player.armor[2].type == ItemID.WoodGreaves;

        // Check if wearing full wood armor set
        private bool IsWearingFullWoodArmor(Player player) => 
            IsWearingWoodHelmet(player) && IsWearingWoodBreastplate(player) && IsWearingWoodGreaves(player);

        // Apply the set bonus for wood armor
        public override void UpdateEquip(Item item, Player player)
        {
            // Wood Greaves provide +10% movement speed
            if (item.type == ItemID.WoodGreaves)
            {
                player.moveSpeed += 0.1f;
            }
        }

        // Apply bonus chance not to consume ammo (part of full set bonus)
        public override bool CanConsumeAmmo(Item ammo, Item weapon, Player player)
        {
            // We keep the ammo conservation bonus as a full set bonus
            if (IsWearingFullWoodArmor(player))
            {
                // 15% chance not to consume ammo
                return Main.rand.NextFloat() >= 0.15f;
            }
            return base.CanConsumeAmmo(ammo, weapon, player);
        }

        // Update for individual armor piece effects
        public override void ModifyHitNPC(Item item, Player player, NPC target, ref NPC.HitModifiers modifiers)
        {
            if (item.DamageType == DamageClass.Ranged)
            {
                // Wood Breastplate provides +10% ranged damage
                if (IsWearingWoodBreastplate(player))
                {
                    modifiers.SourceDamage *= 1.1f;
                }
                
                // Full set provides +15% crit strike damage
                if (IsWearingFullWoodArmor(player))
                {
                    var currentCritDamage = modifiers.CritDamage;
                    float baseValue = currentCritDamage.Base;
                    float additive = currentCritDamage.Additive + 0.15f;  // Add 15% to current additive value
                    modifiers.CritDamage = new StatModifier(baseValue, additive);
                }
            }
        }

        // Also apply the bonus to projectiles (for bows, guns, etc)
        public override void ModifyShootStats(Item item, Player player, ref Vector2 position, ref Vector2 velocity, ref int type, ref int damage, ref float knockback)
        {
            if (item.DamageType == DamageClass.Ranged)
            {
                // Wood Breastplate provides +10% ranged damage
                if (IsWearingWoodBreastplate(player))
                {
                    damage = (int)(damage * 1.1f);
                }
            }
        }

        // Add critical chance bonus for Wood Helmet
        public override void ModifyWeaponCrit(Item item, Player player, ref float crit)
        {
            if (item.DamageType == DamageClass.Ranged && IsWearingWoodHelmet(player))
            {
                crit += 5f; // +5% ranged critical chance
            }
        }

        public override void ModifyTooltips(Item item, List<TooltipLine> tooltips)
        {
            // Individual armor effects
            if (item.type == ItemID.WoodHelmet)
            {
                tooltips.Add(new TooltipLine(Mod, "PrefixAccCritChange", "+5% ranged critical strike chance"));
            }
            else if (item.type == ItemID.WoodBreastplate)
            {
                tooltips.Add(new TooltipLine(Mod, "PrefixAccDamage", "+10% ranged damage"));
            }
            else if (item.type == ItemID.WoodGreaves)
            {
                tooltips.Add(new TooltipLine(Mod, "PrefixAccMoveSpeed", "+10% movement speed"));
            }
            
            // Set bonus tooltip for all pieces
            if (item.type == ItemID.WoodHelmet || item.type == ItemID.WoodBreastplate || item.type == ItemID.WoodGreaves)
            {
                tooltips.Add(new TooltipLine(Mod, "SetBonus", "Set Bonus: +15% critical strike damage and 15% chance not to consume ammo"));
            }
        }
    }
}
