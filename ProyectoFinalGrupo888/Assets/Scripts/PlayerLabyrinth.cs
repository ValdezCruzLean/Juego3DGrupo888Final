using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLabyrinth : MonoBehaviour
{
    /*Veriable que representa la velocidad a la que se mover� el jugador en el ejeX*/
    [SerializeField] private float velocidadX = -600f;
    /*Veriable que representa la velocidad a la que se mover� el jugador en el ejeY*/
    [SerializeField] private float velocidadY = 600f;
    /*Veriable que representa la posicion final del jugador*/
    [SerializeField] private float positionFinal = -20;
    /*Es una variable privada que contendr� el componente Rigidbody del GameObject*/
    private Rigidbody rb;

    // Start is called before the first frame update
    /*Se llama al inicio del juego. Se obtiene el componente Rigidbody del GameObject */
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    // Update is called once per frame
    /*Obtiene la entrada del eje horizontal con las teclas izquierda y derecha y la almacena en movimientoX.
     * Llama al metodo MoveX() con la velocidad calculada multiplicando velocidad por el valor de entrada horizontal controlando el movimiento lateral del jugador.
      *Obtiene la entrada del eje vertical con las teclas arriba y abajo y la almacena en movimientoY.
     * Llama al metodo MoveY() con la velocidad calculada multiplicando velocidad por el valor de entrada horizontal controlando el movimiento lateral del jugador..*/

    void Update()
    {
        float movimientoX = Input.GetAxis("Horizontal");
        MoverX(velocidadX * movimientoX);
        float movimientoY = Input.GetAxis("Vertical");
        MoverY(velocidadY * movimientoY);
        if (this.transform.position.x < positionFinal)
        {
            Destroy(this.gameObject);
        }

    }
    /* Este m�todo se encarga de mover el jugador.
  * MoveX Actualiza la velocidad del componente Rigidbody en el eje X. La velocidad en los ejes Y Z permanece sin cambios. 
  * MoveY Actualiza la velocidad del componente Rigidbody en el eje Y. La velocidad en los ejes X Z permanece sin cambios.*/
    public void MoverX(float velocidadX)
    {
        rb.velocity = new Vector3(velocidadX * Time.deltaTime, rb.velocity.y, rb.velocity.z);
    }
    public void MoverY(float velocidadY)
    {
        rb.velocity = new Vector3(rb.velocity.x, velocidadY * Time.deltaTime, rb.velocity.z);
    }


}