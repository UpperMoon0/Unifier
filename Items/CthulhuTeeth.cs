using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Unifier.Items
{
    public class CthulhuTeeth : ModItem
    {
        public override void SetDefaults()
        {
            Item.width = 22;
            Item.height = 14;
            Item.maxStack = 999;
            Item.value = Item.sellPrice(silver: 5);
            Item.rare = ItemRarityID.Blue;
        }
    }
}
