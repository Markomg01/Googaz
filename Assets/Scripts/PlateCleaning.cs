using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class PlateCleaning : MonoBehaviour
{
    [SerializeField]
    private CleanPoint[] points;

    int numero = 0;
    public int pointsCleaned = 0;
    public int pointToBeCleaned = 0;
    public bool isCleaned;

    private void Update()
    {
        if (pointsCleaned >= pointToBeCleaned)
        {
            gameObject.tag = "Clean";
            isCleaned = true;
            points[numero].DeactivatePoint();
        }
        /*
        if (!isCleaned)
        {
            if (GetComponent<Rigidbody>().isKinematic)
            {
                points[numero].ActivatePoint();
            }
            else
            {
                points[numero].DeactivatePoint();
            }
        }
        */

    }

    public void NextPoint()
    {
        pointsCleaned++;
        points[numero].DeactivatePoint();
        if (numero == 3)
        {
            numero = 0;
        }
        else
        {
            numero++;
        }
        points[numero].ActivatePoint();
    }

    public void Activate()
    {
        if (!gameObject.GetComponent<XRGrabInteractable>().GetOldestInteractorSelecting().transform.gameObject.CompareTag("Socket"))
        {
            points[numero].ActivatePoint();
        }
    }

    public void Deactivate()
    {
        points[numero].DeactivatePoint();
    }
}
