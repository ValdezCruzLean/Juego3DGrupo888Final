using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goalkeeper : MonoBehaviour
{
    public GameObject Ball;
    private float changedirectionX = 4f;

    void Update()
    {
        Move();
    }
    public void Move()
    {
        //Se encarga del movimiento del arquero(usando la logica del trabajo practico 3d)
        if (transform.position.x < -2.1f || transform.position.x > 2.3f)

        {
            changedirectionX *= -1;
        }
        transform.Translate(changedirectionX * Time.deltaTime, 0, 0);
    }

    private void OnCollisionEnter(Collision collision)
    {
        //verifica la colicion con el arquero
        if (collision.gameObject.CompareTag("Ball"))
        {
            // hace que el generador, al colisionar la pelota, genere otra
            GeneratorBall generator = FindObjectOfType<GeneratorBall>();
            if (generator != null)
            {
                generator.GenerateBall();
            }
            //destruye la pelota al colisionar la pelota
            Destroy(collision.gameObject);
            //resta un punto al colisionar
            ScriptGameManager.instance.RestarPuntos();
        }
    }
}
