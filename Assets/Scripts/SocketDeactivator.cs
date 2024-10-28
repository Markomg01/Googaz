using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class SocketDeactivator : MonoBehaviour
{
    public void DeactivateObject()
    {
        GetComponent<XRSocketInteractor>().GetOldestInteractableSelected().transform.gameObject.GetComponent<Collider>().enabled = false;
        GetComponent<MeshRenderer>().enabled = false;
    }
    public void DeactivateSocket()
    {
        gameObject.GetComponent<Collider>().enabled = false;
    }
}
