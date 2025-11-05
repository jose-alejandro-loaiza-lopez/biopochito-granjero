using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    [Header("Tiempos del sistema")]
    [Tooltip("Tiempo entre actualizaciones físicas (segundos)")]
    [SerializeField] private float fixedUpdateInterval = 0.02f;

    public enum GameState
    {
        MainMenu,
        Playing,
        Paused,
        GameOver
    }

    public GameState CurrentState { get; private set; }

    private void Awake()
    {
        // Patrón Singleton para que exista solo un GameManager
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject); // persiste entre escenas
        // Configurar tiempo fijo global
        Time.fixedDeltaTime = fixedUpdateInterval;
    }

    private void Start()
    {
        ChangeState(GameState.MainMenu);
    }

    public void ChangeState(GameState newState)
    {
        CurrentState = newState;

        switch (newState)
        {
            case GameState.MainMenu:
                Debug.Log("Estado: Menú principal");
                break;
            case GameState.Playing:
                Debug.Log("Estado: Jugando");
                break;
            case GameState.Paused:
                Debug.Log("Estado: Pausado");
                break;
            case GameState.GameOver:
                Debug.Log("Estado: Fin del juego");
                break;
        }
    }
}
