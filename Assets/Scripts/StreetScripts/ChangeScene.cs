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
                if (other.transform.name == "Poke Point")
        {
            puertaKotxea.SetTrigger("puertaKotxea");
                    }
    }

    private void OnCollisionEnter(Collision collision)
    {
            }

    public void InvocarEscena()
    {
        SonidoCambioescena.Play();
                Invoke("CambiarEscena", 1f);
        FadeOut.FadeOut();
    }

    public void CambiarEscena()
    {
        SceneManager.LoadScene(escena);
            }    
    
}
