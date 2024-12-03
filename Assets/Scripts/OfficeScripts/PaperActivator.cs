using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class PaperActivator : MonoBehaviour
{
    FaxMachine faxMachine;

    private void Awake()
    {
        faxMachine = GameObject.Find("FaxPushButton").GetComponent<FaxMachine>();
    }

    private void ActivatePaper()
    {
        GetComponent<Rigidbody>().isKinematic = false;
        GetComponent<XRGrabInteractable>().enabled = true;
        GetComponent<Collider>().enabled = true;
    }

    private void DeactivatePaper()
    {
        GetComponent<Rigidbody>().isKinematic = true;
        GetComponent<XRGrabInteractable>().enabled = false;
        GetComponent<Collider>().enabled = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Reset"))
        {
            faxMachine.canSpawn = true;
            faxMachine.SpawnPaper();
            faxMachine.pileArrow.SetActive(false);
            Destroy(gameObject);    
        }
    }
}
