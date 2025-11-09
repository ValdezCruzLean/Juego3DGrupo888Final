using UnityEngine;

public class Goalkeeper : MonoBehaviour
{
    [Header("Movimiento Oscilante")]
    [SerializeField] private float distancia = 2f;             // Amplitud del movimiento
    [SerializeField] private float velocidad = 2f;             // Velocidad inicial de oscilación
    [SerializeField] private float incrementoVelocidad = 0.5f; // Aumento de velocidad por evento

    [Header("Pelota")]
    [SerializeField] private GameObject Ball;

    private Vector3 posicionInicial;

    void Start()
    {
        posicionInicial = transform.position;
    }

    void Update()
    {
        MoverOscilante();
    }

    private void MoverOscilante()
    {
        float desplazamientoX = Mathf.Sin(Time.time * velocidad) * distancia;
        transform.position = new Vector3(posicionInicial.x + desplazamientoX, posicionInicial.y, posicionInicial.z);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            // Generar una nueva pelota
            GeneratorBall generator = FindObjectOfType<GeneratorBall>();
            if (generator != null)
                generator.GenerateBall();

            // Destruir la pelota actual
            Destroy(collision.gameObject);

            // Resta un punto
            ScriptGameManager.instance.RestarPuntos();

            // 🔥 Incrementar velocidad del arquero
            //AumentarVelocidad();
        }
    }

    // Método público para ser llamado desde otros scripts
    public void AumentarVelocidad()
    {
        velocidad += incrementoVelocidad;
        Debug.Log("Velocidad del arquero aumentada: " + velocidad);
    }
}