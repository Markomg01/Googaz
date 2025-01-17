using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.XR.Interaction.Toolkit.Filtering;
using static Unity.VisualScripting.Member;

public class ChangeScene : MonoBehaviour
{
    public Animator puertaKotxea;

    public string escena;
    public AudioSource SonidoCambioescena;
    public FadeInOut FadeOut;

    private void Start()
    {
        SonidoCambioescena = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.gameObject.name);
        if (other.transform.name == "Poke Point")
        {
            puertaKotxea.SetTrigger("puertaKotxea");
            Debug.Log("MANILLARRARARA");
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision.gameObject.name);
    }

    public void InvocarEscena()
    {
        SonidoCambioescena.Play();
        Debug.Log("sonido0");
        Invoke("CambiarEscena", 1f);
        FadeOut.FadeOut();
    }

    public void CambiarEscena()
    {
        SceneManager.LoadScene(escena);
        Debug.Log("PuertaNoAbierta");
    }    
    
}
