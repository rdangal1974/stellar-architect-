using UnityEngine;
using UnityEditor;
using StellarArchitect.Physics.Components;
using StellarArchitect.Physics.Systems;

namespace StellarArchitect.Physics.Editor
{
    /// <summary>
    /// Editor utility to quickly set up physics test scenes.
    /// Creates GravitySystem, PhysicsConstants, and sample physics bodies.
    /// </summary>
    public static class PhysicsSceneSetup
    {
        [MenuItem("Stellar Architect/Physics/Create Test Scene (2 Bodies)")]
        public static void CreateTwoBodyTestScene()
        {
            CreatePhysicsManager();
            CreatePhysicsBody("Star 1 (Red Dwarf)", Vector3.zero, 0.5f, 0.5f, Color.red);
            CreatePhysicsBody("Star 2 (Yellow Star)", new Vector3(5f, 0f, 0f), 1.5f, 0.7f, Color.yellow);
            
            SetupCamera();
            
            UnityEngine.Debug.Log("? Two-body test scene created! Press Play to test gravity.");
        }

        [MenuItem("Stellar Architect/Physics/Create Test Scene (3 Bodies)")]
        public static void CreateThreeBodyTestScene()
        {
            CreatePhysicsManager();
            CreatePhysicsBody("Star 1 (Red Dwarf)", Vector3.zero, 0.5f, 0.5f, Color.red);
            CreatePhysicsBody("Star 2 (Yellow Star)", new Vector3(5f, 0f, 0f), 1.5f, 0.7f, Color.yellow);
            CreatePhysicsBody("Star 3 (Red Dwarf)", new Vector3(0f, 5f, 0f), 0.5f, 0.5f, new Color(1f, 0.5f, 0f));
            
            SetupCamera();
            
            UnityEngine.Debug.Log("? Three-body test scene created! Press Play to test gravity.");
        }

        [MenuItem("Stellar Architect/Physics/Create Test Scene (Binary System)")]
        public static void CreateBinarySystemTestScene()
        {
            CreatePhysicsManager();
            
            // Binary system with initial velocities for orbit
            var star1 = CreatePhysicsBody("Star A (Yellow)", new Vector3(-2.5f, 0f, 0f), 1.0f, 0.6f, Color.yellow);
            var star2 = CreatePhysicsBody("Star B (Yellow)", new Vector3(2.5f, 0f, 0f), 1.0f, 0.6f, new Color(1f, 0.8f, 0f));
            
            // Set initial velocities for circular orbit
            star1.Velocity = new Vector3(0f, 0f, 1.0f);
            star2.Velocity = new Vector3(0f, 0f, -1.0f);
            
            SetupCamera();
            
            UnityEngine.Debug.Log("? Binary system test scene created! Stars should orbit each other.");
        }

        [MenuItem("Stellar Architect/Physics/Create Physics Constants Asset")]
        public static void CreatePhysicsConstantsAsset()
        {
            string path = "Assets/ScriptableObjects/Physics";
            
            // Create directory if it doesn't exist
            if (!AssetDatabase.IsValidFolder("Assets/ScriptableObjects"))
            {
                AssetDatabase.CreateFolder("Assets", "ScriptableObjects");
            }
            if (!AssetDatabase.IsValidFolder(path))
            {
                AssetDatabase.CreateFolder("Assets/ScriptableObjects", "Physics");
            }

            // Create PhysicsConstants asset
            var constants = ScriptableObject.CreateInstance<Config.PhysicsConstants>();
            string assetPath = $"{path}/DefaultPhysicsConstants.asset";
            
            AssetDatabase.CreateAsset(constants, assetPath);
            AssetDatabase.SaveAssets();
            
            EditorUtility.FocusProjectWindow();
            Selection.activeObject = constants;
            
            UnityEngine.Debug.Log($"? PhysicsConstants asset created at: {assetPath}");
        }

        private static void CreatePhysicsManager()
        {
            // Check if GravitySystem already exists
            var existing = GameObject.Find("Physics Manager");
            if (existing != null)
            {
                UnityEngine.Debug.LogWarning("?? Physics Manager already exists. Using existing instance.");
                return;
            }

            GameObject manager = new GameObject("Physics Manager");
            var gravitySystem = manager.AddComponent<GravitySystem>();
            
            // Try to find existing PhysicsConstants asset
            var constants = AssetDatabase.FindAssets("t:PhysicsConstants");
            if (constants.Length > 0)
            {
                string assetPath = AssetDatabase.GUIDToAssetPath(constants[0]);
                var constantsAsset = AssetDatabase.LoadAssetAtPath<Config.PhysicsConstants>(assetPath);
                
                // Use reflection to set the private field (for editor setup)
                var field = typeof(GravitySystem).GetField("physicsConstants", 
                    System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
                field?.SetValue(gravitySystem, constantsAsset);
                
                UnityEngine.Debug.Log($"? Physics Manager created with constants: {assetPath}");
            }
            else
            {
                UnityEngine.Debug.LogWarning("?? No PhysicsConstants asset found. Use menu: Stellar Architect/Physics/Create Physics Constants Asset");
            }
        }

        private static PhysicsBody CreatePhysicsBody(string name, Vector3 position, float mass, float scale, Color color)
        {
            GameObject obj = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            obj.name = name;
            obj.transform.position = position;
            obj.transform.localScale = Vector3.one * scale;

            // Add PhysicsBody component
            var body = obj.AddComponent<PhysicsBody>();
            
            // Set mass using reflection (private field)
            var massField = typeof(PhysicsBody).GetField("mass", 
                System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
            massField?.SetValue(body, mass);

            // Add auto-registration
            obj.AddComponent<PhysicsBodyAutoRegister>();

            // Set material color
            var renderer = obj.GetComponent<Renderer>();
            var material = new Material(Shader.Find("Standard"));
            material.color = color;
            material.SetFloat("_Metallic", 0.5f);
            material.SetFloat("_Glossiness", 0.8f);
            renderer.material = material;

            // Add emissive glow
            material.EnableKeyword("_EMISSION");
            material.SetColor("_EmissionColor", color * 0.5f);

            return body;
        }

        private static void SetupCamera()
        {
            var camera = Camera.main;
            if (camera == null)
            {
                GameObject cameraObj = new GameObject("Main Camera");
                camera = cameraObj.AddComponent<Camera>();
                cameraObj.tag = "MainCamera";
            }

            camera.transform.position = new Vector3(0f, 10f, -10f);
            camera.transform.LookAt(Vector3.zero);
            camera.backgroundColor = new Color(0.05f, 0.05f, 0.1f); // Dark space background
        }
    }
}
