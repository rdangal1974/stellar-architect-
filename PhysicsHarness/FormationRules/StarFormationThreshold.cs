namespace StellarArchitect.Physics.FormationRules;

/// <summary>
/// Concrete implementation of star formation threshold
/// Follows DRY: Single threshold logic used for all star types
/// Follows SOLID: Open/Closed (can add new stars without modifying this class)
/// Single Responsibility: Only responsible for checking formation threshold
/// </summary>
public class StarFormationThreshold : IStarFormationRule
{
    public string StarType { get; }
    public float MinMass { get; }
    public float MinDensity { get; }

    /// <summary>
    /// Create a new star formation threshold rule
    /// </summary>
    /// <param name="starType">Name of the star type (e.g., "RedDwarf")</param>
    /// <param name="minMass">Minimum mass required for formation</param>
    /// <param name="minDensity">Minimum density required for formation</param>
    /// <exception cref="ArgumentException">If parameters are invalid</exception>
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
    /// <param name="mass">Current mass of the forming body</param>
    /// <param name="density">Current density of the forming body</param>
    /// <returns>True if both thresholds are met, false otherwise</returns>
    public bool IsFormed(float mass, float density)
        => mass >= MinMass && density >= MinDensity;
}
