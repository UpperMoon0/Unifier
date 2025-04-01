using CalamityMod.Items.Armor.Umbraphile;
using CalamityMod.Items.Materials;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using ThoriumMod.Items.Illumite;
using ThoriumMod.Items.Lodestone;
using ThoriumMod.Items.Valadium;

namespace Unifier.Recipes
{
    public class ArmorRecipes : ModSystem
    {
        public override void PostAddRecipes()
        {
            // Remove the original recipes for all shields
            for (int i = 0; i < Recipe.numRecipes; i++)
            {
                Recipe recipe = Main.recipe[i];
                if (recipe.createItem.type == ItemID.TurtleHelmet ||
                    recipe.createItem.type == ItemID.TurtleScaleMail ||
                    recipe.createItem.type == ItemID.TurtleLeggings ||
                    recipe.createItem.type == ItemID.BeetleHelmet ||
                    recipe.createItem.type == ItemID.BeetleScaleMail ||
                    recipe.createItem.type == ItemID.BeetleShell ||
                    recipe.createItem.type == ItemID.BeetleLeggings ||
                    recipe.createItem.type == ModContent.ItemType<UmbraphileHood>() ||
                    recipe.createItem.type == ModContent.ItemType<UmbraphileRegalia>() ||
                    recipe.createItem.type == ModContent.ItemType<UmbraphileBoots>())
                {
                    recipe.DisableRecipe();
                }
            }

            AddArmorRecipes();
        }

        private void AddArmorRecipes()
        {
            Recipe recipe = Recipe.Create(ItemID.TurtleHelmet, 1);
            recipe.AddIngredient(ItemID.ChlorophyteMask, 1);
            recipe.AddIngredient(ItemID.TurtleShell, 1);
            recipe.AddIngredient(ModContent.ItemType<IllumiteIngot>(), 6);
            recipe.AddIngredient(ModContent.ItemType<TrapperBulb>(), 1);
            recipe.AddIngredient(ModContent.ItemType<LivingShard>(), 2);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.Register();

            recipe = Recipe.Create(ItemID.TurtleScaleMail, 1);
            recipe.AddIngredient(ItemID.ChlorophytePlateMail, 1);
            recipe.AddIngredient(ItemID.TurtleShell, 1);
            recipe.AddIngredient(ModContent.ItemType<IllumiteIngot>(), 12);
            recipe.AddIngredient(ModContent.ItemType<TrapperBulb>(), 2);
            recipe.AddIngredient(ModContent.ItemType<LivingShard>(), 4);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.Register();

            recipe = Recipe.Create(ItemID.TurtleLeggings, 1);
            recipe.AddIngredient(ItemID.ChlorophyteGreaves, 1);
            recipe.AddIngredient(ItemID.TurtleShell, 1);
            recipe.AddIngredient(ModContent.ItemType<IllumiteIngot>(), 8);
            recipe.AddIngredient(ModContent.ItemType<TrapperBulb>(), 1);
            recipe.AddIngredient(ModContent.ItemType<LivingShard>(), 3);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.Register();

            recipe = Recipe.Create(ItemID.BeetleHelmet, 1);
            recipe.AddIngredient(ItemID.TurtleHelmet, 1);
            recipe.AddIngredient(ItemID.BeetleHusk, 4);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.Register();

            recipe = Recipe.Create(ItemID.BeetleScaleMail, 1);
            recipe.AddIngredient(ItemID.TurtleScaleMail, 1);
            recipe.AddIngredient(ItemID.BeetleHusk, 8);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.Register();

            recipe = Recipe.Create(ItemID.BeetleShell, 1);
            recipe.AddIngredient(ItemID.TurtleScaleMail, 1);
            recipe.AddIngredient(ItemID.BeetleHusk, 8);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.Register();

            recipe = Recipe.Create(ItemID.BeetleLeggings, 1);
            recipe.AddIngredient(ItemID.TurtleLeggings, 1);
            recipe.AddIngredient(ItemID.BeetleHusk, 6);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.Register();

            recipe = Recipe.Create(ModContent.ItemType<UmbraphileHood>(), 1);
            recipe.AddIngredient(ModContent.ItemType<SolarVeil>(), 12);
            recipe.AddIngredient(ModContent.ItemType<LodeStoneIngot>(), 8);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.Register();

            recipe = Recipe.Create(ModContent.ItemType<UmbraphileRegalia>(), 1);
            recipe.AddIngredient(ModContent.ItemType<SolarVeil>(), 18);
            recipe.AddIngredient(ModContent.ItemType<LodeStoneIngot>(), 15);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.Register();

            recipe = Recipe.Create(ModContent.ItemType<UmbraphileBoots>(), 1);
            recipe.AddIngredient(ModContent.ItemType<SolarVeil>(), 14);
            recipe.AddIngredient(ModContent.ItemType<LodeStoneIngot>(), 11);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.Register();

            recipe = Recipe.Create(ModContent.ItemType<UmbraphileHood>(), 1);
            recipe.AddIngredient(ModContent.ItemType<SolarVeil>(), 12);
            recipe.AddIngredient(ModContent.ItemType<ValadiumIngot>(), 8);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.Register();

            recipe = Recipe.Create(ModContent.ItemType<UmbraphileRegalia>(), 1);
            recipe.AddIngredient(ModContent.ItemType<SolarVeil>(), 18);
            recipe.AddIngredient(ModContent.ItemType<ValadiumIngot>(), 15);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.Register();

            recipe = Recipe.Create(ModContent.ItemType<UmbraphileBoots>(), 1);
            recipe.AddIngredient(ModContent.ItemType<SolarVeil>(), 14);
            recipe.AddIngredient(ModContent.ItemType<ValadiumIngot>(), 11);
            recipe.AddTile(TileID.MythrilAnvil);
            recipe.Register();
        }
    }
}
