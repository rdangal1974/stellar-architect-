namespace StellarArchitect.Physics.FormationRules;

/// <summary>
/// Star Formation Rule - Defines formation threshold for a specific star type
/// Strategy Pattern: Each star type has its own rule implementation
/// Follows SOLID: Single Responsibility (one rule per interface)
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
