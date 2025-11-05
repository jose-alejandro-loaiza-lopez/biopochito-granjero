using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuUI : MonoBehaviour
{
    [SerializeField] private GameObject pausePanel;
    private bool isPaused = false;

    void Update()
    {
        // Pausar con tecla ESC
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused) Resume();
            else Pause();
        }
    }

    public void Pause()
    {
        pausePanel.SetActive(true);
        Time.timeScale = 0f; // Pausa toda la simulación
        isPaused = true;
        GameManager.Instance.ChangeState(GameManager.GameState.Paused);
    }

    public void Resume()
    {
        pausePanel.SetActive(false);
        Time.timeScale = 1f; // Reanuda el tiempo
        isPaused = false;
        GameManager.Instance.ChangeState(GameManager.GameState.Playing);
    }

    public void OpenOptions()
    {
        Debug.Log("Abrir opciones (pendiente)");
        // Aquí puedes mostrar otro panel más adelante
    }

    public void ExitToMenu()
    {
        Time.timeScale = 1f; // Asegurarse de reanudar antes de cambiar escena
        SceneManager.LoadScene("Menu");
        GameManager.Instance.ChangeState(GameManager.GameState.MainMenu);
    }
}
