using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCwalk : MonoBehaviour
{
    public float velocidad = 1f;

    public Vector3 direccion = Vector3.forward;
    public Animator animator;

    private void Update()
    {
        MoverIA();
    }

    void MoverIA()
    {
        transform.Translate(direccion.normalized * velocidad * Time.deltaTime);
    }
}
