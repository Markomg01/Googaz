using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MachistaBotScript : MonoBehaviour
{
    public float distanciaRaycastRobot = 100f;
    public Camera camera;
    public Canvas canvasFaces;
    public Canvas canvasScreen;
    public Collider screenCollider;
    public LayerMask MachistaBot;
    

    void Update()
    {       
        LanzarRaycast();
    }

    void LanzarRaycast()
    {
        Ray ray = new Ray(camera.transform.position, camera.transform.forward);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, distanciaRaycastRobot, MachistaBot))
        {
            Debug.Log("Raycast impactó el objeto: " + hit.collider.name);

            canvasScreen.gameObject.SetActive(true);
            screenCollider.gameObject.SetActive(true);
        }
        else
        {
            canvasScreen.gameObject.SetActive(false);
            screenCollider.gameObject.SetActive(false);
        }

        Debug.DrawRay(transform.position, transform.forward * distanciaRaycastRobot, Color.green);
    }
}
