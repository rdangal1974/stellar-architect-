namespace StellarArchitect.Physics.FormationRules;

using System;
using System.Collections.Generic;
using System.Linq;

/// <summary>
/// Registry of all star formation rules
/// Follows SOLID: Dependency Inversion (depend on interface, not concrete types)
/// Factory Pattern: Central place to create and access formation rules
/// Single Responsibility: Only manages the registry of formation rules
/// </summary>
public class StarFormationRuleRegistry
{
    private readonly Dictionary<string, IStarFormationRule> _rules;

    /// <summary>Create a new star formation rule registry with default rules</summary>
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

    /// <summary>
    /// Add or update a formation rule
    /// Supports extensibility: custom star types can be registered
    /// </summary>
    /// <param name="rule">The rule to register</param>
    /// <exception cref="ArgumentNullException">If rule is null</exception>
    public void Register(IStarFormationRule rule)
    {
        if (rule == null)
            throw new ArgumentNullException(nameof(rule));
        _rules[rule.StarType] = rule;
    }

    /// <summary>
    /// Get formation rule by star type
    /// </summary>
    /// <param name="starType">The star type to retrieve</param>
    /// <returns>The formation rule for the star type</returns>
    /// <exception cref="KeyNotFoundException">If star type is not registered</exception>
    public IStarFormationRule GetRule(string starType)
    {
        if (!_rules.TryGetValue(starType, out var rule))
            throw new KeyNotFoundException($"No formation rule found for star type: {starType}");
        return rule;
    }

    /// <summary>Check if a star type has a registered rule</summary>
    /// <param name="starType">The star type to check</param>
    /// <returns>True if rule exists, false otherwise</returns>
    public bool HasRule(string starType) => _rules.ContainsKey(starType);

    /// <summary>Get all registered star types</summary>
    /// <returns>Collection of all registered star type names</returns>
    public IEnumerable<string> GetAllStarTypes() => _rules.Keys.ToList();
}
