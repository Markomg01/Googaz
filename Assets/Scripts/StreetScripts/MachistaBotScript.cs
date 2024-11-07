using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MachistaBotScript : MonoBehaviour
{
    public float distanciaRaycastRobot = 100f;

    public Canvas canvasRobot;
    public LayerMask MachistaBot;
    public Renderer RobotRenderer;

    void Update()
    {       
        LanzarRaycast();
    }

    void LanzarRaycast()
    {
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, distanciaRaycastRobot, MachistaBot))
        {
            Debug.Log("Raycast impactó el objeto: " + hit.collider.name);

            canvasRobot.gameObject.SetActive(true);
        }

        /*else
        {
            canvasRobot.gameObject.SetActive(false);
        }*/

        if (!RobotRenderer.isVisible)
        {
            canvasRobot.gameObject.SetActive(false);
        }

        Debug.DrawRay(transform.position, transform.forward * distanciaRaycastRobot, Color.green);
    }
}
