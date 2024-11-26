using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderBlack : MonoBehaviour
{
    public FadeInOut FadeOut;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("ColliderNegro"))
        {
            FadeOut.FadeOut();
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("ColliderNegro"))
        {
            FadeOut.FadeIn();
        }
    }
}
