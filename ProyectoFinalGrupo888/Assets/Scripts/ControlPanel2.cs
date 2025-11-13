using UnityEngine;
using UnityEngine.SceneManagement;

public class PanelInicioManager : MonoBehaviour
{
    [SerializeField] private GameObject panelInicio;
    [SerializeField] private GameObject canvasHUD;

    private static bool yaMostrado = false;
    private static bool reinicio = false;

    private void Awake()
    {
        // Si la escena se cargó desde un reinicio, no mostrar el panel
        if (reinicio)
        {
            yaMostrado = true;
            reinicio = false; // reseteamos para próximas entradas
        }

        // Mostrar o no el panel según el estado
        if (!yaMostrado)
        {
            Time.timeScale = 0f;
            AudioListener.pause = true;

            if (panelInicio != null) panelInicio.SetActive(true);
            if (canvasHUD != null) canvasHUD.SetActive(false);
        }
        else
        {
            if (panelInicio != null) panelInicio.SetActive(false);
            if (canvasHUD != null) canvasHUD.SetActive(true);
            Time.timeScale = 1f;
            AudioListener.pause = false;
        }
    }

    public void Jugar()
    {
        Time.timeScale = 1f;
        AudioListener.pause = false;

        if (panelInicio != null) panelInicio.SetActive(false);
        if (canvasHUD != null) canvasHUD.SetActive(true);

        yaMostrado = true;
    }

    // 🔁 Llamar cuando se usa el botón "Reiniciar"
    public static void MarcarReinicio()
    {
        reinicio = true;
    }

    // 🏠 Llamar cuando se vuelve al lobby (desde botón "Volver al menú")
    public static void ReiniciarPanel()
    {
        yaMostrado = false;
        reinicio = false;
    }
}
