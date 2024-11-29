using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class StorePlatos : MonoBehaviour
{
    public GameObject plato1;
    public GameObject plato2;
    public GameObject plato3;
    public GameObject plato4;
    public GameObject plato5;
    public GameObject platofinal;
    public AudioSource po;
    public GameObject end;
    public Task task;

    private void Awake()
    {
        plato1.SetActive(false); plato2.SetActive(false); plato3.SetActive(false); plato4.SetActive(false);
    }
    public void Plato1()
    {
        plato1.GetComponent<MeshRenderer>().enabled = false; plato2.SetActive(true);
        plato1.GetComponent<XRSocketInteractor>().GetOldestInteractableSelected().transform.gameObject.GetComponent<Collider>().enabled = false;
        po.Play();
    }
    public void Plato2()
    {
        plato2.GetComponent<MeshRenderer>().enabled = false; plato3.SetActive(true);
        plato2.GetComponent<XRSocketInteractor>().GetOldestInteractableSelected().transform.gameObject.GetComponent<Collider>().enabled = false; po.Play();
    }
    public void Plato3()
    {
        plato3.GetComponent<MeshRenderer>().enabled = false; plato4.SetActive(true);
        plato3.GetComponent<XRSocketInteractor>().GetOldestInteractableSelected().transform.gameObject.GetComponent<Collider>().enabled = false; po.Play();
    }
    public void Plato4()
    {
        plato4.GetComponent<MeshRenderer>().enabled = false; plato5.SetActive(true);
        plato4.GetComponent<XRSocketInteractor>().GetOldestInteractableSelected().transform.gameObject.GetComponent<Collider>().enabled = false; po.Play();
    }
    public void Plato5()
    {
        plato5.GetComponent<MeshRenderer>().enabled = false;
        plato5.GetComponent<XRSocketInteractor>().GetOldestInteractableSelected().transform.gameObject.GetComponent<Collider>().enabled = true; po.Play();
        Instantiate(platofinal, gameObject.transform.position, platofinal.transform.rotation);
        GameObject g = GameObject.Instantiate(end);
        Destroy(gameObject, 0.08f);
        task.TaskComplete(end);
    }

}
