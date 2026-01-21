using UnityEngine;
using StellarArchitect.Physics.Components;
using System.Collections.Generic;

namespace StellarArchitect.Gameplay
{
    /// <summary>
    /// Detects when physics bodies meet star formation thresholds.
    /// Based on ARCHITECTURE_UPDATES.md physics specifications.
    /// </summary>
    public class StarFormationDetector : MonoBehaviour
    {
        /// <summary>
        /// Check what star type (if any) the body has formed into.
        /// Returns the body's CurrentStarType property.
        /// </summary>
        public StarType CheckFormation(PhysicsBody body)
        {
            if (body == null) return StarType.None;
            return body.CurrentStarType;
        }

        /// <summary>
        /// Check all bodies in the scene and return list of formed stars.
        /// </summary>
        public List<(PhysicsBody body, StarType type)> CheckAllBodies()
        {
            List<(PhysicsBody, StarType)> formedStars = new List<(PhysicsBody, StarType)>();

            PhysicsBody[] allBodies = FindObjectsOfType<PhysicsBody>();
            foreach (PhysicsBody body in allBodies)
            {
                StarType type = body.CurrentStarType;
                if (type != StarType.None)
                {
                    formedStars.Add((body, type));
                }
            }

            return formedStars;
        }

        /// <summary>
        /// Get progress toward forming a specific star type (0-1 range).
        /// </summary>
        public float GetFormationProgress(PhysicsBody body, StarType targetType)
        {
            if (body == null) return 0f;

            // Get thresholds from PhysicsConstants (would need reference)
            float massThreshold = GetMassThreshold(targetType);
            float densityThreshold = GetDensityThreshold(targetType);

            float massProgress = Mathf.Clamp01(body.Mass / massThreshold);
            float densityProgress = Mathf.Clamp01(body.Density / densityThreshold);

            return Mathf.Min(massProgress, densityProgress);
        }

        private float GetMassThreshold(StarType type)
        {
            switch (type)
            {
                case StarType.RedDwarf: return 0.5f;
                case StarType.YellowStar: return 1.5f;
                case StarType.BlueGiant: return 4.0f;
                case StarType.BlackHole: return 10.0f;
                default: return 0f;
            }
        }

        private float GetDensityThreshold(StarType type)
        {
            switch (type)
            {
                case StarType.RedDwarf: return 2.0f;
                case StarType.YellowStar: return 3.5f;
                case StarType.BlueGiant: return 6.0f;
                case StarType.BlackHole: return 15.0f;
                default: return 0f;
            }
        }
    }
}
