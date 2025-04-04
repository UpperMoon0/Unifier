using Terraria;
using Terraria.ModLoader;
using ThoriumMod.NPCs.Depths;
using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace Unifier.NPCs
{
    public class NpcChanges : GlobalNPC
    { 
        public override void EditSpawnPool(IDictionary<int, float> pool, NPCSpawnInfo spawnInfo)
        {
            Mod thoriumMod = ModLoader.GetMod("ThoriumMod");
            
            // Check if we're in the Depths biome (using DepthsBiome from Thorium)
            if (thoriumMod != null && spawnInfo.Player.InModBiome(thoriumMod.Find<ModBiome>("DepthsBiome")))
            {
                // Add Aquatic Hallucination to spawn pool with a weight of 0.1
                int aquaticHallucinationType = thoriumMod.Find<ModNPC>("AquaticHallucination").Type;
                pool[aquaticHallucinationType] = 0.1f;
            }
        }
    }
}