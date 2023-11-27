using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TimeLabyrinth : MonoBehaviour
{
    /*Variable que representa el tiempo final, cuando se alcanza este tiempo, se carga la escena de Game Over.*/
    private float finalTime = 0f;
    /*Tiempo inicial que se va reduciendo en cada actualizacion.*/
    private float timmer = 35f;
    /*Referencia al objeto TextMeshProUGUI para mostrar el tiempo restante.*/
    public TextMeshProUGUI textTimmer;

    // Update is called once per frame
    /*Reducir el tiempo con el tiempo transcurrido desde el último frame.
     * Actualizar el texto que muestra el tiempo restante en el objeto TextMeshProUGUI.
     * Verificar si el tiempo ha llegado al valor final.
     * Cargar la escena llamada "GameOver". */
    void Update()
    {
        timmer -= Time.deltaTime;
        textTimmer.text = "Tiempo Restante: " + timmer.ToString("F0");
        if (timmer < finalTime)
        {
            SceneManager.LoadScene("GameOver");
        }
    }


}