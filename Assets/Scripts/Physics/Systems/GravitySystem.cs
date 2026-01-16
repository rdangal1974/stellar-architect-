using UnityEngine;
using System.Collections.Generic;
using System.Linq;
using StellarArchitect.Physics.Core;
using StellarArchitect.Physics.Components;
using StellarArchitect.Physics.Config;

namespace StellarArchitect.Physics.Systems
{
    /// <summary>
    /// Central physics system manager.
    /// Follows Singleton Pattern: Single point of physics coordination.
    /// Follows Observer Pattern: Manages physics body registration/unregistration.
    /// Follows Dependency Inversion: Uses abstractions (IGravityCalculator, IStabilityCalculator).
    /// Follows Single Responsibility: Coordinates physics simulation only.
    /// </summary>
    public class GravitySystem : MonoBehaviour
    {
        [Header("Configuration")]
        [SerializeField, Tooltip("Physics constants configuration")]
        private PhysicsConstants physicsConstants;

        [Header("Debug")]
        [SerializeField]
        private bool drawGravityLines = true;
        
        [SerializeField]
        private bool logStabilityWarnings = true;

        // Singleton instance
        private static GravitySystem instance;
        public static GravitySystem Instance => instance;

        // Physics bodies registry (Observer Pattern)
        private readonly List<IPhysicsBody> registeredBodies = new List<IPhysicsBody>();

        // Strategy implementations (Dependency Injection)
        private IGravityCalculator gravityCalculator;
        private IStabilityCalculator stabilityCalculator;

        #region Unity Lifecycle

        private void Awake()
        {
            // Singleton enforcement
            if (instance != null && instance != this)
            {
                Destroy(gameObject);
                return;
            }
            
            instance = this;
            DontDestroyOnLoad(gameObject);

            InitializeSystems();
        }

        private void FixedUpdate()
        {
            UpdatePhysics(Time.fixedDeltaTime);
        }

        private void OnDestroy()
        {
            if (instance == this)
            {
                instance = null;
            }
        }

        #endregion

        #region Initialization

        /// <summary>
        /// Initialize physics calculators.
        /// Follows Dependency Injection: Inject concrete implementations.
        /// </summary>
        private void InitializeSystems()
        {
            if (physicsConstants == null)
            {
                Debug.LogError("PhysicsConstants not assigned! Creating default.");
                physicsConstants = ScriptableObject.CreateInstance<PhysicsConstants>();
            }

            // Inject dependencies (Strategy Pattern)
            gravityCalculator = new NewtonianGravityCalculator(physicsConstants);
            stabilityCalculator = new StabilityCalculator(physicsConstants, gravityCalculator);

            Debug.Log("GravitySystem initialized with Newtonian gravity and stability calculations.");
        }

        #endregion

        #region Body Registration (Observer Pattern)

        /// <summary>
        /// Register a physics body for simulation.
        /// </summary>
        public void RegisterBody(IPhysicsBody body)
        {
            if (!registeredBodies.Contains(body))
            {
                registeredBodies.Add(body);
                Debug.Log($"Registered body: {body} (Total: {registeredBodies.Count})");
            }
        }

        /// <summary>
        /// Unregister a physics body from simulation.
        /// </summary>
        public void UnregisterBody(IPhysicsBody body)
        {
            if (registeredBodies.Remove(body))
            {
                Debug.Log($"Unregistered body: {body} (Total: {registeredBodies.Count})");
            }
        }

        /// <summary>
        /// Get all registered bodies (read-only).
        /// </summary>
        public IReadOnlyList<IPhysicsBody> GetAllBodies() => registeredBodies.AsReadOnly();

        #endregion

        #region Physics Simulation

        /// <summary>
        /// Main physics update loop.
        /// Follows Single Responsibility: Only coordinates physics steps.
        /// </summary>
        private void UpdatePhysics(float deltaTime)
        {
            if (registeredBodies.Count == 0)
                return;

            // Step 1: Calculate and apply gravitational forces
            ApplyGravitationalForces();

            // Step 2: Integrate motion for all bodies
            IntegrateBodies(deltaTime);

            // Step 3: Check system stability (optional, for warnings)
            if (logStabilityWarnings)
            {
                CheckSystemStability();
            }
        }

        /// <summary>
        /// Calculate and apply gravitational forces to all bodies.
        /// Follows DRY: Reuses gravity calculator.
        /// </summary>
        private void ApplyGravitationalForces()
        {
            // O(n²) gravity calculation - optimize later if needed
            foreach (var body in registeredBodies)
            {
                Vector3 totalForce = gravityCalculator.CalculateTotalGravity(body, registeredBodies);
                body.ApplyForce(totalForce);
            }
        }

        /// <summary>
        /// Integrate all bodies forward in time.
        /// </summary>
        private void IntegrateBodies(float deltaTime)
        {
            foreach (var body in registeredBodies)
            {
                if (body is PhysicsBody physicsBody)
                {
                    physicsBody.UpdatePhysics(deltaTime);
                }
            }
        }

        /// <summary>
        /// Check and log system stability warnings.
        /// </summary>
        private void CheckSystemStability()
        {
            if (!stabilityCalculator.IsSystemStable(registeredBodies))
            {
                float bindingEnergy = stabilityCalculator.CalculateBindingEnergy(registeredBodies);
                Debug.LogWarning($"System unstable! Binding energy: {bindingEnergy:F3} (threshold: {physicsConstants.stabilityThreshold})");
            }
        }

        #endregion

        #region Public API

        /// <summary>
        /// Check if specific body orbit is stable.
        /// </summary>
        public bool IsBodyOrbitStable(IPhysicsBody body)
        {
            return stabilityCalculator.IsOrbitStable(
                body, 
                registeredBodies, 
                physicsConstants.orbitPredictionFrames
            );
        }

        /// <summary>
        /// Get current system binding energy.
        /// </summary>
        public float GetSystemBindingEnergy()
        {
            return stabilityCalculator.CalculateBindingEnergy(registeredBodies);
        }

        /// <summary>
        /// Check if entire system is stable.
        /// </summary>
        public bool IsSystemStable()
        {
            return stabilityCalculator.IsSystemStable(registeredBodies);
        }

        #endregion

        #region Debug Visualization

        private void OnDrawGizmos()
        {
            if (!drawGravityLines || registeredBodies.Count == 0)
                return;

            // Draw gravity connections
            Gizmos.color = new Color(0, 1, 0, 0.3f);
            
            foreach (var body1 in registeredBodies)
            {
                foreach (var body2 in registeredBodies)
                {
                    if (body1 == body2)
                        continue;

                    Gizmos.DrawLine(body1.Position, body2.Position);
                }
            }
        }

        #endregion
    }
}
