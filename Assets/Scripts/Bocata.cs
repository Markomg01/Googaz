using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class Bocata : MonoBehaviour
{
    public GameObject breadtop;
    public GameObject breadbottom;
    public GameObject cheese;
    public GameObject tomato;
    public GameObject letuce;
    public GameObject bocatafinal;
    public AudioSource po;
    public GameObject end;
    public Task task;

    private void Awake()
    {
        breadtop.SetActive(false); cheese.SetActive(false); letuce.SetActive(false); tomato.SetActive(false);
    }
    public void BreadBot()
    {
        breadbottom.GetComponent<MeshRenderer>().enabled = false; letuce.SetActive(true);
        breadbottom.GetComponent<XRSocketInteractor>().GetOldestInteractableSelected().transform.gameObject.GetComponent<Collider>().enabled = false;
        po.Play();
    }
    public void Letuce()
    {
        letuce.GetComponent<MeshRenderer>().enabled = false; tomato.SetActive(true);
        letuce.GetComponent<XRSocketInteractor>().GetOldestInteractableSelected().transform.gameObject.GetComponent<Collider>().enabled = false; po.Play();
    }
    public void Tomato()
    {
        tomato.GetComponent<MeshRenderer>().enabled = false; cheese.SetActive(true);
        tomato.GetComponent<XRSocketInteractor>().GetOldestInteractableSelected().transform.gameObject.GetComponent<Collider>().enabled = false; po.Play();
    }
    public void Cheese()
    {
        cheese.GetComponent<MeshRenderer>().enabled = false; breadtop.SetActive(true);
        cheese.GetComponent<XRSocketInteractor>().GetOldestInteractableSelected().transform.gameObject.GetComponent<Collider>().enabled = false; po.Play();
    }
    public void BreadTop()
    {
        breadtop.GetComponent<MeshRenderer>().enabled = false;
        breadtop.GetComponent<XRSocketInteractor>().GetOldestInteractableSelected().transform.gameObject.GetComponent<Collider>().enabled = true; po.Play();
        Instantiate(bocatafinal, gameObject.transform.position, bocatafinal.transform.rotation);
        GameObject g = GameObject.Instantiate(end);
        Destroy(gameObject, 0.08f);
        task.TaskComplete(end);
    }

}
