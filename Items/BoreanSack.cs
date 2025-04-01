using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Unifier.Items
{
    public class BoreanSack : ModItem
    {
        public override void SetDefaults()
        {
            Item.width = 40;
            Item.height = 26;
            Item.maxStack = 999;
            Item.value = Item.sellPrice(silver: 10);
            Item.rare = ItemRarityID.Green;
        }
    }
}
