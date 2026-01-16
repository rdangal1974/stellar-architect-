using UnityEngine;

namespace StellarArchitect.Physics.Components
{
    /// <summary>
    /// Draws a trail behind physics bodies to visualize orbital paths.
    /// Optimized for performance with limited trail length.
    /// </summary>
    [RequireComponent(typeof(PhysicsBody))]
    public class PhysicsBodyTrail : MonoBehaviour
    {
        [Header("Trail Settings")]
        [SerializeField, Tooltip("Enable trail rendering")]
        private bool enableTrail = true;

        [SerializeField, Tooltip("Trail duration in seconds")]
        private float trailTime = 5.0f;

        [SerializeField, Tooltip("Trail width")]
        private float trailWidth = 0.1f;

        [SerializeField, Tooltip("Trail color (inherits from body if null)")]
        private Color trailColor = new Color(1f, 1f, 1f, 0.5f);

        [SerializeField, Tooltip("Use gradient for trail (fade out)")]
        private bool useGradient = true;

        private TrailRenderer trailRenderer;
        private Renderer bodyRenderer;

        private void Awake()
        {
            SetupTrailRenderer();
        }

        private void Start()
        {
            // Get body color if available
            bodyRenderer = GetComponent<Renderer>();
            if (bodyRenderer != null && trailColor == Color.white)
            {
                trailColor = bodyRenderer.material.color;
                UpdateTrailColor();
            }
        }

        private void SetupTrailRenderer()
        {
            trailRenderer = gameObject.GetComponent<TrailRenderer>();
            
            if (trailRenderer == null)
            {
                trailRenderer = gameObject.AddComponent<TrailRenderer>();
            }

            // Configure trail
            trailRenderer.time = trailTime;
            trailRenderer.startWidth = trailWidth;
            trailRenderer.endWidth = trailWidth * 0.1f;
            trailRenderer.material = new Material(Shader.Find("Sprites/Default"));
            trailRenderer.sortingOrder = -1; // Behind objects

            // Set up gradient
            if (useGradient)
            {
                Gradient gradient = new Gradient();
                gradient.SetKeys(
                    new GradientColorKey[] 
                    { 
                        new GradientColorKey(trailColor, 0.0f), 
                        new GradientColorKey(trailColor, 1.0f) 
                    },
                    new GradientAlphaKey[] 
                    { 
                        new GradientAlphaKey(0.8f, 0.0f), 
                        new GradientAlphaKey(0.0f, 1.0f) 
                    }
                );
                trailRenderer.colorGradient = gradient;
            }
            else
            {
                trailRenderer.startColor = trailColor;
                trailRenderer.endColor = new Color(trailColor.r, trailColor.g, trailColor.b, 0f);
            }

            trailRenderer.enabled = enableTrail;
        }

        public void SetTrailEnabled(bool enabled)
        {
            enableTrail = enabled;
            if (trailRenderer != null)
            {
                trailRenderer.enabled = enabled;
            }
        }

        public void ClearTrail()
        {
            if (trailRenderer != null)
            {
                trailRenderer.Clear();
            }
        }

        public void UpdateTrailColor()
        {
            if (trailRenderer == null) return;

            if (useGradient)
            {
                Gradient gradient = new Gradient();
                gradient.SetKeys(
                    new GradientColorKey[] 
                    { 
                        new GradientColorKey(trailColor, 0.0f), 
                        new GradientColorKey(trailColor, 1.0f) 
                    },
                    new GradientAlphaKey[] 
                    { 
                        new GradientAlphaKey(0.8f, 0.0f), 
                        new GradientAlphaKey(0.0f, 1.0f) 
                    }
                );
                trailRenderer.colorGradient = gradient;
            }
            else
            {
                trailRenderer.startColor = trailColor;
                trailRenderer.endColor = new Color(trailColor.r, trailColor.g, trailColor.b, 0f);
            }
        }

        private void OnValidate()
        {
            if (trailRenderer != null)
            {
                trailRenderer.time = trailTime;
                trailRenderer.startWidth = trailWidth;
                trailRenderer.endWidth = trailWidth * 0.1f;
                trailRenderer.enabled = enableTrail;
                UpdateTrailColor();
            }
        }
    }
}
