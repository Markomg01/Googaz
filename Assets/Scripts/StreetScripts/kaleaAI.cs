using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class kaleaAI : MonoBehaviour
{
    public float velocidad = 1f;

    public Vector3 direccion = Vector3.forward;

    private bool raycastGolpeo = false;
    public string escena;
    public FadeInOut FadeOut;


    void Update()
    {
        if (!raycastGolpeo)
        {
            MoverIA();            
        }
    }

    void MoverIA()
    {
        transform.Translate(direccion.normalized * velocidad * Time.deltaTime);
    }

    public void DetenerIA(bool detener)
    {
        raycastGolpeo = detener;

        if (detener)
        {
            Debug.Log("IA Detenida");
        }
        else
        {
            MoverIA();
            Debug.Log("IA Reanudando movimiento");
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision.gameObject);
        if (collision.gameObject.CompareTag("Player"))
        {
            Invoke("CambiarEscena", 1f);
            FadeOut.FadeOut();
        }
    }

    public void CambiarEscena()
    {
        SceneManager.LoadScene(escena);
    }

    /*private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Trigger activado por el jugador. Reiniciando escena...");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }*/

}
