using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CleanPoint : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Sponge"))
        {
            gameObject.GetComponentInParent<PlateCleaning>().NextPoint();
            DeactivatePoint();
        }
    }

    public void ActivatePoint()
    {
        transform.DOScale(0.03f, 1f);
    }

    public void DeactivatePoint()
    {
        transform.DOScale(0f, 1f);
    }
}
