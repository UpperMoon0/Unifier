using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;
using ThoriumMod.Items.BasicAccessories;

namespace Unifier.RecipeGroups
{
    public class ShieldRecipeGroups : ModSystem
    {
        public static RecipeGroup Tier1Shields;
        public static RecipeGroup Tier2Shields;
        public static RecipeGroup Tier3Shields;
        public static RecipeGroup Tier4Shields;
        
        public static string GetGroupNameByTier(int tier)
        {
            return $"Unifier:Tier{tier}Shield";
        }

        public override void AddRecipeGroups()
        {
            // Make sure Thorium mod is loaded
            if (!ModLoader.HasMod("ThoriumMod"))
                return;

            // Tier 1: Copper and Tin Bucklers
            Tier1Shields = new RecipeGroup(
                () => $"{Language.GetTextValue("LegacyMisc.37")} Tier 1 Shield",
                new int[]
                {
                    ModContent.ItemType<CopperBuckler>(),
                    ModContent.ItemType<TinBuckler>()
                }
            );
            RecipeGroup.RegisterGroup(GetGroupNameByTier(1), Tier1Shields);

            // Tier 2: Iron and Lead Shields
            Tier2Shields = new RecipeGroup(
                () => $"{Language.GetTextValue("LegacyMisc.37")} Tier 2 Shield",
                new int[]
                {
                    ModContent.ItemType<IronShield>(),
                    ModContent.ItemType<LeadShield>()
                }
            );
            RecipeGroup.RegisterGroup(GetGroupNameByTier(2), Tier2Shields);

            // Tier 3: Silver and Tungsten Bulwarks
            Tier3Shields = new RecipeGroup(
                () => $"{Language.GetTextValue("LegacyMisc.37")} Tier 3 Shield",
                new int[]
                {
                    ModContent.ItemType<SilverBulwark>(),
                    ModContent.ItemType<TungstenBulwark>()
                }
            );
            RecipeGroup.RegisterGroup(GetGroupNameByTier(3), Tier3Shields);

            // Tier 4: Gold and Platinum Aegises
            Tier4Shields = new RecipeGroup(
                () => $"{Language.GetTextValue("LegacyMisc.37")} Tier 4 Shield",
                new int[]
                {
                    ModContent.ItemType<GoldAegis>(),
                    ModContent.ItemType<PlatinumAegis>()
                }
            );
            RecipeGroup.RegisterGroup(GetGroupNameByTier(4), Tier4Shields);
        }
    }
}
