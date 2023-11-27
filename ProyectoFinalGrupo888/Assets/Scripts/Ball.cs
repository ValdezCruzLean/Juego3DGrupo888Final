using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{ /*Una variable privada que indica la posicion final en el eje Y, despues de la cual el objeto se destruira.*/
    private float posicionFinal;
    /*Una variable privada que almacena un valor num�rico inicializado en 1*/
    private int valorSuma = 1;


    /*En el m�todo Start, se establece la posicion final (posicionFinal) en -15.*/
    void Start()
    {
        posicionFinal = -15;
    }

    /*En el metodo Update, verifica si la posicion actual en el eje Y del objeto es menor o igual a la posicion final establecida.
     * Si es asi, el objeto se destruye y Resta puntos utilizando el método RestarPuntos del ScriptGameManager.*/
    void Update()
    {
        if (transform.position.y <= posicionFinal)
        {
            ScriptGameManager.instance.RestarPuntos();
            Destroy(this.gameObject);
        }
    }

    /*Este metodo se llama cuando el objeto colisiona con otro objeto en el juego. Si el objeto colisiona con un objeto que tenga la etiqueta "Jugador", 
     * se llama a la funcion SumarPuntos del script ScriptGameManager.instance, y luego se destruye el objeto.*/
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Jugador"))
        {
            ScriptGameManager.instance.SumarPuntos(valorSuma);
            Destroy(this.gameObject);
        }
       
    }


}