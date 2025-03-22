using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace Unifier.Items
{
    public class ViscountFur : ModItem
    {
        
        public override void SetDefaults()
        {
            Item.width = 32;
            Item.height = 32;
            Item.maxStack = 999;
            Item.value = Item.sellPrice(silver: 16);
            Item.rare = ItemRarityID.Green;
        }
    }
}
