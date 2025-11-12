using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReiniciarNivel : MonoBehaviour
{
    public void Reiniciar()
    {
        Time.timeScale = 1f;                // Reactiva el tiempo
        Cursor.lockState = CursorLockMode.None; // Libera el mouse por si estaba bloqueado
        Cursor.visible = true;              // Asegura que se vea
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); // Recarga escena
    }
}
