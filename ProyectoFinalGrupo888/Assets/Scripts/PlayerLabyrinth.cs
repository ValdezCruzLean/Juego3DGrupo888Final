using UnityEngine;

public class PlayerLabyrinth : MonoBehaviour
{
    [Header("Velocidades del jugador")]
    [SerializeField] private float velocidadX = 6f;  // Unidades por segundo
    [SerializeField] private float velocidadY = 6f;  // Unidades por segundo

    [Header("Posición límite")]
    [SerializeField] private float positionFinal = -20f;

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        gameObject.SetActive(true);
    }

    void Update()
    {
        // Entradas del jugador
        float movimientoX = Input.GetAxis("Horizontal");
        float movimientoY = Input.GetAxis("Vertical");

        // Movimiento usando Rigidbody (sin deltaTime)
        Mover(movimientoX, movimientoY);

        // Destruye el jugador si supera la posición límite
        if (transform.position.x < positionFinal)
        {
            Destroy(gameObject);
        }
    }

    private void Mover(float movimientoX, float movimientoY)
    {
        // Calculamos la velocidad deseada (en unidades/segundo)
        Vector3 nuevaVelocidad = new Vector3(
            movimientoX * velocidadX,
            movimientoY * velocidadY,
            rb.velocity.z
        );

        // Asignamos la velocidad al Rigidbody
        rb.velocity = nuevaVelocidad;
    }
}