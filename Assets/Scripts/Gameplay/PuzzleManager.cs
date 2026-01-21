using UnityEngine;
using StellarArchitect.Physics.Components;
using StellarArchitect.Physics.Systems;

namespace StellarArchitect.Gameplay
{
    public class PuzzleManager : MonoBehaviour
    {
        [Header("Puzzle Goal")]
        [SerializeField] private StarType targetStarType = StarType.RedDwarf;
        [SerializeField] private bool requireStability = false;
        [SerializeField] private float timeLimit = 0f;

        [Header("Puzzle State")]
        [SerializeField, ReadOnly] private PuzzleState currentState = PuzzleState.NotStarted;
        [SerializeField, ReadOnly] private float elapsedTime = 0f;
        [SerializeField, ReadOnly] private int attemptCount = 0;

        private StarFormationDetector formationDetector;
        private bool puzzleCompleted = false;

        public PuzzleState CurrentState => currentState;
        public StarType TargetStarType => targetStarType;
        public float ElapsedTime => elapsedTime;
        public int AttemptCount => attemptCount;

        private void Awake()
        {
            formationDetector = GetComponent<StarFormationDetector>();
            if (formationDetector == null)
            {
                formationDetector = gameObject.AddComponent<StarFormationDetector>();
            }
        }

        private void Start()
        {
            StartPuzzle();
        }

        private void Update()
        {
            if (currentState != PuzzleState.Playing) return;

            elapsedTime += Time.deltaTime;

            if (timeLimit > 0 && elapsedTime >= timeLimit)
            {
                FailPuzzle("Time limit exceeded!");
                return;
            }

            if (!puzzleCompleted)
            {
                CheckWinCondition();
            }
        }

        public void StartPuzzle()
        {
            currentState = PuzzleState.Playing;
            elapsedTime = 0f;
            attemptCount++;
            puzzleCompleted = false;
        }

        public void RestartPuzzle()
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(
                UnityEngine.SceneManagement.SceneManager.GetActiveScene().name
            );
        }

        private void CheckWinCondition()
        {
            var formedStars = formationDetector.CheckAllBodies();

            foreach (var (body, starType) in formedStars)
            {
                if (starType == targetStarType)
                {
                    if (requireStability)
                    {
                        // Stability check removed for v1.0 - always win if star forms
                        WinPuzzle(body);
                    }
                    else
                    {
                        WinPuzzle(body);
                    }
                }
            }
        }

        private void WinPuzzle(PhysicsBody winningBody)
        {
            if (puzzleCompleted) return;

            puzzleCompleted = true;
            currentState = PuzzleState.Won;

            Debug.Log($"<color=green>PUZZLE WON!</color> Formed {targetStarType} in {elapsedTime:F1}s");
        }

        private void FailPuzzle(string reason)
        {
            if (puzzleCompleted) return;

            puzzleCompleted = true;
            currentState = PuzzleState.Failed;

            Debug.Log($"<color=red>PUZZLE FAILED:</color> {reason}");
        }

        private void OnGUI()
        {
            if (!Application.isPlaying) return;

            GUILayout.BeginArea(new Rect(10, 10, 300, 150));
            GUILayout.Label("=== PUZZLE STATUS ===");
            GUILayout.Label($"State: {currentState}");
            GUILayout.Label($"Goal: Form a {targetStarType}");
            GUILayout.Label($"Time: {elapsedTime:F1}s");
            GUILayout.Label($"Attempts: {attemptCount}");

            if (timeLimit > 0)
            {
                float remaining = timeLimit - elapsedTime;
                GUILayout.Label($"Time Remaining: {remaining:F1}s");
            }

            if (currentState == PuzzleState.Won)
            {
                GUILayout.Label("<color=green>SUCCESS!</color>");
            }
            else if (currentState == PuzzleState.Failed)
            {
                if (GUILayout.Button("Restart"))
                {
                    RestartPuzzle();
                }
            }

            GUILayout.EndArea();
        }
    }

    public enum PuzzleState
    {
        NotStarted,
        Playing,
        Won,
        Failed,
        Paused
    }
}
