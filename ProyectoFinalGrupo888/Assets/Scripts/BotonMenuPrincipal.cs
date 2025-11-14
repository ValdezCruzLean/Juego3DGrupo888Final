using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BotonMenuPrincipal : MonoBehaviour
{
    public void IrAlMenuPrincipal()
    {
        Time.timeScale = 1f;  // Por si la escena estaba pausada
        SceneManager.LoadScene("MenuInicial");
    }
}
