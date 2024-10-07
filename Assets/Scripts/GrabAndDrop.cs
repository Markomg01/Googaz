using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabAndDrop : MonoBehaviour
{
    public Animator laPuerta;

    private void OnTriggerEnter(Collider other)
    {
        laPuerta.SetTrigger("DoorOpen");
    }
}
