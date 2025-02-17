using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using TMPro;
using UnityEngine.UI;

public class TirarBasura : MonoBehaviour
{
    public string ropaTag = "Ropa";  // Tag de los objetos correctos
    public Transform otraPosicion;  // Posici�n para devolver objetos incorrectos
    public ParticleSystem particulas2;  // Sistema de part�culas (nuevo)
    public AudioClip sonidoDeposito;  // Sonido al depositar correctamente
    public AudioSource audioSource;  // Para reproducir el sonido
    public TMP_Text mensajeError;  // Mensaje de error
    public float duracionMensaje = 2f;  // Duraci�n del mensaje
    public float tiempoDesaparecer = 0f;  // Tiempo antes de eliminar el objeto correcto
    //public Outline outline;  // Componente Outline
    //public Toggle UIToggle ;  // Referencia al Canvas que quieres desactivar
    public Task task;
    int zenbatArropaJasota = 0;
    public int MAXarropa = 3;
    public Animator animator;
    public AudioSource audioStart;

    private void Start()
    {
        /* Asegurarse de que el outline est� desactivado al principio
        if (outline != null)
        {
            outline.enabled = false;
        }

        audioSource = gameObject.AddComponent<AudioSource>();

        //audioSource.loop = true;*/
    }

    private void OnTriggerEnter(Collider other)
    {
        XRGrabInteractable interactable = other.GetComponent<XRGrabInteractable>();

        if (interactable != null)
        {
            if (other.CompareTag(ropaTag))
            {
                zenbatArropaJasota++ ; 
                if ( zenbatArropaJasota == MAXarropa)
                {
                    // Si es un objeto correcto
                    if (particulas2 != null)
                    {
                        particulas2.Play();  // Activar part�culas
                        animator.SetTrigger("Activar");
                    }

                    if (sonidoDeposito != null)
                    {
                        audioSource.clip = sonidoDeposito;  // Reproducir sonido
                        audioSource.Play();
                    }

                    // Desactivar la interacci�n para que no pueda volver a agarrarse
                    interactable.enabled = false;

                    // Hacer que el objeto sea hijo del contenedor
                    other.transform.SetParent(this.transform);

                    // Desactivar las part�culas y eliminar el objeto m�s r�pido
                    Invoke("DetenerParticulas", tiempoDesaparecer);
                   // Invoke("EliminarObjetoCorrecto", tiempoDesaparecer);



                    //UIToggle.isOn = true;

                    task.TaskComplete(task);
                }
                else
                {
                    if (sonidoDeposito != null)
                    {
                        audioSource.clip = sonidoDeposito;  // Reproducir sonido
                        audioSource.Play();
                    }

                    // Desactivar la interacci�n para que no pueda volver a agarrarse
                    interactable.enabled = false;

                    // Hacer que el objeto sea hijo del contenedor
                    other.transform.SetParent(this.transform);

                    // Desactivar las part�culas y eliminar el objeto m�s r�pido
                    Invoke("DetenerParticulas", tiempoDesaparecer);
                  Invoke("EliminarObjetoCorrecto", tiempoDesaparecer);
                }
                Destroy(other.gameObject);

            }
            else
            {
                // Si el objeto es incorrecto, devolverlo a su posici�n original
                MostrarMensajeError("Dep�sitelo en su lugar correspondiente.");

                // Detener el movimiento del objeto
                Rigidbody objetoRB = other.attachedRigidbody;
                if (objetoRB != null)
                {
                    objetoRB.velocity = Vector3.zero;
                    objetoRB.angularVelocity = Vector3.zero;
                }

                // Devolver el objeto a su posici�n original
                if (otraPosicion != null)
                {
                    other.transform.position = otraPosicion.position;
                    other.transform.rotation = otraPosicion.rotation;
                }

            }

        }
    }

    // Mostrar mensaje de error en la UI
    private void MostrarMensajeError(string mensaje)
    {
        if (mensajeError != null)
        {
            mensajeError.text = mensaje;  // Establecer mensaje
            mensajeError.gameObject.SetActive(true);  // Mostrar mensaje
            CancelInvoke("OcultarMensajeError");
            Invoke("OcultarMensajeError", duracionMensaje);  // Ocultar despu�s de unos segundos
        }
    }

    // Ocultar el mensaje de error
    private void OcultarMensajeError()
    {
        if (mensajeError != null)
        {
            mensajeError.gameObject.SetActive(false);  // Ocultar mensaje
        }
    }

    // Detener part�culas despu�s de depositar correctamente
    private void DetenerParticulas()
    {
        if (particulas2 != null)
        {
            particulas2.Stop();  // Detener part�culas r�pidamente
        }
    }

    // Eliminar el objeto correcto despu�s de depositarlo
    private void EliminarObjetoCorrecto()
    {
        if (transform.childCount > 0)
        {
            Transform objetoDepositado = transform.GetChild(transform.childCount - 1);
            if (objetoDepositado != null)
            {
                Destroy(objetoDepositado.gameObject);  // Eliminar el objeto de la escena
                audioStart.Play();

            }
        }
    }

    // Activar el outline cuando se agarra el objeto correcto
    public void ActivarOutline(Outline outline)
    {
        if (outline != null)
        {
            outline.enabled = true;
        }
    }

    // Desactivar el outline cuando se suelta el objeto correcto
    public void DesactivarOutline(Outline outline)
    {
        if (outline != null)
        {
            outline.enabled = false;
        }
    }
}
