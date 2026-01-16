using UnityEngine;
using StellarArchitect.Physics.Core;

namespace StellarArchitect.Physics.Components
{
    /// <summary>
    /// Physics body component for stellar objects.
    /// Follows Single Responsibility: Manages physics state for a single body.
    /// Follows Component Pattern: Unity MonoBehaviour integration.
    /// Implements IPhysicsBody for polymorphic physics calculations.
    /// </summary>
    [RequireComponent(typeof(Rigidbody))]
    public class PhysicsBody : MonoBehaviour, IPhysicsBody
    {
        [Header("Physical Properties")]
        [SerializeField, Tooltip("Mass of the stellar body (solar masses)")]
        private float mass = 0.3f;
        
        [SerializeField, Tooltip("Current density (g/cm³) - calculated from mass and volume")]
        private float density = 1.0f;

        [Header("Runtime State")]
        [SerializeField, ReadOnly]
        private Vector3 velocity;
        
        [SerializeField, ReadOnly]
        private Vector3 acceleration;

        private Rigidbody rb;

        #region IPhysicsBody Implementation

        public float Mass => mass;
        public float Density => density;
        
        public Vector3 Position => transform.position;
        
        public Vector3 Velocity 
        { 
            get => velocity; 
            set => velocity = value; 
        }
        
        public Vector3 Acceleration => acceleration;

        public void ApplyForce(Vector3 force)
        {
            if (mass > 0)
            {
                acceleration += force / mass;
            }
        }

        public void ResetAcceleration()
        {
            acceleration = Vector3.zero;
        }

        #endregion

        #region Unity Lifecycle

        private void Awake()
        {
            rb = GetComponent<Rigidbody>();
            rb.useGravity = false; // Use custom gravity system
            rb.isKinematic = true; // Manual physics control
        }

        private void Start()
        {
            CalculateDensity();
        }

        /// <summary>
        /// Update physics state using semi-implicit Euler integration.
        /// Called by GravitySystem to maintain consistent update order.
        /// </summary>
        public void UpdatePhysics(float deltaTime)
        {
            // Semi-implicit Euler: v(t+dt) = v(t) + a(t) * dt
            velocity += acceleration * deltaTime;
            
            // Update position: p(t+dt) = p(t) + v(t+dt) * dt
            transform.position += velocity * deltaTime;
            
            // Reset acceleration for next frame (forces are reapplied each frame)
            ResetAcceleration();
        }

        #endregion

        #region Density Calculation

        /// <summary>
        /// Calculate density from mass and volume.
        /// Assumes spherical body: density = mass / (4/3 * ? * r³)
        /// </summary>
        private void CalculateDensity()
        {
            float radius = transform.localScale.x * 0.5f; // Assume uniform scale
            float volume = (4f / 3f) * Mathf.PI * Mathf.Pow(radius, 3);
            
            if (volume > 0)
            {
                density = mass / volume;
            }
        }

        /// <summary>
        /// Recalculate density when mass or scale changes.
        /// </summary>
        public void UpdateDensity()
        {
            CalculateDensity();
        }

        #endregion

        #region Debug Visualization

        private void OnDrawGizmos()
        {
            // Visualize velocity vector
            if (Application.isPlaying && velocity.magnitude > 0.01f)
            {
                Gizmos.color = Color.cyan;
                Gizmos.DrawLine(transform.position, transform.position + velocity.normalized * 2f);
            }

            // Visualize acceleration vector
            if (Application.isPlaying && acceleration.magnitude > 0.01f)
            {
                Gizmos.color = Color.yellow;
                Gizmos.DrawLine(transform.position, transform.position + acceleration.normalized * 1.5f);
            }
        }

        #endregion
    }

    /// <summary>
    /// Custom attribute for read-only display in inspector.
    /// </summary>
    public class ReadOnlyAttribute : PropertyAttribute { }
}
