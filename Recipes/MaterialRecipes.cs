using CalamityMod.Items.Materials;
using CalamityMod.Items.Placeables;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using ThoriumMod.Items.Depths;
using ThoriumMod.Items.Illumite;
using ThoriumMod.Items.Terrarium;
using Unifier.Items;

namespace Unifier.Recipes
{
    public class MaterialRecipes : ModSystem
    {
        public override void PostAddRecipes()
        {
            for (int i = 0; i < Recipe.numRecipes; i++)
            {
                Recipe recipe = Main.recipe[i];
                if (recipe.createItem.type == ModContent.ItemType<TerrariumCore>())
                {
                    recipe.DisableRecipe();
                }
            }

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

            recipe = Recipe.Create(ModContent.ItemType<TerrariumCore>(), 4);
            recipe.AddIngredient(ItemID.MeteoriteBar, 4);
            recipe.AddIngredient(ItemID.HallowedBar, 2);
            recipe.AddIngredient(ModContent.ItemType<IllumiteIngot>(), 2);
            recipe.AddIngredient(ItemID.ShroomiteBar, 2);
            recipe.AddIngredient(ItemID.SpectreBar, 2);
            recipe.AddIngredient(ModContent.ItemType<LifeAlloy>(), 1);
            recipe.AddIngredient(ModContent.ItemType<AstralBar>(), 2);
            recipe.AddTile(TileID.LunarCraftingStation);
            recipe.Register();
        }
    }
}
