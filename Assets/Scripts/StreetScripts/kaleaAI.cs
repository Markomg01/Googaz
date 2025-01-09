using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
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

    public AudioSource pisadasMalo;
    public GameObject prota;

    public void setRaycastGolpeo (bool bvalor)
    {
        /*if (bvalor == false)
        {
            enRetroceso = false;
        }*/
        raycastGolpeo = bvalor;
    }
    void Update()
    {
        float distance = Vector3.Distance(transform.position, prota.transform.position);
        //Debug.Log(raycastGolpeo+" "+ distance);


        if (enRetroceso)
        {
            Debug.Log("en Retroceso chaval");
            enRetroceso = true;
            MoverHaciaAtras();
            animator.SetBool("IsAtras", true);
            animator.SetBool("IsMovil", false);
            animator.SetBool("IsMoving", false);
            pisadasMalo.Play();
        }
        else
        {
            if (distance < 2f) //En Rango
            {
                if (raycastGolpeo == true)
                {
                    Debug.Log("en rango y mirando");
                    enRetroceso = true;
                    MoverHaciaAtras();
                    animator.SetBool("IsAtras", true);
                    animator.SetBool("IsMovil", false);
                    animator.SetBool("IsMoving", false);
                    pisadasMalo.Play();
                }
                else
                {
                    Debug.Log("en rango y no mirando");
                    DetenerIA(true);
                    enRetroceso = false;
                }
            }
            else  //Fuera de Rango
            {
                if (raycastGolpeo)
                {
                    Debug.Log("fuera de range y mirando");
                    DetenerIA(true);
                    enRetroceso = false;

                }
                else
                {
                    Debug.Log("fuera de rango y no mirando");
                    enRetroceso = false;
                    MoverIA();
                    velocidad = 1.1f;
                }
            }
        }

        /*if(distance <= 2.5f)
        {
            if(raycastGolpeo == true)
            {
                Debug.Log("en rango y mirando");
                enRetroceso = true;
                //Debug.Log("AtrasAtrasAtras");
                MoverHaciaAtras();
                animator.SetBool("IsAtras", true);
                animator.SetBool("IsMovil", false);
                animator.SetBool("IsMoving", false);
                pisadasMalo.Play();
            }
            else
            {
                Debug.Log("en rango y no mirando");
                DetenerIA(true);
                enRetroceso = false;
            }
        }
        else 
        {
            if (!enRetroceso)
            {
                if (!raycastGolpeo)// !enRetroceso)
                {

                    Debug.Log("fuera de rango y no mirando");
                    enRetroceso = false;
                    MoverIA();
                    velocidad = 1.1f;
                }
                else
                {
                    Debug.Log("fuera de range y mirando");
                    DetenerIA(true);
                    enRetroceso = false;
                }
            }
            else
            {
                if(raycastGolpeo == true)
                {
                    Debug.Log("fuera de rango y mirando222");
                    enRetroceso = true;
                    //Debug.Log("AtrasAtrasAtras");
                    MoverHaciaAtras();
                    animator.SetBool("IsAtras", true);
                    animator.SetBool("IsMovil", false);
                    animator.SetBool("IsMoving", false);
                    pisadasMalo.Play();
                }
                else
                {
                    Debug.Log("fuera de rango y no mirando2222");
                    enRetroceso = false;
                    MoverIA();
                    velocidad = 1.1f;
                }
            }
        }*/

    }

    void MoverIA()
    {
        transform.Translate(direccion.normalized * velocidad * Time.deltaTime);
        enRetroceso = false;
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

        //raycastGolpeo = detener;

        if (detener)
        {
            enRetroceso = false;
            animator.SetBool("IsMoving", false);
            animator.SetBool("IsMovil", true);
            animator.SetBool("IsAtras", false);
            pisadasMalo.Stop();
            //Debug.Log("IA Detenida");
        }
        else
        {
            enRetroceso = false;
            animator.SetBool("IsMovil", false);
            animator.SetBool("IsAtras", false);
            animator.SetBool("IsMoving", true);
            MoverIA();
            pisadasMalo.Play();
            //Debug.Log("IA Reanudando movimiento");
        }
    }

    /*private void OnCollisionEnter(Collision collision)
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
    }*/

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            enRetroceso = true;
            //Debug.Log("AtrasAtrasAtras");
            MoverHaciaAtras();
            animator.SetBool("IsAtras", true);
            animator.SetBool("IsMovil", false);
            animator.SetBool("IsMoving", false);
            pisadasMalo.Play();
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            enRetroceso = true;
            Debug.Log("AtrasAtrasAtrasCoñoQue te vayas a tomar por culo");
            MoverHaciaAtras();
            velocidad = 0.75f;
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
            velocidad = 1.1f;
        }
    }

    /*public void CambiarEscena()
    {
        SceneManager.LoadScene(escena);
    }*/
}
