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
        }

        public override void ModifyTooltips(Item item, List<TooltipLine> tooltips)
        {
            // Clear and add new tooltips for shields
            if (item.type == ModContent.ItemType<CopperBuckler>() 
                || item.type == ModContent.ItemType<TinBuckler>()
                || item.type == ModContent.ItemType<IronShield>()
                || item.type == ModContent.ItemType<LeadShield>()
                || item.type == ModContent.ItemType<SilverBulwark>()
                || item.type == ModContent.ItemType<TungstenBulwark>()
                || item.type == ModContent.ItemType<GoldAegis>()
                || item.type == ModContent.ItemType<PlatinumAegis>()
                || item.type == ModContent.ItemType<ThoriumShield>())
            {
                // Clear all existing all tooltips line from the 3rd line
                for (int i = tooltips.Count - 1; i >= 2; i--)
                {
                    tooltips.RemoveAt(i);
                }
                
                // Add specific tooltip lines for each shield type
                if (item.type == ModContent.ItemType<CopperBuckler>())
                {
                    tooltips.Add(new TooltipLine(Mod, "Defense", "2 defense"));
                    tooltips.Add(new TooltipLine(Mod, "", "You constantly generate a 8 life shield"));
                }

                if (item.type == ModContent.ItemType<TinBuckler>())
                {
                    tooltips.Add(new TooltipLine(Mod, "Defense", "2 defense"));
                    tooltips.Add(new TooltipLine(Mod, "", "You constantly generate a 9 life shield"));
                }

                if (item.type == ModContent.ItemType<IronShield>())
                {
                    tooltips.Add(new TooltipLine(Mod, "Defense", "3 defense"));
                    tooltips.Add(new TooltipLine(Mod, "", "You constantly generate a 13 life shield"));
                }

                if (item.type == ModContent.ItemType<LeadShield>())
                {
                    tooltips.Add(new TooltipLine(Mod, "Defense", "3 defense"));
                    tooltips.Add(new TooltipLine(Mod, "", "You constantly generate a 14 life shield"));
                }

                if (item.type == ModContent.ItemType<SilverBulwark>())
                {
                    tooltips.Add(new TooltipLine(Mod, "Defense", "4 defense"));
                    tooltips.Add(new TooltipLine(Mod, "", "You constantly generate a 17 life shield"));
                }

                if (item.type == ModContent.ItemType<TungstenBulwark>())
                {
                    tooltips.Add(new TooltipLine(Mod, "Defense", "4 defense"));
                    tooltips.Add(new TooltipLine(Mod, "", "You constantly generate a 18 life shield"));
                }

                if (item.type == ModContent.ItemType<GoldAegis>())
                {
                    tooltips.Add(new TooltipLine(Mod, "Defense", "5 defense"));
                    tooltips.Add(new TooltipLine(Mod, "", "You constantly generate a 22 life shield"));
                }

                if (item.type == ModContent.ItemType<PlatinumAegis>())
                {
                    tooltips.Add(new TooltipLine(Mod, "Defense", "5 defense"));
                    tooltips.Add(new TooltipLine(Mod, "", "You constantly generate a 23 life shield"));
                }

                if (item.type == ModContent.ItemType<ThoriumShield>())
                {
                    tooltips.Add(new TooltipLine(Mod, "Defense", "6 defense"));
                    tooltips.Add(new TooltipLine(Mod, "", "You constantly generate a 32 life shield"));
                }
            }
        }
    }
}
