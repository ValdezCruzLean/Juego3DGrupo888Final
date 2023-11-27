using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LabyrinthRaycast : MonoBehaviour
{   /*Variable que representa el rango maximo del rayo.*/
    private float range = 10f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    /* RaycastHit hit Estructura que almacena información sobre el rayo lanzado.
     * Lanzar un rayo hacia adelante desde la posicion actual del objeto.
     * El rayo tiene una longitud igual al rango especificado.
     * Verificar si el rayo ha golpeado un objeto (collider).
     * Carga la escena "YouWin" si el rayo golpea un objeto.  .*/
    void Update()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, range))
        {
            if(hit.collider != null)
            {
                SceneManager.LoadScene("YouWin");
            }
        }
       
    }
    /*Metodo llamado en el editor para dibujar gizmos que ayudan en la visualizacion.
     * Establece el color de los gizmos a amarillo.
     * Dibujar el rayo en el editor, desde la posición del objeto hacia adelante multiplicado por el rango.*/
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawRay(transform.position, transform.forward * range);
    }
}