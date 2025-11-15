using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerBalls : MonoBehaviour
{
    /* Variable privada que representa la velocidad en el eje X*/
    [SerializeField] private float velocidadX = -5f;
    /*Es una variable privada que indica la posición inicial en el eje X.*/
    private float inicialPosicionX = 15f;
    /*Es una variable privada que indica la posición final en el eje X.*/
    private float finalPosicionX = -15f;
    /*Es una variable de tipo GameObject que se asignará desde el inspector el enemigo que se generará.*/
    [SerializeField] private GameObject enemigo01;
   

    // Start is called before the first frame update
    /*En el metodo Start(), se utiliza InvokeRepeating para llamar repetidamente al método GenerarEnemigo
     * Esto significa que GenerarEnemigo se ejecutará cada 3.5 segundos después de que el juego comience.*/
    void Start()
    {
        InvokeRepeating("GenerarEnemigo", 0, 4f);
    }

    // Update is called once per frame
    /*En el metodo Update() mueve el GameObject  a lo largo del eje X utilizando Translate.
     * Luego, verifica si la posición actual en el eje X es mayor o igual a finalPosicionX o menor o igual a inicialPosicionX. 
     * Si es así, invierte la dirección de movimiento multiplicando velocidadZ por -1.*/
    void Update()
    {
        transform.Translate(velocidadX * Time.deltaTime, 0, 0);

        if (transform.position.x <= finalPosicionX || transform.position.x >= inicialPosicionX)
        {
           
                velocidadX = velocidadX * -1;
            
        }
    }
    /*Metodo para generar enemigos se utiliza la función Instantiate para crear una instancia de un objeto.
     pasando primero el objeto despues su posicion (que es la de nuestro spawner)y por ultimo 
     Quaternion.identity diciendo que wl objeto enemigo se instanciará sin ninguna rotación*/
    public void GenerarEnemigo()
    {
            Instantiate(enemigo01, transform.position, Quaternion.identity);
        
    }
}