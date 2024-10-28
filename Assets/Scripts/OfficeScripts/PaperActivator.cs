using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class PaperActivator : MonoBehaviour
{
    private void ActivatePaper()
    {
        GetComponent<Rigidbody>().isKinematic = false;
        GetComponent<XRGrabInteractable>().enabled = true;
        GetComponent<Collider>().enabled = true;
    }
}
