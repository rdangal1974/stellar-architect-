using UnityEngine;
using System.Collections.Generic;
using StellarArchitect.Physics.Core;
using StellarArchitect.Physics.Config;

namespace StellarArchitect.Physics.Systems
{
    /// <summary>
    /// Newton-inspired gravity calculator with softening.
    /// Follows Strategy Pattern: Implements IGravityCalculator for swappable algorithms.
    /// Follows Single Responsibility: Only calculates gravitational forces.
    /// Follows DRY: Reuses force calculation for pairwise and total gravity.
    /// </summary>
    public class NewtonianGravityCalculator : IGravityCalculator
    {
        private readonly PhysicsConstants constants;

        public NewtonianGravityCalculator(PhysicsConstants constants)
        {
            this.constants = constants ?? throw new System.ArgumentNullException(nameof(constants));
        }

        /// <summary>
        /// Calculate gravitational force between two bodies.
        /// Formula: F = G * (m1 * m2) / (r² + ?²)^(3/2) * direction
        /// Where ? is softening length to prevent singularities.
        /// </summary>
        public Vector3 CalculateGravitationalForce(IPhysicsBody body1, IPhysicsBody body2)
        {
            Vector3 direction = body2.Position - body1.Position;
            float distanceSquared = direction.sqrMagnitude;
            
            // Prevent self-interaction
            if (distanceSquared < 0.0001f)
                return Vector3.zero;

            // Softened gravity to prevent singularities
            float softenedDistanceSquared = distanceSquared + 
                constants.softeningLength * constants.softeningLength;
            
            // Newton's law: F = G * m1 * m2 / r²
            // With softening: F = G * m1 * m2 / (r² + ?²)^(3/2)
            float forceMagnitude = constants.gravitationalScale * 
                body1.Mass * body2.Mass / 
                Mathf.Pow(softenedDistanceSquared, 1.5f);

            // Clamp force to prevent numerical instability
            forceMagnitude = Mathf.Min(forceMagnitude, constants.maxGravitationalForce);

            return direction.normalized * forceMagnitude;
        }

        /// <summary>
        /// Calculate total gravitational force on a body from all other bodies.
        /// Follows DRY: Reuses CalculateGravitationalForce.
        /// </summary>
        public Vector3 CalculateTotalGravity(IPhysicsBody body, IEnumerable<IPhysicsBody> otherBodies)
        {
            Vector3 totalForce = Vector3.zero;

            foreach (var otherBody in otherBodies)
            {
                if (otherBody == body)
                    continue;

                totalForce += CalculateGravitationalForce(body, otherBody);
            }

            return totalForce;
        }
    }
}
