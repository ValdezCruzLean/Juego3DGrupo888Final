using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Footballball : MonoBehaviour
{
    //Añade una variable fuerza a la pelota
    public float Force;
    private void Update()
    {
        //Hace que al apretar el espacio la pelota se dirija hacia el arco
        if (Input.GetKey(KeyCode.Space))
        {
            GetComponent<Rigidbody>().AddForce(Vector3.forward * Force, ForceMode.Impulse);
        }
    }
}
