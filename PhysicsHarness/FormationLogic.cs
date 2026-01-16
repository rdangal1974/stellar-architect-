namespace StellarArchitect.Physics;

using System;
using System.Linq;
using StellarArchitect.Physics.FormationRules;

/// <summary>
/// Static accessor for formation logic
/// Provides backward compatibility with existing code
/// Follows SOLID: Facade pattern for simplified interface
/// Single Responsibility: Provides single entry point for formation checks
/// </summary>
public static class FormationLogic
{
    private static readonly Lazy<StarFormationRuleRegistry> _registry =
        new(() => new StarFormationRuleRegistry());

    /// <summary>Check if a Red Dwarf has formed</summary>
    public static bool IsRedDwarfFormed(float mass, float density)
        => CheckFormation("RedDwarf", mass, density);

    /// <summary>Check if a Yellow Star has formed</summary>
    public static bool IsYellowStarFormed(float mass, float density)
        => CheckFormation("YellowStar", mass, density);

    /// <summary>Check if a Blue Giant has formed</summary>
    public static bool IsBlueGiantFormed(float mass, float density)
        => CheckFormation("BlueGiant", mass, density);

    /// <summary>Check if a Black Hole has formed</summary>
    public static bool IsBlackHoleFormed(float mass, float density)
        => CheckFormation("BlackHole", mass, density);

    /// <summary>
    /// Generic method to check formation for any star type
    /// Single point of logic (DRY principle)
    /// </summary>
    /// <param name="starType">Type of star to check</param>
    /// <param name="mass">Current mass</param>
    /// <param name="density">Current density</param>
    /// <returns>True if formation threshold is met, false otherwise</returns>
    /// <exception cref="InvalidOperationException">If star type is not recognized</exception>
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
