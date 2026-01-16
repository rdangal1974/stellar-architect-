using System.Collections.Generic;

namespace StellarArchitect.Physics.Core
{
    /// <summary>
    /// Interface for stability calculations.
    /// Follows Single Responsibility: Only calculates stability metrics.
    /// Follows Dependency Inversion: Depends on IPhysicsBody abstraction.
    /// </summary>
    public interface IStabilityCalculator
    {
        float CalculateBindingEnergy(IEnumerable<IPhysicsBody> bodies);
        bool IsSystemStable(IEnumerable<IPhysicsBody> bodies);
        bool IsOrbitStable(IPhysicsBody body, IEnumerable<IPhysicsBody> otherBodies, int predictionFrames);
    }
}
