using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorFixLobby : MonoBehaviour
{
    [Header("Script de cámara del Lobby")]
    [SerializeField] private MonoBehaviour cameraScript;

    [Header("Panel de menú del Lobby")]
    [SerializeField] private GameObject panelMenu;

    private bool menuActivo = false;

    void Start()
    {
        // Cuando entrás al lobby, todo normal
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        if (cameraScript != null) cameraScript.enabled = true;
    }

    void Update()
    {
        if (panelMenu == null) return;

        // Detecta si el menú está activo
        if (panelMenu.activeSelf && !menuActivo)
        {
            ActivarModoMenu();
        }
        else if (!panelMenu.activeSelf && menuActivo)
        {
            ActivarModoJuego();
        }
    }

    void ActivarModoMenu()
    {
        menuActivo = true;

        // Cursor libre
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        // Bloquear movimiento de cámara
        if (cameraScript != null)
            cameraScript.enabled = false;
    }

    void ActivarModoJuego()
    {
        menuActivo = false;

        // Cursor bloqueado
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        // Habilitar cámara
        if (cameraScript != null)
            cameraScript.enabled = true;
    }
}