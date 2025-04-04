using System;
using System.Collections.Generic;
using System.Linq;
using Terraria;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace Unifier
{
    public class Unifier : Mod
    {
        // Cache the Thorium Shield item type
        public static int ThoriumShieldItemType { get; private set; } = -1;

        public override void Load()
        {
            // Mod initialization code here if needed
            Logger.Info("Unifier mod loaded. Thorium Shield modifications will be applied when Thorium loads.");
        }

        public override void PostSetupContent()
        {
            // This runs after all mods have loaded
            if (ModLoader.TryGetMod("ThoriumMod", out Mod thoriumMod))
            {
                // Get the Thorium Shield item type using the internal name
                ThoriumShieldItemType = thoriumMod.Find<ModItem>("ThoriumShield").Type;
                Logger.Info($"Found Thorium Shield with ID: {ThoriumShieldItemType}");
            }
        }
    }
    
    // Command to print biome names - direct implementation without references
    public class PrintBiomesCommand : ModCommand
    {
        public override CommandType Type => CommandType.Chat;
        
        public override string Command => "printbiomes";
        
        public override string Description => "Prints all biome names from Thorium Mod";
        
        public override void Action(CommandCaller caller, string input, string[] args)
        {
            try
            {
                Mod thoriumMod = ModLoader.GetMod("ThoriumMod");
                if (thoriumMod == null)
                {
                    Main.NewText("Thorium Mod not loaded!", Color.Red);
                    return;
                }
                
                Main.NewText("=== Thorium Biome Names ===", Color.Yellow);
                
                // Use reflection to get all ModBiome types from Thorium
                var biomeTypes = thoriumMod.Code.GetTypes()
                    .Where(t => !t.IsAbstract && t.IsSubclassOf(typeof(ModBiome)))
                    .ToList();
                
                foreach (var biomeType in biomeTypes)
                {
                    // Print the name in chat and to logs
                    string biomeName = biomeType.Name;
                    Main.NewText($"Biome: {biomeName}", Color.White);
                    Console.WriteLine($"Thorium Biome: {biomeName}");
                }
                
                Main.NewText($"Found {biomeTypes.Count} biomes in Thorium Mod", Color.Green);
            }
            catch (Exception ex)
            {
                Main.NewText("Error printing biome names: " + ex.Message, Color.Red);
                Console.WriteLine("Error printing biome names: " + ex.Message);
            }
        }
    }
    
    // Command manager system
    public class CommandManager : ModSystem
    {
        public override void PostAddRecipes()
        {
            if (ModLoader.TryGetMod("ThoriumMod", out Mod _))
            {
                // Register the commands after recipes are added to ensure all mods are loaded
                try
                {
                    // Register our commands
                    ModContent.GetInstance<PrintBiomesCommand>();
                }
                catch (Exception ex)
                {
                    Main.NewText($"Error registering commands: {ex.Message}", Color.Red);
                }
            }
        }
    }
}
