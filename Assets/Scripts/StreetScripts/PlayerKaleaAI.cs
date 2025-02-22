using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerKaleaAI : MonoBehaviour
{
    public float distanciaRaycast = 100f;
    public LayerMask kaleaAI;
    private kaleaAI iaUltimaGolpeada;

    public Renderer kaleaAIrenderer;

    void Update()
    {
        LanzarRaycast();
    }

    void LanzarRaycast()
    {
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, distanciaRaycast, kaleaAI))
        {

            kaleaAI ia = hit.collider.GetComponent<kaleaAI>();
            iaUltimaGolpeada = ia;
            iaUltimaGolpeada.setRaycastGolpeo(true);
            if (ia != null)
            {
                ia.DetenerIA(true);
                iaUltimaGolpeada = ia;
            }
        }
        else
        {
            if (iaUltimaGolpeada != null)
            {
                iaUltimaGolpeada.setRaycastGolpeo(false);
            }
        }


        if (!kaleaAIrenderer.isVisible)
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
