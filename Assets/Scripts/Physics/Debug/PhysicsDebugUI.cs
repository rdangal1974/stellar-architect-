using UnityEngine;
using StellarArchitect.Physics.Systems;
using StellarArchitect.Physics.Components;

namespace StellarArchitect.Physics.Debug
{
    /// <summary>
    /// Runtime debug visualizer for physics system.
    /// Displays stability metrics, body count, and performance info.
    /// </summary>
    public class PhysicsDebugUI : MonoBehaviour
    {
        [Header("Display Settings")]
        [SerializeField] private bool showDebugUI = true;
        [SerializeField] private bool showBodyInfo = true;
        [SerializeField] private bool showStabilityInfo = true;
        [SerializeField] private bool showPerformanceInfo = true;

        [Header("UI Style")]
        [SerializeField] private int fontSize = 14;
        [SerializeField] private Color textColor = Color.white;
        [SerializeField] private Color backgroundColor = new Color(0, 0, 0, 0.7f);

        private GUIStyle labelStyle;
        private GUIStyle boxStyle;
        private float updateInterval = 0.5f;
        private float lastUpdateTime;

        // Cached values
        private int bodyCount;
        private float bindingEnergy;
        private bool isSystemStable;
        private float fps;

        private void Start()
        {
            SetupStyles();
        }

        private void Update()
        {
            if (!showDebugUI) return;

            // Update cached values periodically
            if (Time.time - lastUpdateTime > updateInterval)
            {
                UpdateCachedValues();
                lastUpdateTime = Time.time;
            }

            // Calculate FPS
            fps = 1.0f / Time.unscaledDeltaTime;
        }

        private void OnGUI()
        {
            if (!showDebugUI) return;
            
            // Setup styles if not already done (lazy initialization)
            if (labelStyle == null || boxStyle == null)
            {
                SetupStyles();
            }

            float yOffset = 10f;
            float lineHeight = fontSize + 4;

            GUI.Box(new Rect(10, yOffset, 350, GetTotalHeight()), "", boxStyle);
            yOffset += 10;

            // Title
            GUI.Label(new Rect(15, yOffset, 340, lineHeight), 
                "=== STELLAR ARCHITECT - PHYSICS DEBUG ===", labelStyle);
            yOffset += lineHeight + 5;

            // Body Info
            if (showBodyInfo)
            {
                GUI.Label(new Rect(15, yOffset, 340, lineHeight), 
                    $"Bodies: {bodyCount}", labelStyle);
                yOffset += lineHeight;
            }

            // Stability Info
            if (showStabilityInfo && GravitySystem.Instance != null)
            {
                Color originalColor = GUI.color;
                GUI.color = isSystemStable ? Color.green : Color.red;
                
                GUI.Label(new Rect(15, yOffset, 340, lineHeight), 
                    $"System Stable: {(isSystemStable ? "YES ?" : "NO ?")}", labelStyle);
                yOffset += lineHeight;
                
                GUI.color = originalColor;

                GUI.Label(new Rect(15, yOffset, 340, lineHeight), 
                    $"Binding Energy: {bindingEnergy:F3}", labelStyle);
                yOffset += lineHeight;
            }

            // Performance Info
            if (showPerformanceInfo)
            {
                Color originalColor = GUI.color;
                GUI.color = fps > 55 ? Color.green : (fps > 30 ? Color.yellow : Color.red);
                
                GUI.Label(new Rect(15, yOffset, 340, lineHeight), 
                    $"FPS: {fps:F1}", labelStyle);
                
                GUI.color = originalColor;
                yOffset += lineHeight;
            }

            // Instructions
            yOffset += 5;
            GUI.Label(new Rect(15, yOffset, 340, lineHeight), 
                "Press 'H' to toggle this UI", labelStyle);
        }

        private void UpdateCachedValues()
        {
            if (GravitySystem.Instance != null)
            {
                bodyCount = GravitySystem.Instance.GetAllBodies().Count;
                bindingEnergy = GravitySystem.Instance.GetSystemBindingEnergy();
                isSystemStable = GravitySystem.Instance.IsSystemStable();
            }
        }

        private float GetTotalHeight()
        {
            float lineHeight = fontSize + 4;
            float height = 30; // Base padding

            if (showBodyInfo) height += lineHeight;
            if (showStabilityInfo) height += lineHeight * 2;
            if (showPerformanceInfo) height += lineHeight;
            height += lineHeight; // Instructions

            return height;
        }

        private void SetupStyles()
        {
            labelStyle = new GUIStyle(GUI.skin.label)
            {
                fontSize = fontSize,
                normal = { textColor = textColor },
                fontStyle = FontStyle.Bold
            };

            boxStyle = new GUIStyle(GUI.skin.box)
            {
                normal = { background = MakeTexture(2, 2, backgroundColor) }
            };
        }

        private Texture2D MakeTexture(int width, int height, Color color)
        {
            Color[] pixels = new Color[width * height];
            for (int i = 0; i < pixels.Length; i++)
            {
                pixels[i] = color;
            }

            Texture2D texture = new Texture2D(width, height);
            texture.SetPixels(pixels);
            texture.Apply();
            return texture;
        }

        private void OnValidate()
        {
            // Don't setup styles here - will be done in OnGUI
            // This prevents "GUI functions can only be called from OnGUI" error
        }

        // Toggle UI with 'H' key
        private void LateUpdate()
        {
            if (Input.GetKeyDown(KeyCode.H))
            {
                showDebugUI = !showDebugUI;
            }
        }
    }
}
