using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Unifier.Items
{
    public class DukeTail : ModItem
    {
        public override void SetDefaults()
        {
            Item.width = 48;
            Item.height = 58;
            Item.maxStack = 999;
            Item.value = Item.sellPrice(silver: 15);
            Item.rare = ItemRarityID.Green;
        }
    }
}
