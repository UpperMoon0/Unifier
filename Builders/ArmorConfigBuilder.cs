namespace Unifier.Builders
{
    public class ArmorConfigBuilder
    {
        private readonly ArmorConfig _config = new ArmorConfig();
        
        // Helmet configuration
        public ArmorConfigBuilder WithHelmet(int itemType)
        {
            _config.IsHelmet = type => type == itemType;
            return this;
        }
        
        public ArmorConfigBuilder WithHelmet(Func<int, bool> helmetPredicate)
        {
            _config.IsHelmet = helmetPredicate;
            return this;
        }
        
        public ArmorConfigBuilder WithHelmetEffects(Action<Player> effects)
        {
            _config.ApplyHelmetEffects = effects;
            return this;
        }
        
        public ArmorConfigBuilder WithHelmetTooltips(params string[] tooltips)
        {
            _config.HelmetTooltips = new List<string>(tooltips);
            return this;
        }
        
        // Chestplate configuration
        public ArmorConfigBuilder WithChestplate(int itemType)
        {
            _config.IsChestplate = type => type == itemType;
            return this;
        }
        
        public ArmorConfigBuilder WithChestplate(Func<int, bool> chestplatePredicate)
        {
            _config.IsChestplate = chestplatePredicate;
            return this;
        }
        
        public ArmorConfigBuilder WithChestplateEffects(Action<Player> effects)
        {
            _config.ApplyChestplateEffects = effects;
            return this;
        }
        
        public ArmorConfigBuilder WithChestplateTooltips(params string[] tooltips)
        {
            _config.ChestplateTooltips = new List<string>(tooltips);
            return this;
        }
        
        // Leggings configuration
        public ArmorConfigBuilder WithLeggings(int itemType)
        {
            _config.IsLeggings = type => type == itemType;
            return this;
        }
        
        public ArmorConfigBuilder WithLeggings(Func<int, bool> leggingsPredicate)
        {
            _config.IsLeggings = leggingsPredicate;
            return this;
        }
        
        public ArmorConfigBuilder WithLeggingsEffects(Action<Player> effects)
        {
            _config.ApplyLeggingsEffects = effects;
            return this;
        }
        
        public ArmorConfigBuilder WithLeggingsTooltips(params string[] tooltips)
        {
            _config.LeggingsTooltips = new List<string>(tooltips);
            return this;
        }
        
        // Set bonus configuration
        public ArmorConfigBuilder WithSetEffects(Action<Player> effects)
        {
            _config.ApplySetEffects = effects;
            return this;
        }
        
        public ArmorConfigBuilder WithSetBonusDescription(string description)
        {
            _config.SetBonusDescription = description;
            return this;
        }
        
        public ArmorConfigBuilder WithAmmoConservationChance(float chance)
        {
            _config.AmmoConservationChance = chance;
            return this;
        }
        
        // Damage type effects
        public ArmorConfigBuilder WithDamageTypeEffect(DamageClass damageClass, float damageMultiplier = 0f, float critChanceBonus = 0f, 
            float critDamageBonus = 0f, float knockbackMultiplier = 0f, ArmorPiece requiredPieces = ArmorPiece.FullSet)
        {
            _config.DamageTypeEffects[damageClass] = new DamageTypeEffect
            {
                DamageMultiplier = damageMultiplier,
                CritChanceBonus = critChanceBonus,
                CritDamageBonus = critDamageBonus,
                KnockbackMultiplier = knockbackMultiplier,
                RequiredPieces = requiredPieces
            };
            
            return this;
        }
        
        public ArmorConfig Build()
        {
            // Apply defaults for any unset predicates
            if (_config.IsHelmet == null)
                _config.IsHelmet = _ => false;
                
            if (_config.IsChestplate == null)
                _config.IsChestplate = _ => false;
                
            if (_config.IsLeggings == null)
                _config.IsLeggings = _ => false;
            
            return _config;
        }
    }
}