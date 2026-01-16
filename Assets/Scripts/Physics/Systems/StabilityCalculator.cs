using UnityEngine;
using System.Collections.Generic;
using System.Linq;
using StellarArchitect.Physics.Core;
using StellarArchitect.Physics.Config;

namespace StellarArchitect.Physics.Systems
{
    /// <summary>
    /// Calculates system stability and binding energy.
    /// Follows Single Responsibility: Only stability calculations.
    /// Follows Dependency Inversion: Depends on abstractions (IPhysicsBody, IGravityCalculator).
    /// </summary>
    public class StabilityCalculator : IStabilityCalculator
    {
        private readonly PhysicsConstants constants;
        private readonly IGravityCalculator gravityCalculator;

        public StabilityCalculator(PhysicsConstants constants, IGravityCalculator gravityCalculator)
        {
            this.constants = constants ?? throw new System.ArgumentNullException(nameof(constants));
            this.gravityCalculator = gravityCalculator ?? throw new System.ArgumentNullException(nameof(gravityCalculator));
        }

        /// <summary>
        /// Calculate total binding energy of a system.
        /// Formula: E_bind = -0.5 × M × G_scale × (M / R_softening)
        /// Where M is total mass, R_softening prevents singularities.
        /// </summary>
        public float CalculateBindingEnergy(IEnumerable<IPhysicsBody> bodies)
        {
            var bodyList = bodies.ToList();
            
            if (bodyList.Count == 0)
                return 0f;

            // Calculate total mass
            float totalMass = bodyList.Sum(b => b.Mass);

            // Calculate center of mass
            Vector3 centerOfMass = CalculateCenterOfMass(bodyList);

            // Calculate mean distance from center of mass
            float meanDistance = bodyList
                .Average(b => Vector3.Distance(b.Position, centerOfMass));

            // Add softening to prevent division by zero
            float softenedDistance = Mathf.Max(meanDistance, constants.softeningLength);

            // Binding energy formula (negative = bound system)
            float bindingEnergy = -0.5f * totalMass * constants.gravitationalScale * 
                (totalMass / softenedDistance);

            return bindingEnergy;
        }

        /// <summary>
        /// Check if system is gravitationally stable.
        /// Stable if binding energy exceeds threshold (E_bind > -0.8 = stable).
        /// </summary>
        public bool IsSystemStable(IEnumerable<IPhysicsBody> bodies)
        {
            float bindingEnergy = CalculateBindingEnergy(bodies);
            return bindingEnergy > constants.stabilityThreshold;
        }

        /// <summary>
        /// Predict orbit stability over multiple frames.
        /// Stable if acceleration remains below threshold for prediction window.
        /// </summary>
        public bool IsOrbitStable(IPhysicsBody body, IEnumerable<IPhysicsBody> otherBodies, int predictionFrames)
        {
            var otherBodyList = otherBodies.Where(b => b != body).ToList();
            
            if (otherBodyList.Count == 0)
                return true; // No gravitational influence = stable

            // Check if acceleration is consistently below threshold
            for (int i = 0; i < predictionFrames; i++)
            {
                Vector3 totalGravity = gravityCalculator.CalculateTotalGravity(body, otherBodyList);
                float acceleration = totalGravity.magnitude / body.Mass;

                if (acceleration > constants.orbitStableAcceleration)
                {
                    return false; // Orbit unstable
                }

                // Note: This is a simplified prediction.
                // Full implementation would integrate positions forward.
            }

            return true;
        }

        #region Helper Methods (DRY)

        /// <summary>
        /// Calculate center of mass for a collection of bodies.
        /// </summary>
        private Vector3 CalculateCenterOfMass(List<IPhysicsBody> bodies)
        {
            if (bodies.Count == 0)
                return Vector3.zero;

            float totalMass = bodies.Sum(b => b.Mass);
            
            if (totalMass == 0)
                return Vector3.zero;

            Vector3 weightedSum = bodies
                .Aggregate(Vector3.zero, (sum, body) => sum + body.Position * body.Mass);

            return weightedSum / totalMass;
        }

        #endregion
    }
}
