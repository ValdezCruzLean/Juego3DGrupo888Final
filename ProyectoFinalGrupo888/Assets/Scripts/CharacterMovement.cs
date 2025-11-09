using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class CharacterMovement : MonoBehaviour
{
    [Header("Velocidad del jugador (unidades por segundo)")]
    [SerializeField] private float velocidad = 3f; // Recomendado: entre 2 y 6

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();

        // Evita que la física afecte rotación o caída si no querés gravedad
        rb.freezeRotation = true;
        rb.useGravity = false;
    }

    void Update()
    {
        float movimientoX = Input.GetAxis("Horizontal");
        Mover(movimientoX);
    }

    private void Mover(float movimientoX)
    {
        // Movimiento horizontal (en el eje X)
        Vector3 movimiento = new Vector3(movimientoX, 0f, 0f);

        // Mueve al jugador suavemente con respecto al tiempo
        rb.MovePosition(rb.position + movimiento * velocidad * Time.deltaTime);
    }
}
