using CalamityMod.Items.Materials;
using CalamityMod.Items.Placeables;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using ThoriumMod.Items.BasicAccessories;
using ThoriumMod.Items.Depths;
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
            Recipe recipe = Recipe.Create(ModContent.ItemType<PharaohBrick>(), 8);
            recipe.AddIngredient(ModContent.ItemType<PharaohBrick>(), 1);
            recipe.AddIngredient(ItemID.Sandstone, 20);
            recipe.AddIngredient(ItemID.Sapphire, 2);
            recipe.AddTile(TileID.Furnaces);
            recipe.Register();

            recipe = Recipe.Create(ModContent.ItemType<PharaohBrick>(), 24);
            recipe.AddIngredient(ModContent.ItemType<PharaohBrick>(), 1);
            recipe.AddIngredient(ItemID.AncientBattleArmorMaterial, 1);
            recipe.AddIngredient(ModContent.ItemType<AerialiteBar>(), 1);
            recipe.AddTile(TileID.AdamantiteForge);
            recipe.Register();

            recipe = Recipe.Create(ModContent.ItemType<Aquaite>(), 64);
            recipe.AddIngredient(ModContent.ItemType<Aquaite>(), 8);
            recipe.AddIngredient(ModContent.ItemType<SeaPrism>(), 3);
            recipe.AddIngredient(ModContent.ItemType<BaronFin>(), 1);
            recipe.AddTile(TileID.AdamantiteForge);
            recipe.Register();
        }
    }
}
