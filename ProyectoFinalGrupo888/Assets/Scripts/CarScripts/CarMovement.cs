using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarMovement : MonoBehaviour
{
    //Variable que regula la velocidad del jugador
    private float velocidad = 2000f;
    //Variable que contiene el RigidBody
    private Rigidbody rb;

    //se llama al inicio, obtiene el RB
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    //movimientoX almacena el movimiento hacia la izquierda y derecha
    void Update()
    {
        float movimientoX = Input.GetAxis("Horizontal");
        MoverX(velocidad * movimientoX);

        float movimientoZ = Input.GetAxis("Vertical");
        MoverZ(velocidad * movimientoZ);

    }
    //este metodo sirve para mover al personaje, actualizandolo constantemente en X
    public void MoverX(float velocidadX)
    {
        rb.velocity = new Vector3(velocidadX * Time.deltaTime, rb.velocity.y, rb.velocity.z);
    }
     public void MoverZ(float velocidadZ)
    {
        rb.velocity = new Vector3(rb.velocity.x,rb.velocity.y,velocidadZ * Time.deltaTime );
    }

}
