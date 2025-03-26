using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.DataStructures;
using System.Collections.Generic;
using System;
using Unifier.Models;
using Unifier.Builders;

namespace Unifier.Items.GlobalItems
{
    public abstract class ArmorChanges : GlobalItem
    {
        public override bool InstancePerEntity => true;
        
        // Core armor configuration
        protected ArmorConfig Config { get; private set; }
        
        // Constructor that sets up the armor configuration
        public ArmorChanges()
        {
            Config = SetupArmorConfig(new ArmorConfigBuilder()).Build();
        }
        
        // Abstract method for setting up the armor configuration
        protected abstract ArmorConfigBuilder SetupArmorConfig(ArmorConfigBuilder builder);
        
        // Helper methods for armor set detection
        protected bool IsWearingHelmet(Player player) => player.armor[0].type != ItemID.None && Config.IsHelmet(player.armor[0].type);
        protected bool IsWearingChestplate(Player player) => player.armor[1].type != ItemID.None && Config.IsChestplate(player.armor[1].type);
        protected bool IsWearingLeggings(Player player) => player.armor[2].type != ItemID.None && Config.IsLeggings(player.armor[2].type);
        protected bool IsWearingFullSet(Player player) => IsWearingHelmet(player) && IsWearingChestplate(player) && IsWearingLeggings(player);
        
        // Standard implementations of GlobalItem overrides
        public override void UpdateEquip(Item item, Player player)
        {
            if (!Config.IsArmorPiece(item.type)) return;
            
            if (Config.IsHelmet(item.type))
            {
                Config.ApplyHelmetEffects?.Invoke(player);
            }
            else if (Config.IsChestplate(item.type))
            {
                Config.ApplyChestplateEffects?.Invoke(player);
            }
            else if (Config.IsLeggings(item.type))
            {
                Config.ApplyLeggingsEffects?.Invoke(player);
            }
        }
        
        // Override the correct GlobalItem method signature
        public override void UpdateArmorSet(Player player, string set)
        {
            if (set == GetArmorSetName() && IsWearingFullSet(player) && Config.ApplySetEffects != null)
            {
                Config.ApplySetEffects(player);
            }
        }
        
        // Return the armor set name to match in IsArmorSet
        protected virtual string GetArmorSetName() => "CustomArmorSet";
        
        // Override IsArmorSet to identify our armor set
        public override string IsArmorSet(Item head, Item body, Item legs)
        {
            bool isHelmet = Config.IsHelmet(head.type);
            bool isChestplate = Config.IsChestplate(body.type);
            bool isLeggings = Config.IsLeggings(legs.type);
            
            if (isHelmet && isChestplate && isLeggings)
                return GetArmorSetName();
                
            return "";
        }
        
        public override bool CanConsumeAmmo(Item ammo, Item weapon, Player player)
        {
            if (IsWearingFullSet(player) && Config.AmmoConservationChance > 0f)
            {
                if (Main.rand.NextFloat() < Config.AmmoConservationChance)
                {
                    return false;
                }
            }
            return base.CanConsumeAmmo(ammo, weapon, player);
        }
        
        public override void ModifyHitNPC(Item item, Player player, NPC target, ref NPC.HitModifiers modifiers)
        {
            if (!IsAnyArmorPieceEquipped(player)) return;
            
            ArmorPiece piece = GetEquippedPieces(player);
            
            // Apply damage type specific effects
            if (Config.DamageTypeEffects.TryGetValue(item.DamageType, out var effects))
            {
                if (effects.DamageMultiplier > 0f && (piece & effects.RequiredPieces) == effects.RequiredPieces)
                {
                    modifiers.SourceDamage *= 1f + effects.DamageMultiplier;
                }
                
                if (effects.CritDamageBonus > 0f && (piece & ArmorPiece.FullSet) == ArmorPiece.FullSet)
                {
                    var currentCritDamage = modifiers.CritDamage;
                    modifiers.CritDamage = new StatModifier(currentCritDamage.Base, currentCritDamage.Additive + effects.CritDamageBonus);
                }
            }
        }
        
        public override void ModifyShootStats(Item item, Player player, ref Vector2 position, ref Vector2 velocity, ref int type, ref int damage, ref float knockback)
        {
            if (!IsAnyArmorPieceEquipped(player)) return;
            
            ArmorPiece piece = GetEquippedPieces(player);
            
            if (Config.DamageTypeEffects.TryGetValue(item.DamageType, out var effects))
            {
                if (effects.DamageMultiplier > 0f && (piece & effects.RequiredPieces) != 0)
                {
                    damage = (int)(damage * (1f + effects.DamageMultiplier));
                }
                
                if (effects.KnockbackMultiplier > 0f && (piece & effects.RequiredPieces) != 0)
                {
                    knockback *= 1f + effects.KnockbackMultiplier;
                }
            }
        }
        
        public override void ModifyWeaponCrit(Item item, Player player, ref float crit)
        {
            if (!IsAnyArmorPieceEquipped(player)) return;
            
            ArmorPiece piece = GetEquippedPieces(player);
            
            if (Config.DamageTypeEffects.TryGetValue(item.DamageType, out var effects))
            {
                if (effects.CritChanceBonus > 0f && (piece & effects.RequiredPieces) != 0)
                {
                    crit += effects.CritChanceBonus;
                }
            }
        }
        
        public override void ModifyTooltips(Item item, List<TooltipLine> tooltips)
        {
            if (!Config.IsArmorPiece(item.type)) return;
            
            // Get tooltips for this piece
            if (Config.IsHelmet(item.type))
            {
                AddTooltipsForPiece(tooltips, Config.HelmetTooltips);
            }
            else if (Config.IsChestplate(item.type))
            {
                AddTooltipsForPiece(tooltips, Config.ChestplateTooltips);
            }
            else if (Config.IsLeggings(item.type))
            {
                AddTooltipsForPiece(tooltips, Config.LeggingsTooltips);
            }
            
            // Add set bonus tooltip if appropriate
            if (Config.SetBonusDescription != null && !string.IsNullOrEmpty(Config.SetBonusDescription))
            {
                var setBonusLine = new TooltipLine(Mod, "SetBonus", "Set Bonus: " + Config.SetBonusDescription);
                setBonusLine.IsModifier = true;
                tooltips.Add(setBonusLine);
            }
        }
        
        private void AddTooltipsForPiece(List<TooltipLine> tooltips, List<string> pieceTooltips)
        {
            if (pieceTooltips == null) return;
            
            foreach (var tip in pieceTooltips)
            {
                tooltips.Add(new TooltipLine(Mod, $"ArmorEffect{Guid.NewGuid().ToString().Substring(0, 8)}", tip));
            }
        }
        
        private bool IsAnyArmorPieceEquipped(Player player)
        {
            return IsWearingHelmet(player) || IsWearingChestplate(player) || IsWearingLeggings(player);
        }
        
        private ArmorPiece GetEquippedPieces(Player player)
        {
            ArmorPiece piece = ArmorPiece.None;
            
            if (IsWearingHelmet(player))
                piece |= ArmorPiece.Helmet;
            if (IsWearingChestplate(player))
                piece |= ArmorPiece.Chestplate;
            if (IsWearingLeggings(player))
                piece |= ArmorPiece.Leggings;
                
            return piece;
        }
    }
}
