using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerBalls : MonoBehaviour
{
    /* Variable privada que representa la velocidad en el eje X*/
    [SerializeField] private float velocidadX = -5f;
    /*Es una variable privada que indica la posici�n inicial en el eje X.*/
    private float inicialPosicionX = 15f;
    /*Es una variable privada que indica la posici�n final en el eje X.*/
    private float finalPosicionX = -15f;
    /*Es una variable de tipo GameObject que se asignar� desde el inspector el enemigo que se generar�.*/
    [SerializeField] private GameObject enemigo01;
   

    // Start is called before the first frame update
    /*En el metodo Start(), se utiliza InvokeRepeating para llamar repetidamente al m�todo GenerarEnemigo
     * Esto significa que GenerarEnemigo se ejecutar� cada 2 segundos despu�s de que el juego comience.*/
    void Start()
    {
        InvokeRepeating("GenerarEnemigo", 0, 3.5f);
    }

    // Update is called once per frame
    /*En el metodo Update() mueve el GameObject  a lo largo del eje X utilizando Translate.
     * Luego, verifica si la posici�n actual en el eje X es mayor o igual a finalPosicionX o menor o igual a inicialPosicionX. 
     * Si es as�, invierte la direcci�n de movimiento multiplicando velocidadZ por -1.*/
    void Update()
    {
        transform.Translate(velocidadX * Time.deltaTime, 0, 0);

        if (transform.position.x <= finalPosicionX || transform.position.x >= inicialPosicionX)
        {
           
                velocidadX = velocidadX * -1;
            
        }
    }

    public void GenerarEnemigo()
    {
            Instantiate(enemigo01, transform.position, Quaternion.identity);
        
    }
}