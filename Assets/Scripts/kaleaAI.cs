using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kaleaAI : MonoBehaviour
{
    public float velocidad = 1f;

    public Vector3 direccion = Vector3.forward;

    private bool raycastGolpeo = false;
    private bool estabaDetenida = false;

    void Update()
    {
        if (!raycastGolpeo)
        {
            MoverIA();            
        }
    }

    void MoverIA()
    {
        transform.Translate(direccion * velocidad * Time.deltaTime);
    }

    public void DetenerIA(bool detener)
    {
        if (detener != raycastGolpeo)
        {
            raycastGolpeo = detener;

            if (detener)
            {
                Debug.Log("IA Detenida");
                estabaDetenida = true;
            }
            else if (estabaDetenida)
            {
                Debug.Log("IA Reanudando movimiento");
                estabaDetenida = false;
            }
        }
    }

}
