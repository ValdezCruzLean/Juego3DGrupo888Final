using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class CameraInteraction : MonoBehaviour
{
    private new Transform camera;
    [SerializeField]private float rayDistance;
     private bool clickRegistered = false;
    // Start is called before the first frame update
    void Start()
    {
        camera = transform.Find("Main Camera");
    }

    // Update is called once per frame
    void Update()
    {
        Debug.DrawRay(camera.position, camera.forward * rayDistance, Color.red);

        RaycastHit hit;
        if(Physics.Raycast(camera.position, camera.forward, out hit, rayDistance)){
            int layer = hit.collider.gameObject.layer;
            //Debug.Log(hit.transform.name);
            // if (Input.GetMouseButtonDown(0) && !clickRegistered)
            // {
            //     clickRegistered = true;
            //     SceneManager.LoadScene("Pachinko");
            // }
            if (layer == LayerMask.NameToLayer("Pachinko") && Input.GetMouseButtonDown(0) && !clickRegistered)
            {
                clickRegistered = true;
                SceneManager.LoadScene("Pachinko");
            }
            else if (layer == LayerMask.NameToLayer("Laberinto") && Input.GetMouseButtonDown(0) && !clickRegistered)
            {
                clickRegistered = true;
                SceneManager.LoadScene("Laberinto");
            }
            else if (layer == LayerMask.NameToLayer("Futbol") && Input.GetMouseButtonDown(0) && !clickRegistered)
            {
                clickRegistered = true;
                SceneManager.LoadScene("Futbol");
            }
        }
        else
        {
            clickRegistered = false;
        }
    }
}
