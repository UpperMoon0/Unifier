using Terraria;
using Terraria.GameContent.ItemDropRules;
using Terraria.ID;
using Terraria.ModLoader;
using Unifier.Items;

namespace Unifier.NPCs
{
    public class BossDrops : GlobalNPC
    {
        public override void ModifyNPCLoot(NPC npc, NPCLoot npcLoot)
        {
            // Reference the required mods directly
            Mod fargoMod = ModLoader.GetMod("FargowiltasSouls");
            Mod thoriumMod = ModLoader.GetMod("ThoriumMod");
            Mod calamityMod = ModLoader.GetMod("CalamityMod");
            
            // Fargowiltas Souls Mod Bosses
            // Trojan Squirrel - Hardened Planks
            if (npc.type == fargoMod.Find<ModNPC>("TrojanSquirrel").Type)
            {
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<HardenedPlanks>(), 1, 5, 8));
            }

            // Cursed Coffin - Pharaoh Slab
            if (npc.type == fargoMod.Find<ModNPC>("CursedCoffin").Type)
            {
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<PharaohBrick>(), 1, 5, 8));
            }

            // Thorium Mod Bosses
            // Star Scouter - Alien Tech Scrap
            if (npc.type == thoriumMod.Find<ModNPC>("StarScouter").Type)
            {
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<AlienTechScrap>(), 1, 5, 8));
            }

            // Buried Champion - Champion Fragment
            if (npc.type == thoriumMod.Find<ModNPC>("BuriedChampion").Type)
            {
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<ChampionFragment>(), 1, 5, 8));
            }

            // Granite Energy Storm - Granite Storm Core
            if (npc.type == thoriumMod.Find<ModNPC>("GraniteEnergyStorm").Type)
            {
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<GraniteStormCore>(), 1, 5, 8));
            }

            // Queen Jellyfish - Jellyfish Gel
            if (npc.type == thoriumMod.Find<ModNPC>("QueenJellyfish").Type)
            {
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<JellyfishGel>(), 1, 5, 8));
            }

            // Viscount - Viscount Fur
            if (npc.type == thoriumMod.Find<ModNPC>("Viscount").Type)
            {
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<ViscountFur>(), 1, 5, 8));
            }

            // Calamity Mod Bosses
            // Crabulon - Mutant Glowing Mushroom
            if (npc.type == calamityMod.Find<ModNPC>("Crabulon").Type)
            {
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<MutantGlowingMushroom>(), 1, 5, 8));
            }

            // Vanilla bosses
            // Deerclops - Deerclops Fur
            if (npc.type == NPCID.Deerclops)
            {
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<DeerclopsFur>(), 1, 5, 8));
            }

            // King Slime - Gilded Gel
            if (npc.type == NPCID.KingSlime)
            {
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<GildedGel>(), 1, 5, 8));
            }
        }
    }
}
