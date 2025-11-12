using System.Collections;
using System.Collections.Generic;
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
        resultText.text = playerWon ? "¡GANASTE!" : "PERDISTE";
        Time.timeScale = 0f; // Pausar juego
    }

    public void Retry()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void ReturnToLobby()
    {
        Time.timeScale = 1f;
        UnityEngine.SceneManagement.SceneManager.LoadScene("salaPrincipal"); // Cambiá "Lobby" por el nombre real de tu escena de sala
    }
}
