using UnityEngine;

namespace StellarArchitect.Physics.Core
{
    /// <summary>
    /// Interface for physics-simulated bodies.
    /// Follows Interface Segregation: Only essential physics properties.
    /// Follows Liskov Substitution: Any IPhysicsBody can be used interchangeably.
    /// </summary>
    public interface IPhysicsBody
    {
        float Mass { get; }
        Vector3 Position { get; }
        Vector3 Velocity { get; set; }
        Vector3 Acceleration { get; }
        
        void ApplyForce(Vector3 force);
        void ResetAcceleration();
    }
}
