using UnityEngine;

public class GoalMechanical : MonoBehaviour
{
    public GameObject Ball;
    private int valorSuma = 1;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            // Generar una nueva pelota
            GeneratorBall generator = FindObjectOfType<GeneratorBall>();
            if (generator != null)
                generator.GenerateBall();

            // Destruir la pelota
            Destroy(collision.gameObject);

            // Sumar puntos
            ScriptGameManager.instance.SumarPuntos(valorSuma);

            // 🔥 Aumentar velocidad del arquero si existe
            Goalkeeper arquero = FindObjectOfType<Goalkeeper>();
            if (arquero != null)
                arquero.AumentarVelocidad();
        }
    }
}
