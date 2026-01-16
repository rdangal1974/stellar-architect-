using UnityEngine;

namespace StellarArchitect.Physics.Config
{
    /// <summary>
    /// Physics constants and configuration values.
    /// Single source of truth for all physics calculations (DRY principle).
    /// Follows Single Responsibility: Only manages physics constants.
    /// </summary>
    [CreateAssetMenu(fileName = "PhysicsConstants", menuName = "Stellar Architect/Physics Constants")]
    public class PhysicsConstants : ScriptableObject
    {
        [Header("Gravity Settings")]
        [Tooltip("Gravitational constant scale for gameplay (dimensionless)")]
        public float gravitationalScale = 1.0f;
        
        [Tooltip("Softening length to prevent singularities (units)")]
        public float softeningLength = 2.0f;
        
        [Tooltip("Maximum gravitational acceleration (g_game units)")]
        public float maxGravitationalForce = 10.0f;

        [Header("Stability Thresholds")]
        [Tooltip("Binding energy threshold for stability (E_bind > -0.8 = stable)")]
        public float stabilityThreshold = -0.8f;
        
        [Tooltip("Orbit prediction acceleration threshold (g_game)")]
        public float orbitStableAcceleration = 0.3f;
        
        [Tooltip("Number of frames to predict for orbit stability")]
        public int orbitPredictionFrames = 10;

        [Header("Formation Thresholds")]
        [Tooltip("Red Dwarf: mass >= 0.5, density >= 2.0")]
        public FormationThreshold redDwarfThreshold = new FormationThreshold(0.5f, 2.0f);
        
        [Tooltip("Yellow Star: mass >= 1.5, density >= 3.5")]
        public FormationThreshold yellowStarThreshold = new FormationThreshold(1.5f, 3.5f);
        
        [Tooltip("Blue Giant: mass >= 4.0, density >= 6.0")]
        public FormationThreshold blueGiantThreshold = new FormationThreshold(4.0f, 6.0f);
        
        [Tooltip("Black Hole: mass >= 10.0, density >= 15.0")]
        public FormationThreshold blackHoleThreshold = new FormationThreshold(10.0f, 15.0f);

        [Header("Lifecycle Timescales (gameplay hours)")]
        public float redDwarfLifetime = 120.0f;
        public float yellowStarLifetime = 80.0f;
        public float blueGiantLifetime = 40.0f;
        
        [Tooltip("Red giant phase duration for yellow stars")]
        public float redGiantPhaseDuration = 25.0f;

        [Header("Player Interaction")]
        [Tooltip("Impulse magnitude for nudge mechanic (g_game)")]
        public float nudgeImpulse = 0.2f;
        
        [Tooltip("Long-press duration for merge (seconds)")]
        public float mergeLongPressDuration = 0.5f;
        
        [Tooltip("Hold duration for shield activation (seconds)")]
        public float shieldHoldDuration = 1.0f;
    }

    /// <summary>
    /// Formation threshold data structure.
    /// Encapsulates mass and density requirements for star formation.
    /// </summary>
    [System.Serializable]
    public struct FormationThreshold
    {
        public float minMass;
        public float minDensity;

        public FormationThreshold(float mass, float density)
        {
            minMass = mass;
            minDensity = density;
        }

        public bool IsMet(float mass, float density)
        {
            return mass >= minMass && density >= minDensity;
        }
    }
}
