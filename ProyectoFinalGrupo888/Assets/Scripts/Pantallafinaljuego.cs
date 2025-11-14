using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pantallafinaljuego : MonoBehaviour
{
    public TextMeshProUGUI resultText;
    public GameObject uiPanel;

    public void ShowEndGame(bool playerWon)
    {
        uiPanel.SetActive(true);
        resultText.text = playerWon ? "¡GANASTE!" : "PERDISTE!";

        Time.timeScale = 0f;
        AudioListener.pause = true;
    }

    public void Retry()
    {
        Time.timeScale = 1f;
        AudioListener.pause = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void ReturnToLobby()
    {
        PanelInicioManager.ResetearTodosLosPaneles();

        Time.timeScale = 1f;
        AudioListener.pause = false;

        SceneManager.LoadScene("salaPrincipal");
    }
}