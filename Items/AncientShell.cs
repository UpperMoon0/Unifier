using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Unifier.Items
{
    public class AncientShell : ModItem
    {
        public override void SetDefaults()
        {
            Item.width = 42;
            Item.height = 26;
            Item.maxStack = 999;
            Item.value = Item.sellPrice(silver: 5);
            Item.rare = ItemRarityID.Blue;
        }
    }
}
