namespace Unifier.Models
{
    [System.Flags]
    public enum ArmorPiece
    {
        None = 0,
        Helmet = 1,
        Chestplate = 2,
        Leggings = 4,
        FullSet = Helmet | Chestplate | Leggings
    }
}