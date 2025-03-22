using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using ThoriumMod.Items.BasicAccessories;
using ThoriumMod.Items.Thorium;
using Unifier.Items;
using Unifier.RecipeGroups;
using ThoriumAnvil = ThoriumMod.Tiles.ThoriumAnvil;

namespace Unifier.Recipes
{
    public class ShieldRecipes : ModSystem
    {
        public override void PostAddRecipes()
        {
            // Remove the original recipes for all shields
            for (int i = 0; i < Recipe.numRecipes; i++)
            {
                Recipe recipe = Main.recipe[i];
                if (recipe.createItem.type == ModContent.ItemType<CopperBuckler>() ||
                    recipe.createItem.type == ModContent.ItemType<TinBuckler>() ||
                    recipe.createItem.type == ModContent.ItemType<IronShield>() ||
                    recipe.createItem.type == ModContent.ItemType<LeadShield>() ||
                    recipe.createItem.type == ModContent.ItemType<SilverBulwark>() ||
                    recipe.createItem.type == ModContent.ItemType<TungstenBulwark>() ||
                    recipe.createItem.type == ModContent.ItemType<GoldAegis>() ||
                    recipe.createItem.type == ModContent.ItemType<PlatinumAegis>() ||
                    recipe.createItem.type == ModContent.ItemType<ThoriumShield>())
                {
                    recipe.DisableRecipe();
                }
            }

            AddShieldRecipes();
        }

        private void AddShieldRecipes()
        {
            Recipe recipe = Recipe.Create(ModContent.ItemType<CopperBuckler>());
            recipe.AddIngredient(ItemID.CopperBar, 10);
            recipe.AddTile(TileID.Anvils);
            recipe.Register();

            recipe = Recipe.Create(ModContent.ItemType<TinBuckler>());
            recipe.AddIngredient(ItemID.TinBar, 10);
            recipe.AddTile(TileID.Anvils);
            recipe.Register();

            recipe = Recipe.Create(ModContent.ItemType<IronShield>());
            recipe.AddRecipeGroup(ShieldRecipeGroups.GetGroupNameByTier(1)); // Use any Tier 1 shield
            recipe.AddIngredient(ItemID.IronBar, 10);
            recipe.AddIngredient(ModContent.ItemType<HardenedPlanks>(), 3);
            recipe.AddTile(TileID.Anvils);
            recipe.Register();
            
            recipe = Recipe.Create(ModContent.ItemType<LeadShield>());
            recipe.AddRecipeGroup(ShieldRecipeGroups.GetGroupNameByTier(1)); // Use any Tier 1 shield
            recipe.AddIngredient(ItemID.LeadBar, 10);
            recipe.AddIngredient(ModContent.ItemType<HardenedPlanks>(), 3);
            recipe.AddTile(TileID.Anvils);
            recipe.Register();
            
            recipe = Recipe.Create(ModContent.ItemType<SilverBulwark>());
            recipe.AddRecipeGroup(ShieldRecipeGroups.GetGroupNameByTier(2)); // Use any Tier 2 shield
            recipe.AddIngredient(ItemID.SilverBar, 10);
            recipe.AddIngredient(ModContent.ItemType<PharaohBrick>(), 3);
            recipe.AddTile(TileID.TinkerersWorkbench);
            recipe.Register();
            
            recipe = Recipe.Create(ModContent.ItemType<TungstenBulwark>());
            recipe.AddRecipeGroup(ShieldRecipeGroups.GetGroupNameByTier(2)); // Use any Tier 2 shield
            recipe.AddIngredient(ItemID.TungstenBar, 10);
            recipe.AddIngredient(ModContent.ItemType<PharaohBrick>(), 3);
            recipe.AddTile(TileID.TinkerersWorkbench);
            recipe.Register();
            
            recipe = Recipe.Create(ModContent.ItemType<GoldAegis>());
            recipe.AddRecipeGroup(ShieldRecipeGroups.GetGroupNameByTier(3)); // Use any Tier 3 shield
            recipe.AddIngredient(ItemID.GoldBar, 10);
            recipe.AddIngredient(ModContent.ItemType<ViscountFur>(), 3);
            recipe.AddTile(TileID.TinkerersWorkbench);
            recipe.Register();
            
            recipe = Recipe.Create(ModContent.ItemType<PlatinumAegis>());
            recipe.AddRecipeGroup(ShieldRecipeGroups.GetGroupNameByTier(3)); // Use any Tier 3 shield
            recipe.AddIngredient(ItemID.PlatinumBar, 10);
            recipe.AddIngredient(ModContent.ItemType<ViscountFur>(), 3);
            recipe.AddTile(TileID.TinkerersWorkbench);
            recipe.Register();
            
            recipe = Recipe.Create(ModContent.ItemType<ThoriumShield>());
            recipe.AddRecipeGroup(ShieldRecipeGroups.GetGroupNameByTier(4)); // Use any Tier 4 shield
            recipe.AddIngredient(ModContent.ItemType<ThoriumBar>(), 10);
            recipe.AddIngredient(ModContent.ItemType<ChampionFragment>(), 3);
            recipe.AddTile(ModContent.TileType<ThoriumAnvil>());
            recipe.Register();
        }
    }
}
