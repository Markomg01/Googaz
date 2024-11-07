using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kaleaAI : MonoBehaviour
{
    public float velocidad = 1f;

    public Vector3 direccion = Vector3.forward;

    private bool raycastGolpeo = false;

    void Update()
    {
        if (!raycastGolpeo)
        {
            MoverIA();            
        }
    }

    void MoverIA()
    {
        transform.Translate(direccion.normalized * velocidad * Time.deltaTime);
    }

    public void DetenerIA(bool detener)
    {
        raycastGolpeo = detener;

        if (detener)
        {
            Debug.Log("IA Detenida");
        }
        else
        {
            MoverIA();
            Debug.Log("IA Reanudando movimiento");
        }
    }

}
