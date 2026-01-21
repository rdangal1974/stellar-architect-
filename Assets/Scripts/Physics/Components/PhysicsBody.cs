using UnityEngine;
using StellarArchitect.Physics.Core;
using StellarArchitect.Physics.Config;

namespace StellarArchitect.Physics.Components
{
    [RequireComponent(typeof(Rigidbody))]
    public class PhysicsBody : MonoBehaviour, IPhysicsBody
    {
        [Header("Physical Properties")]
        [SerializeField] private float mass = 0.3f;
        [SerializeField] private float density = 1.0f;

        [Header("Star Formation")]
        [SerializeField, ReadOnly] private StarType currentStarType = StarType.None;
        [SerializeField] private PhysicsConstants physicsConstants;

        [Header("Runtime State")]
        [SerializeField, ReadOnly] private Vector3 velocity;
        [SerializeField, ReadOnly] private Vector3 acceleration;
        private Rigidbody rb;

        public float Mass => mass;
        public float Density => density;
        public StarType CurrentStarType => currentStarType;
        public Vector3 Position => transform.position;
        public Vector3 Velocity { get => velocity; set => velocity = value; }
        public Vector3 Acceleration => acceleration;

        public void ApplyForce(Vector3 force) { if (mass > 0) acceleration += force / mass; }
        public void ResetAcceleration() => acceleration = Vector3.zero;

        private void Awake()
        {
            rb = GetComponent<Rigidbody>();
            rb.useGravity = false;
            rb.isKinematic = true;
        }

        private void Start() => CheckStarFormation();

        public void UpdatePhysics(float deltaTime)
        {
            velocity += acceleration * deltaTime;
            transform.position += velocity * deltaTime;
            ResetAcceleration();
        }

        public void CheckStarFormation()
        {
            if (physicsConstants == null) { currentStarType = StarType.None; return; }
            if (physicsConstants.blackHoleThreshold.IsMet(mass, density)) currentStarType = StarType.BlackHole;
            else if (physicsConstants.blueGiantThreshold.IsMet(mass, density)) currentStarType = StarType.BlueGiant;
            else if (physicsConstants.yellowStarThreshold.IsMet(mass, density)) currentStarType = StarType.YellowStar;
            else if (physicsConstants.redDwarfThreshold.IsMet(mass, density)) currentStarType = StarType.RedDwarf;
            else currentStarType = StarType.None;
        }

        public void MergeWith(PhysicsBody other)
        {
            if (other == null || other == this) return;
            float totalMass = mass + other.Mass;
            density = (density * mass + other.Density * other.Mass) / totalMass;
            velocity = (velocity * mass + other.Velocity * other.Mass) / totalMass;
            mass = totalMass;
            CheckStarFormation();
            Destroy(other.gameObject);
        }

        public bool CanMergeWith(PhysicsBody other, float mergeDistance = 1.0f)
        {
            if (other == null || other == this) return false;
            return Vector3.Distance(Position, other.Position) <= mergeDistance;
        }

        public void SetMass(float newMass) { mass = Mathf.Max(0f, newMass); CheckStarFormation(); }
        public void SetDensity(float newDensity) { density = Mathf.Max(0f, newDensity); CheckStarFormation(); }

        private void OnDrawGizmos()
        {
            if (Application.isPlaying && velocity.magnitude > 0.01f)
            {
                Gizmos.color = Color.cyan;
                Gizmos.DrawLine(transform.position, transform.position + velocity.normalized * 2f);
            }
        }
    }

    public enum StarType { None, RedDwarf, YellowStar, BlueGiant, BlackHole }
    public class ReadOnlyAttribute : PropertyAttribute { }
}
