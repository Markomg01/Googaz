using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerKaleaAI : MonoBehaviour
{
    public float distanciaRaycast = 10f;

    void Update()
    {
        LanzarRaycast();
    }

    void LanzarRaycast()
    {
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, distanciaRaycast))
        {
            kaleaAI ia = hit.collider.GetComponent<kaleaAI>();

            if (ia != null)
            {
                ia.DetenerIA(true);
                Debug.Log("Raycast impactó a la IA: " + hit.collider.name);
            }
        }
        else
        {
            kaleaAI[] ias = FindObjectsOfType<kaleaAI>();
            foreach (kaleaAI ia in ias)
            {
                ia.DetenerIA(false);
            }
        }        
        Debug.DrawRay(transform.position, transform.forward * distanciaRaycast, Color.red);
    }
}
