using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuUI : MonoBehaviour
{
    [SerializeField] private string gameSceneName = "Main"; // Nombre de la escena principal

    public void PlayGame()
    {
        SceneManager.LoadScene(gameSceneName);
        GameManager.Instance.ChangeState(GameManager.GameState.Playing);
    }

    public void QuitGame()
    {
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #else
        Application.Quit();
        #endif
    }

    public void OpenOptions()
    {
        Debug.Log("Abrir opciones próximamente...");
        // Aquí puedes cargar otro panel o escena con las opciones.
    }
}
