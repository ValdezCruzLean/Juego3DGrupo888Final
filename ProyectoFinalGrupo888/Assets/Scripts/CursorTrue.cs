using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorTrue : MonoBehaviour
{
    void Start()
    {
        // Reactiva el tiempo por si venías de un estado pausado
        Time.timeScale = 1f;

        // Libera el cursor para usar los botones
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
}
