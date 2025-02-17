using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class kaleaAI : MonoBehaviour
{
    private float velocidad = 1f;

    public Vector3 direccion = Vector3.forward;

    private bool raycastGolpeo = false;
    private bool enRetroceso = false;
    public string escena;
    public FadeInOut FadeOut;

    public Animator animator;

    public AudioSource pisadasMalo;
    public GameObject prota;

    public void setRaycastGolpeo(bool bvalor)
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

                //Lo estoy mirando
        if (raycastGolpeo)
        {
            if (distance <= 6f)
            {
                //MoverseAtras
                                enRetroceso = true;
                MoverHaciaAtras();
                animator.SetBool("IsAtras", true);
                animator.SetBool("IsMovil", false);
                animator.SetBool("IsMoving", false);
                pisadasMalo.Play();
            }

            if (distance > 6f)
            {
                enRetroceso = false;
                                DetenerIA(true);
            }
        }
        else
        {
            if(distance > 2.5f)
            {
                //MoverseHaciaMi
                                enRetroceso = false;
                MoverIA();
                velocidad = 1f;
                animator.SetBool("IsAtras", false);
                animator.SetBool("IsMovil", false);
                animator.SetBool("IsMoving", true);
            }
            if(distance <= 2.5f)
            {
                                DetenerIA(true);
                enRetroceso = false;
            }
        }

        /*if (enRetroceso)
        {            
                        enRetroceso = true;
                      MoverHaciaAtras();
            animator.SetBool("IsAtras", true);
            animator.SetBool("IsMovil", false);
            animator.SetBool("IsMoving", false);
            pisadasMalo.Play();
        }
        else
        {
            if (distance <= 2.5f) //En Rango
            {
                if (raycastGolpeo == true)
                {
                                        enRetroceso = true;
                    MoverHaciaAtras();
                    animator.SetBool("IsAtras", true);
                    animator.SetBool("IsMovil", false);
                    animator.SetBool("IsMoving", false);
                    pisadasMalo.Play();
                }
                else
                {
                                        DetenerIA(true);
                    enRetroceso = false;
                }
            }
            else  //Fuera de Rango
            {
                if (raycastGolpeo)
                {
                    enRetroceso = false;
                                        DetenerIA(true);
                }
                else
                {
                                        enRetroceso = false;
                    MoverIA();
                    velocidad = 1.1f;
                }
            }
        }*/

        /*if (distance <= 2.5f)
        {
            if (raycastGolpeo == true)
            {
                                enRetroceso = true;
                              MoverHaciaAtras();
                animator.SetBool("IsAtras", true);
                animator.SetBool("IsMovil", false);
                animator.SetBool("IsMoving", false);
                pisadasMalo.Play();
            }
            else
            {
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

                                        enRetroceso = false;
                    MoverIA();
                    velocidad = 1.1f;
                }
                else
                {
                                        DetenerIA(true);
                    enRetroceso = false;
                }
            }
            else
            {
                if (raycastGolpeo == true)
                {
                                        enRetroceso = true;
                                      MoverHaciaAtras();
                    animator.SetBool("IsAtras", true);
                    animator.SetBool("IsMovil", false);
                    animator.SetBool("IsMoving", false);
                    pisadasMalo.Play();
                }
                else
                {
                                        enRetroceso = false;
                    MoverIA();
                    velocidad = 1.1f;
                }
            }
        }*/

    }

    void MoverIA()
    {
        velocidad = 1f;
        enRetroceso = false;
        transform.Translate(direccion.normalized * velocidad * Time.deltaTime);
    }

    void MoverHaciaAtras()
    {
        velocidad = 2f;
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
            animator.SetBool("IsMoving", false);
            animator.SetBool("IsMovil", true);
            animator.SetBool("IsAtras", false);
            pisadasMalo.Stop();
        }
        else
        {
            animator.SetBool("IsMovil", false);
            animator.SetBool("IsAtras", false);
            animator.SetBool("IsMoving", true);
            MoverIA();
            pisadasMalo.Play();
        }
    }

    /*private void OnCollisionEnter(Collision collision)
    {
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

    /*private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            enRetroceso = true;
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
    }*/

    /*public void CambiarEscena()
    {
        SceneManager.LoadScene(escena);
    }*/
}
