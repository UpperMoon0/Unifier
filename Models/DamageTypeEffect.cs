namespace Unifier.Models 
{
    public class DamageTypeEffect
    {
        public float DamageMultiplier { get; set; }
        public float CritChanceBonus { get; set; }
        public float CritDamageBonus { get; set; }
        public float KnockbackMultiplier { get; set; }
        public ArmorPiece RequiredPieces { get; set; } = ArmorPiece.FullSet;
    }
}