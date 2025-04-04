using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Unifier.Items
{
    public class ShinyPlate : ModItem
    {
        
        public override void SetDefaults()
        {
            Item.width = 44;
            Item.height = 48;
            Item.maxStack = 999;
            Item.value = Item.sellPrice(silver: 18);
            Item.rare = ItemRarityID.Green;
        }
    }
}
