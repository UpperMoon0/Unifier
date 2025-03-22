using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Unifier.Items
{
    public class ChampionFragment : ModItem
    {
        public override void SetDefaults()
        {
            Item.width = 32;
            Item.height = 32;
            Item.maxStack = 999;
            Item.value = Item.sellPrice(silver: 10);
            Item.rare = ItemRarityID.Green;
        }
    }
}
