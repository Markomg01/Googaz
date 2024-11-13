using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class SocketPlate : MonoBehaviour
{
    [SerializeField] GameObject PilaPlatosSnap;

    public void Snap()
    {
        GetComponent<XRSocketInteractor>().GetOldestInteractableSelected().transform.gameObject.GetComponent<Collider>().enabled = false;
        GetComponent<MeshRenderer>().enabled = false;
        PilaPlatosSnap.GetComponent<PilaPlatosSnap>().NextPlate();
    }

}
