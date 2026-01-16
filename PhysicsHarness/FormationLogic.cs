using System;
using System.Collections.Generic;
using System.Linq;

/// <summary>
/// Star Formation Rule - Defines formation threshold for a specific star type
/// Strategy Pattern: Each star type has its own rule implementation
/// Follows SOLID: Single Responsibility (one rule per class)
/// </summary>
public interface IStarFormationRule
{
    /// <summary>Unique identifier for this star type</summary>
    string StarType { get; }
    
    /// <summary>Minimum mass required for formation</summary>
    float MinMass { get; }
    
    /// <summary>Minimum density required for formation</summary>
    float MinDensity { get; }
    
    /// <summary>Check if star has formed based on mass and density</summary>
    bool IsFormed(float mass, float density);
}

/// <summary>
/// Concrete implementation of star formation threshold
/// Follows DRY: Single threshold logic used for all star types
/// Follows SOLID: Open/Closed (can add new stars without modifying this class)
/// </summary>
public class StarFormationThreshold : IStarFormationRule
{
    public string StarType { get; }
    public float MinMass { get; }
    public float MinDensity { get; }

    public StarFormationThreshold(string starType, float minMass, float minDensity)
    {
        if (string.IsNullOrWhiteSpace(starType))
            throw new ArgumentException("Star type cannot be empty", nameof(starType));
        if (minMass < 0)
            throw new ArgumentException("Minimum mass cannot be negative", nameof(minMass));
        if (minDensity < 0)
            throw new ArgumentException("Minimum density cannot be negative", nameof(minDensity));

        StarType = starType;
        MinMass = minMass;
        MinDensity = minDensity;
    }

    /// <summary>
    /// Check if formation threshold is met
    /// Both mass AND density must meet minimum requirements
    /// </summary>
    public bool IsFormed(float mass, float density)
        => mass >= MinMass && density >= MinDensity;
}

/// <summary>
/// Registry of all star formation rules
/// Follows SOLID: Dependency Inversion (depend on interface, not concrete types)
/// Factory Pattern: Central place to create and access formation rules
/// </summary>
public class StarFormationRuleRegistry
{
    private readonly Dictionary<string, IStarFormationRule> _rules;

    public StarFormationRuleRegistry()
    {
        _rules = new Dictionary<string, IStarFormationRule>();
        RegisterDefaultRules();
    }

    /// <summary>Register all standard star types and their thresholds</summary>
    private void RegisterDefaultRules()
    {
        Register(new StarFormationThreshold("RedDwarf", minMass: 0.5f, minDensity: 2.0f));
        Register(new StarFormationThreshold("YellowStar", minMass: 1.5f, minDensity: 3.5f));
        Register(new StarFormationThreshold("BlueGiant", minMass: 4.0f, minDensity: 6.0f));
        Register(new StarFormationThreshold("BlackHole", minMass: 10.0f, minDensity: 15.0f));
    }

    /// <summary>Add a custom star formation rule (extensibility)</summary>
    public void Register(IStarFormationRule rule)
    {
        if (rule == null)
            throw new ArgumentNullException(nameof(rule));
        _rules[rule.StarType] = rule;
    }

    /// <summary>Get formation rule by star type</summary>
    public IStarFormationRule GetRule(string starType)
    {
        if (!_rules.TryGetValue(starType, out var rule))
            throw new KeyNotFoundException($"No formation rule found for star type: {starType}");
        return rule;
    }

    /// <summary>Check if a star type is registered</summary>
    public bool HasRule(string starType) => _rules.ContainsKey(starType);

    /// <summary>Get all registered star types</summary>
    public IEnumerable<string> GetAllStarTypes() => _rules.Keys.ToList();
}

/// <summary>
/// Static accessor for formation logic
/// Provides backward compatibility with existing code
/// Follows SOLID: Facade pattern for simplified interface
/// </summary>
public static class FormationLogic
{
    private static readonly Lazy<StarFormationRuleRegistry> _registry =
        new(() => new StarFormationRuleRegistry());

    public static bool IsRedDwarfFormed(float mass, float density)
        => CheckFormation("RedDwarf", mass, density);

    public static bool IsYellowStarFormed(float mass, float density)
        => CheckFormation("YellowStar", mass, density);

    public static bool IsBlueGiantFormed(float mass, float density)
        => CheckFormation("BlueGiant", mass, density);

    public static bool IsBlackHoleFormed(float mass, float density)
        => CheckFormation("BlackHole", mass, density);

    /// <summary>
    /// Generic method to check formation for any star type
    /// Single point of logic (DRY principle)
    /// </summary>
    public static bool CheckFormation(string starType, float mass, float density)
    {
        try
        {
            var rule = _registry.Value.GetRule(starType);
            return rule.IsFormed(mass, density);
        }
        catch (KeyNotFoundException)
        {
            throw new InvalidOperationException(
                $"Unknown star type: {starType}. Available types: {string.Join(", ", _registry.Value.GetAllStarTypes())}");
        }
    }

    /// <summary>Get the registry for direct access (advanced usage)</summary>
    public static StarFormationRuleRegistry Registry => _registry.Value;
}
