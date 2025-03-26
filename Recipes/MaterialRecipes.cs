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
    public class MaterialRecipes : ModSystem
    {
        public override void PostAddRecipes()
        {
            AddMaterialRecipes();
        }

        private void AddMaterialRecipes()
        {
            Recipe recipe = Recipe.Create(ItemID.PharaohBrick, 8);
            recipe.AddIngredient(ModContent.ItemType<PharaohBrick>(), 1);
            recipe.AddIngredient(ItemID.Sandstone, 20);
            recipe.AddIngredient(ItemID.Sapphire, 2);
            recipe.AddTile(TileID.Furnaces);
            recipe.Register();
        }
    }
}
