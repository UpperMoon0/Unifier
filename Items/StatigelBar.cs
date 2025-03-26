using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Unifier.Items
{
    public class StatigelBar : ModItem
    {
        public override void SetDefaults()
        {
            Item.width = 32;
            Item.height = 24;
            Item.maxStack = 999;
            Item.value = Item.sellPrice(silver: 70);
            Item.rare = ItemRarityID.Green;
        }
    }
}
