using UnityEngine;

public class GeneratorBall : MonoBehaviour
{
    [SerializeField]
    //Indica el GameObject de la pelota
    private GameObject ballPrefab;
    //Indica la pelota actual
    private GameObject currentBall;

    void Start()
    {
        GenerateBall();
    }
    public void GenerateBall()
    {
        // Si es que hay una pelota generada, la destruye
        if (currentBall != null)
        {
            Destroy(currentBall);
        }

        // Instancia una nueva pelota en donde se ubica el generador
        currentBall = Instantiate(ballPrefab, transform.position, transform.rotation);
    }
}