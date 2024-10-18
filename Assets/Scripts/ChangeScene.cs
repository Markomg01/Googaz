using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.XR.Interaction.Toolkit.Filtering;

public class ChangeScene : MonoBehaviour
{
    public Animator puertaKotxea;

    public string escena;

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

    public void CambiarEscena()
    {
        SceneManager.LoadScene(escena);
    }
    
}
