using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.DataStructures;

namespace Unifier.Changes
{
    public class ProjectileChanges : GlobalProjectile
    {
        // Check for individual Wood armor pieces
        private bool IsWearingWoodHelmet(Player player) => player.armor[0].type == ItemID.WoodHelmet;
        private bool IsWearingWoodBreastplate(Player player) => player.armor[1].type == ItemID.WoodBreastplate;
        private bool IsWearingWoodGreaves(Player player) => player.armor[2].type == ItemID.WoodGreaves;
        
        // Check if wearing full wood armor set
        private bool IsWearingFullWoodArmor(Player player) => 
            IsWearingWoodHelmet(player) && IsWearingWoodBreastplate(player) && IsWearingWoodGreaves(player);

        public override void ModifyHitNPC(Projectile projectile, NPC target, ref NPC.HitModifiers modifiers)
        {
            if (projectile.DamageType == DamageClass.Ranged)
            {
                Player player = Main.player[projectile.owner];
                
                // Wood Breastplate provides +10% ranged damage
                if (IsWearingWoodBreastplate(player))
                {
                    modifiers.SourceDamage *= 1.1f;
                }
                
                // Full set provides +15% crit strike damage
                if (IsWearingFullWoodArmor(player))
                {
                    var currentCritDamage = modifiers.CritDamage;
                    float baseValue = currentCritDamage.Base;
                    float additive = currentCritDamage.Additive + 0.15f;  // Add 15% to current additive value
                    modifiers.CritDamage = new StatModifier(baseValue, additive);
                }
            }
        }
        
        // Apply critical chance bonus to projectiles
        public override void OnSpawn(Projectile projectile, IEntitySource source)
        {
            if (projectile.DamageType == DamageClass.Ranged && projectile.owner >= 0 && projectile.owner < Main.maxPlayers)
            {
                Player player = Main.player[projectile.owner];
                
                // Adjust projectile critical chance (this is handled differently for projectiles)
                if (IsWearingWoodHelmet(player))
                {
                    projectile.CritChance += 5;
                }
            }
        }
    }
}
