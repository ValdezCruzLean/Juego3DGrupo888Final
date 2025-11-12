using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LabyrinthRaycast : MonoBehaviour
{
    private float range = 10f;
    private bool levelEnded = false; //  evita llamadas múltiples

    void Update()
    {
        if (levelEnded) return; //  si ya terminó, no sigue detectando

        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, range))
        {
            if (hit.collider != null)
            {
                levelEnded = true; //  marca que ya terminó
                FindObjectOfType<Pantallafinaljuego>().ShowEndGame(true);
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawRay(transform.position, transform.forward * range);
    }
}