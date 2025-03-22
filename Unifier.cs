using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria.ModLoader;

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
}
