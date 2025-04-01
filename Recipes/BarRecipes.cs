using CalamityMod.Items.Materials;
using CalamityMod.Items.Placeables.Ores;
using CalamityMod.Tiles.Furniture.CraftingStations;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using ThoriumMod.Items.ArcaneArmor;
using ThoriumMod.Items.Darksteel;
using ThoriumMod.Items.Depths;
using ThoriumMod.Items.Misc;
using Unifier.Items;

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
                    recipe.createItem.type == ModContent.ItemType<aDarksteelAlloy>() ||
                    recipe.createItem.type == ItemID.HellstoneBar ||
                    recipe.createItem.type == ModContent.ItemType<CryonicBar>() ||
                    recipe.createItem.type == ItemID.HallowedBar ||
                    recipe.createItem.type == ItemID.ChlorophyteBar ||
                    recipe.createItem.type == ItemID.ShroomiteBar ||
                    recipe.createItem.type == ItemID.SpectreBar)
                {
                    recipe.DisableRecipe();
                }
            }

            AddBarRecipes();
        }

        private void AddBarRecipes()
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

            recipe = Recipe.Create(ModContent.ItemType<aDarksteelAlloy>(), 8);
            recipe.AddIngredient(ItemID.Spike, 4);
            recipe.AddIngredient(ItemID.Bone, 16);
            recipe.AddIngredient(ModContent.ItemType<DeerclopsFur>(), 1);
            recipe.AddTile(TileID.Furnaces);
            recipe.Register();

            recipe = Recipe.Create(ModContent.ItemType<AquaiteBar>(), 12);
            recipe.AddIngredient(ModContent.ItemType<Aquaite>(), 32);
            recipe.AddIngredient(ModContent.ItemType<Aquamarine>(), 2);
            recipe.AddIngredient(ModContent.ItemType<BoreanSack>(), 1);
            recipe.AddTile(TileID.AdamantiteForge);
            recipe.Register();

            recipe = Recipe.Create(ItemID.HellstoneBar, 8);
            recipe.AddIngredient(ItemID.Hellstone, 24);
            recipe.AddIngredient(ItemID.Obsidian, 8);
            recipe.AddIngredient(ModContent.ItemType<GraniteStormCore>(), 1);
            recipe.AddTile(TileID.Furnaces);
            recipe.Register();

            recipe = Recipe.Create(ItemID.HellstoneBar, 24);
            recipe.AddIngredient(ItemID.Hellstone, 32);
            recipe.AddIngredient(ItemID.Obsidian, 6);
            recipe.AddIngredient(ModContent.ItemType<UnholyCore>(), 2);
            recipe.AddIngredient(ModContent.ItemType<GraniteStormCore>(), 1);
            recipe.AddTile(TileID.Furnaces);
            recipe.Register();

            recipe = Recipe.Create(ModContent.ItemType<StatigelBar>(), 8);
            recipe.AddIngredient(ItemID.HellstoneBar, 8);
            recipe.AddIngredient(ModContent.ItemType<PurifiedGel>(), 2);
            recipe.AddIngredient(ModContent.ItemType<GildedGel>(), 2);
            recipe.AddIngredient(ModContent.ItemType<JellyfishGel>(), 1);
            recipe.AddTile(ModContent.TileType<StaticRefiner>());
            recipe.Register();

            recipe = Recipe.Create(ModContent.ItemType<CryonicBar>(), 10);
            recipe.AddIngredient(ModContent.ItemType<AquaiteBar>(), 3);
            recipe.AddIngredient(ModContent.ItemType<AerialiteBar>(), 2);
            recipe.AddIngredient(ModContent.ItemType<CryonicOre>(), 24);
            recipe.AddIngredient(ModContent.ItemType<EssenceofEleum>(), 2);
            recipe.AddTile(TileID.AdamantiteForge);
            recipe.Register();

            recipe = Recipe.Create(ItemID.HallowedBar, 16);
            recipe.AddIngredient(ModContent.ItemType<HallowedOre>(), 40);
            recipe.AddIngredient(ItemID.GelBalloon, 10); 
            recipe.AddIngredient(ItemID.PixieDust, 6); 
            recipe.AddIngredient(ItemID.UnicornHorn, 1); 
            recipe.AddIngredient(ModContent.ItemType<PharaohBrick>(), 2);
            recipe.AddTile(TileID.AdamantiteForge);
            recipe.Register();

            recipe = Recipe.Create(ItemID.ChlorophyteBar, 16);
            recipe.AddIngredient(ItemID.ChlorophyteOre, 40); 
            recipe.AddIngredient(ModContent.ItemType<Petal>(), 8);
            recipe.AddIngredient(ItemID.BeeWax, 5); 
            recipe.AddIngredient(ModContent.ItemType<AshesofCalamity>(), 4);
            recipe.AddTile(TileID.AdamantiteForge);
            recipe.Register();

            recipe = Recipe.Create(ItemID.ShroomiteBar, 12);
            recipe.AddIngredient(ItemID.ChlorophyteBar, 8);
            recipe.AddIngredient(ItemID.GlowingMushroom, 16);
            recipe.AddIngredient(ModContent.ItemType<MutantGlowingMushroom>(), 2);
            recipe.AddTile(TileID.Autohammer);
            recipe.Register();

            recipe = Recipe.Create(ItemID.SpectreBar, 12);
            recipe.AddIngredient(ItemID.ChlorophyteBar, 8);
            recipe.AddIngredient(ItemID.Ectoplasm, 12);
            recipe.AddIngredient(ModContent.ItemType<SpiritDroplet>(), 4);
            recipe.AddIngredient(ModContent.ItemType<CoznixEye>(), 1);
            recipe.AddTile(TileID.Autohammer);
            recipe.Register();
        }
    }
}
