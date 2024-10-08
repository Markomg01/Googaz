using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.XR.Interaction.Toolkit.Filtering;

public class ChangeScene : MonoBehaviour
{
    public Animator puertaKotxea;

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.name == "Poke Point")
        {
            puertaKotxea.SetTrigger("puertaKotxea");
        }
    } 
    
    public void cambiarEscena()
    {
        SceneManager.LoadScene("Etxea(Egunez)");
    }
    
}
