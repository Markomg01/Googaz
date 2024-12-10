using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class kaleaAI : MonoBehaviour
{
    public float velocidad = 1f;

    public Vector3 direccion = Vector3.forward;

    private bool raycastGolpeo = false;
    private bool enRetroceso = false;
    public string escena;
    public FadeInOut FadeOut;

    public Animator animator;


    void Update()
    {
        if (!raycastGolpeo && !enRetroceso)
        {
            MoverIA();            
        }
    }

    void MoverIA()
    {
        transform.Translate(direccion.normalized * velocidad * Time.deltaTime);
    }

    void MoverHaciaAtras()
    {
        enRetroceso = true;
        transform.Translate(-direccion.normalized * velocidad * Time.deltaTime);
        animator.SetBool("IsMoving", true);
    }

    public void DetenerIA(bool detener)
    {
        if (enRetroceso) return;

        raycastGolpeo = detener;

        if (detener)
        {            
            animator.SetBool("IsMoving", false);
            animator.SetBool("IsMovil", true);
            animator.SetBool("IsAtras", false);
            Debug.Log("IA Detenida");
        }
        else
        {
            animator.SetBool("IsMovil", false);
            animator.SetBool("IsAtras", false);
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

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            enRetroceso = true;
            Debug.Log("AtrasAtrasAtras");
            MoverHaciaAtras();
            animator.SetBool("IsAtras", true);
            animator.SetBool("IsMovil", false);
            animator.SetBool("IsMoving", false);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            enRetroceso = true;
            Debug.Log("AtrasAtrasAtrasCoñoQue te vayas a tomar por culo");
            MoverHaciaAtras();
            velocidad = 0.5f;
            animator.SetBool("IsAtras", true);
            animator.SetBool("IsMovil", false);
            animator.SetBool("IsMoving", false);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            enRetroceso = false;
            MoverIA();
        }
    }

    /*public void CambiarEscena()
    {
        SceneManager.LoadScene(escena);
    }*/
}
