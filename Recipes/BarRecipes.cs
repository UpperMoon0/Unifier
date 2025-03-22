using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using ThoriumMod.Items.BasicAccessories;
using ThoriumMod.Items.Lodestone;
using ThoriumMod.Items.Thorium;
using Unifier.Items;
using Unifier.RecipeGroups;

namespace Unifier.Recipes
{
    public class BarRecipes : ModSystem
    {
        public override void PostAddRecipes()
        {
            // Remove the original recipes for all shields
            for (int i = 0; i < Recipe.numRecipes; i++)
            {
                Recipe recipe = Main.recipe[i];
                if (recipe.createItem.type == ItemID.DemoniteBar ||
                    recipe.createItem.type == ItemID.CrimtaneBar ||
                    recipe.createItem.type == ItemID.MeteoriteBar ||
                    recipe.createItem.type == ModContent.ItemType<LodeStoneIngot>() ||
                    recipe.createItem.type == ItemID.HellstoneBar)
                {
                    recipe.DisableRecipe();
                }
            }

            AddShieldRecipes();
        }

        private void AddShieldRecipes()
        {
            Recipe recipe = Recipe.Create(ItemID.DemoniteBar, 8);
            recipe.AddIngredient(ItemID.DemoniteOre, 24);
            recipe.AddIngredient(ModContent.ItemType<CthulhuTeeth>(), 1);
            recipe.AddTile(TileID.Furnaces);
            recipe.Register();

            recipe = Recipe.Create(ItemID.CrimtaneBar, 8);
            recipe.AddIngredient(ItemID.CrimtaneOre, 24);
            recipe.AddIngredient(ModContent.ItemType<CthulhuTeeth>(), 1);
            recipe.AddTile(TileID.Furnaces);
            recipe.Register();

            recipe = Recipe.Create(ItemID.MeteoriteBar, 8);
            recipe.AddIngredient(ItemID.Meteorite, 24);
            recipe.AddIngredient(ModContent.ItemType<MutantGlowingMushroom>(), 1);
            recipe.AddTile(TileID.Furnaces);
            recipe.Register();

            recipe = Recipe.Create(ModContent.ItemType<LodeStoneIngot>(), 8);
            recipe.AddIngredient(ItemID.Spike, 4);
            recipe.AddIngredient(ItemID.Bone, 16);
            recipe.AddIngredient(ModContent.ItemType<DeerclopsFur>(), 1);
            recipe.AddTile(TileID.Furnaces);
            recipe.Register();

            recipe = Recipe.Create(ItemID.HellstoneBar, 8);
            recipe.AddIngredient(ItemID.Hellstone, 24);
            recipe.AddIngredient(ItemID.Obsidian, 8);
            recipe.AddIngredient(ModContent.ItemType<GraniteStormCore>(), 1);
            recipe.AddTile(TileID.Furnaces);
            recipe.Register();
        }
    }
}
