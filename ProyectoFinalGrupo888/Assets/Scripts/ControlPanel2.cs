using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PanelInicioManager : MonoBehaviour
{
    [SerializeField] private GameObject panelInicio;
    [SerializeField] private GameObject canvasHUD;

    private static HashSet<string> escenasYaMostradas = new HashSet<string>();

    private string escenaActual;

    private void Awake()
    {
        escenaActual = SceneManager.GetActiveScene().name;

        bool yaMostrado = escenasYaMostradas.Contains(escenaActual);

        if (!yaMostrado)
        {
            // Primera vez en esta escena
            Time.timeScale = 0f;
            AudioListener.pause = true;

            panelInicio.SetActive(true);
            canvasHUD.SetActive(false);
        }
        else
        {
            // Ya visto → entrar directo
            panelInicio.SetActive(false);
            canvasHUD.SetActive(true);

            Time.timeScale = 1f;
            AudioListener.pause = false;
        }
    }

    public void Jugar()
    {
        Time.timeScale = 1f;
        AudioListener.pause = false;

        panelInicio.SetActive(false);
        canvasHUD.SetActive(true);

        // Marcar esta escena como “ya mostrado”
        escenasYaMostradas.Add(escenaActual);
    }

    // Se llama desde el lobby
    public static void ResetearTodosLosPaneles()
    {
        escenasYaMostradas.Clear();
    }
}
