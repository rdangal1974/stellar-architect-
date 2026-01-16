using UnityEngine;
using StellarArchitect.Physics.Systems;

namespace StellarArchitect.Physics.Components
{
    /// <summary>
    /// Automatically registers/unregisters PhysicsBody with GravitySystem.
    /// Follows Observer Pattern: Automatic subscription management.
    /// Follows Single Responsibility: Only handles registration lifecycle.
    /// </summary>
    [RequireComponent(typeof(PhysicsBody))]
    public class PhysicsBodyAutoRegister : MonoBehaviour
    {
        private PhysicsBody physicsBody;

        private void Awake()
        {
            physicsBody = GetComponent<PhysicsBody>();
        }

        private void OnEnable()
        {
            if (GravitySystem.Instance != null)
            {
                GravitySystem.Instance.RegisterBody(physicsBody);
            }
            else
            {
                Debug.LogWarning($"GravitySystem not found! {gameObject.name} will not participate in physics.");
            }
        }

        private void OnDisable()
        {
            if (GravitySystem.Instance != null)
            {
                GravitySystem.Instance.UnregisterBody(physicsBody);
            }
        }
    }
}
