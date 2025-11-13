using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FixPause : MonoBehaviour
{
    void Start()
    {
        // Asegura que el tiempo vuelva a la normalidad cada vez que entras al lobby
        Time.timeScale = 1f;
    }
}
