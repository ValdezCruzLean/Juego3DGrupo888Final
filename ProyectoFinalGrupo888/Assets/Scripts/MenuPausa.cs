using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPausa : MonoBehaviour
{
    [Header("Panel Principal del Menu de Pausa")]
    [SerializeField] private GameObject panelPausa;

    [Header("Botones (Activar/Desactivar según escena)")]
    [SerializeField] private GameObject btnReiniciar;   // Solo minijuegos
    [SerializeField] private GameObject btnLobby;       // Lobby + minijuegos
    [SerializeField] private GameObject btnSalir;       // Lobby + minijuegos

    private bool esLobby;

    void Start()
    {
        panelPausa.SetActive(false);
        Time.timeScale = 1f;

        // Detectar si estamos en el lobby
        string nombreEscena = SceneManager.GetActiveScene().name;
        esLobby = nombreEscena.Contains("Lobby");

        // Ajustar botones según dónde estamos
        ConfigurarBotones();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            AlternarPausa();
        }
    }

    private void ConfigurarBotones()
    {
        // En el lobby NO hay botón reiniciar
        if (btnReiniciar != null)
            btnReiniciar.SetActive(!esLobby);

        // Lobby y Salir siempre visibles
        if (btnLobby != null)
            btnLobby.SetActive(true);

        if (btnSalir != null)
            btnSalir.SetActive(true);
    }

    private void AlternarPausa()
    {
        bool activo = !panelPausa.activeSelf;
        panelPausa.SetActive(activo);
        Time.timeScale = activo ? 0f : 1f;
    }

    public void Reanudar()
    {
        AlternarPausa();
    }

    public void Reiniciar()
    {
        if (!esLobby)
        {
            Time.timeScale = 1f;
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    public void Lobby()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("salaPrincipal");
    }

    public void Salir()
    {
        Application.Quit();
    }
}
