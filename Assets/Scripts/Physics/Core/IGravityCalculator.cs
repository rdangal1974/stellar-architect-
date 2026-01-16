using UnityEngine;
using System.Collections.Generic;

namespace StellarArchitect.Physics.Core
{
    /// <summary>
    /// Interface for gravity calculation strategies.
    /// Follows Strategy Pattern: Different gravity algorithms can be swapped.
    /// Follows Open/Closed: Open for extension (new strategies), closed for modification.
    /// </summary>
    public interface IGravityCalculator
    {
        Vector3 CalculateGravitationalForce(IPhysicsBody body1, IPhysicsBody body2);
        Vector3 CalculateTotalGravity(IPhysicsBody body, IEnumerable<IPhysicsBody> otherBodies);
    }
}
