using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    /*Veriable que representa la velocidad a la que se mover� el jugador,*/
   private float velocidad = -1500f;
    /*Es una variable privada que contendra el componente Rigidbody del GameObject*/
    private Rigidbody rb;

    // Start is called before the first frame update
    /*Se llama al inicio del juego. Se obtiene el componente Rigidbody del GameObject */
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    // Update is called once per frame
    /*Obtiene la entrada del eje horizontal con las teclas izquierda y derecha  y la almacena en movimientoX.
     * Llama al metodo Move() con la velocidad calculada multiplicando velocidad por el valor de entrada horizontal controlando el movimiento lateral del jugador.
     */

    void Update()
    {
        float movimientoX = Input.GetAxis("Horizontal");
        Mover(velocidad * movimientoX);
       
    }
    /* Este metodo se encarga de mover el jugador.
     * Actualiza la velocidad del componente Rigidbody en el eje X. La velocidad en los ejes Y Z permanece sin cambios. */
    public void Mover(float velocidadX)
    {
        rb.velocity = new Vector3(velocidadX * Time.deltaTime, rb.velocity.y, rb.velocity.z);
    }
   
   
}