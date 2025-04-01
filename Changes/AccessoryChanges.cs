using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using ThoriumMod.Items.BasicAccessories;
using ThoriumMod.Items.Thorium;
using ThoriumMod.Utilities;

namespace Unifier.Changes
{
    public class AccessoryChanges : GlobalItem
    {
        // Dictionary to store shield stats: <ItemType, (Defense, ShieldValue)>
        private static Dictionary<int, (int Defense, int ShieldValue)> shieldStats;
        
        // Initialize the shield stats dictionary in OnLoad
        public override void Load()
        {
            shieldStats = new Dictionary<int, (int Defense, int ShieldValue)>();
            
            // Only populate after ThoriumMod is confirmed loaded
            if (ModLoader.TryGetMod("ThoriumMod", out Mod _))
            {
                shieldStats[ModContent.ItemType<CopperBuckler>()] = (2, 8);
                shieldStats[ModContent.ItemType<TinBuckler>()] = (2, 9);
                shieldStats[ModContent.ItemType<IronShield>()] = (3, 13);
                shieldStats[ModContent.ItemType<LeadShield>()] = (3, 14);
                shieldStats[ModContent.ItemType<SilverBulwark>()] = (4, 17);
                shieldStats[ModContent.ItemType<TungstenBulwark>()] = (4, 18);
                shieldStats[ModContent.ItemType<GoldAegis>()] = (5, 22);
                shieldStats[ModContent.ItemType<PlatinumAegis>()] = (5, 23);
                shieldStats[ModContent.ItemType<ThoriumShield>()] = (6, 32);
                shieldStats[ItemID.ObsidianShield] = (8, 40);
                shieldStats[ItemID.AnkhShield] = (10, 50);
            }
        }

        public override void UpdateAccessory(Item item, Player player, bool hideVisual)
        {
            if (item.type == ModContent.ItemType<CopperBuckler>() 
                || item.type == ModContent.ItemType<TinBuckler>())
            {
                player.statDefense += 1;
            }

            if (item.type == ModContent.ItemType<IronShield>()
                || item.type == ModContent.ItemType<LeadShield>())
            {
                player.statDefense += 2;
                player.GetThoriumPlayer().MetalShieldMax += 3;
            }

            if (item.type == ModContent.ItemType<SilverBulwark>()
                || item.type == ModContent.ItemType<TungstenBulwark>())
            {
                player.statDefense += 2;
                player.GetThoriumPlayer().MetalShieldMax += 5;
            }

            if (item.type == ModContent.ItemType<GoldAegis>()
                || item.type == ModContent.ItemType<PlatinumAegis>())
            {
                player.statDefense += 3;
                player.GetThoriumPlayer().MetalShieldMax += 11;
            }

            if (item.type == ModContent.ItemType<ThoriumShield>())
            {
                player.statDefense += 3;
                player.GetThoriumPlayer().MetalShieldMax += 16;
            }

            if (item.type == ItemID.ObsidianShield)
            {
                player.statDefense += 2;
                player.GetThoriumPlayer().MetalShieldMax += 40;
            }

            if (item.type == ItemID.AnkhShield)
            {
                player.statDefense += 2;
                player.GetThoriumPlayer().MetalShieldMax += 50;
            }
        }

        public override void ModifyTooltips(Item item, List<TooltipLine> tooltips)
        {
            // Check if this item is one of our modified shields
            if (shieldStats != null && shieldStats.TryGetValue(item.type, out var stats))
            {
                // Clear all existing tooltips line from the 3rd line
                for (int i = tooltips.Count - 1; i >= 2; i--)
                {
                    tooltips.RemoveAt(i);
                }
                
                // Add standard shield tooltips
                tooltips.Add(new TooltipLine(Mod, "Equipable", "Equipable"));
                tooltips.Add(new TooltipLine(Mod, "Defense", $"{stats.Defense} defense"));
                
                // Add shield value tooltip
                tooltips.Add(new TooltipLine(Mod, "ShieldValue", $"You constantly generate a {stats.ShieldValue} life shield"));
                
                // Add obsidian shield specific tooltip
                if (item.type == ItemID.ObsidianShield)
                {
                    tooltips.Add(new TooltipLine(Mod, "Immunity", "Grants immunity to knockback"));
                    tooltips.Add(new TooltipLine(Mod, "Immunity", "Grants immunity to the Burning and On Fire! debuffs"));
                }

                // Add ankh shield specific tooltip
                if (item.type == ItemID.AnkhShield)
                {
                    tooltips.Add(new TooltipLine(Mod, "Immunity", "Grants immunity to knockback, the Burning and On Fire! debuffs"));
                    tooltips.Add(new TooltipLine(Mod, "Immunity", "Grants immunity to most debuffs, including the Mighty Wind"));
                }

                tooltips.Add(new TooltipLine(Mod, "Material", "Material"));
            }
        }
    }
}
