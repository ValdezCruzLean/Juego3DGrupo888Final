using UnityEngine;

public class PauseByTarget : MonoBehaviour
{
    public GameObject target;  // Objeto que controlará la pausa

    void Update()
    {
        if (target != null)
        {
            Time.timeScale = target.activeSelf ? 0f : 1f;
        }
    }
}
