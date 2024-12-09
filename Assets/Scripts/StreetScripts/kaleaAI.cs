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

    public Animator animator;


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
            animator.SetBool("IsMoving", false);
            animator.SetBool("IsMovil", true);
            Debug.Log("IA Detenida");
        }
        else
        {
            animator.SetBool("IsMovil", false);
            animator.SetBool("IsMoving", true);
            MoverIA();
            Debug.Log("IA Reanudando movimiento");
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision.gameObject);
        if (collision.gameObject.CompareTag("Player"))
        {
            DetenerIA(true);
            //Invoke("CambiarEscena", 1f);
            //FadeOut.FadeOut();
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            MoverIA();
        }
    }

    /*public void CambiarEscena()
    {
        SceneManager.LoadScene(escena);
    }*/
}
