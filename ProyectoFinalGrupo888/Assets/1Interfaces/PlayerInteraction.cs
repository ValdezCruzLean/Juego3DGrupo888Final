using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerInteraction : MonoBehaviour
{
    [Header("Configuración del Raycast")]
    [SerializeField] private float distanciaRayo = 3f;
    [SerializeField] private LayerMask capaInteractuable; // Capas de las máquinas

    [Header("HUD")]
    [SerializeField] private GameObject mensajeUI; // Texto o panel "Presione E para jugar"

    private Transform camTransform;

    void Start()
    {
        // Usa la cámara principal si no está asignada manualmente
        camTransform = Camera.main != null ? Camera.main.transform : transform;

        // Oculta el mensaje al inicio
        if (mensajeUI != null)
            mensajeUI.SetActive(false);
    }

    void Update()
    {
        DetectarObjeto();
    }

    private void DetectarObjeto()
    {
        Ray rayo = new Ray(camTransform.position, camTransform.forward);
        RaycastHit hit;

        // Dibuja el rayo (visible en la vista Scene)
        Debug.DrawRay(camTransform.position, camTransform.forward * distanciaRayo, Color.yellow);

        if (Physics.Raycast(rayo, out hit, distanciaRayo, capaInteractuable))
        {
            // Obtiene la capa del objeto golpeado
            int layer = hit.collider.gameObject.layer;

            // Muestra el mensaje en pantalla
            if (mensajeUI != null)
                mensajeUI.SetActive(true);

            // Detecta si se presiona la tecla E
            if (Input.GetKeyDown(KeyCode.E))
            {
                // Cambia de escena según la capa
                if (layer == LayerMask.NameToLayer("Pachinko"))
                {
                    SceneManager.LoadScene("Pachinko");
                }
                else if (layer == LayerMask.NameToLayer("Laberinto"))
                {
                    SceneManager.LoadScene("Laberinto");
                }
                else if (layer == LayerMask.NameToLayer("Futbol"))
                {
                    SceneManager.LoadScene("Futbol");
                }
            }
        }
        else
        {
            // Si no está mirando nada interactuable, oculta el mensaje
            if (mensajeUI != null)
                mensajeUI.SetActive(false);
        }
    }
}