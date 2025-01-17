using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using TMPro;
using Unity.VisualScripting;

public class StoreBokata : MonoBehaviour
{
    public string bokataTag = "Bokata";  // Tag de los objetos correctos
    public Transform otraPosicion;  // Posici�n para devolver objetos incorrectos
    public ParticleSystem particulas;  // Sistema de part�culas
    public AudioClip sonidoDeposito;  // Sonido al depositar correctamente
    public AudioSource audioSource;  // Para reproducir el sonido
    public TMP_Text mensajeError;  // Mensaje de error
    public float duracionMensaje = 2f;  // Duraci�n del mensaje
    public float tiempoDesaparecer = 0.2f;  // Tiempo antes de eliminar el objeto correcto
    public Outline outline;  // Componente Outline
    public Task task;
    public GameObject ArrowBokataFinal;
    public GameObject ArrowStoreBokata;
    public GameObject Preparar_MesaProps;
    public GameObject PlatoSocket;
    public GameObject ArrowSetTable1;

    private void Start()
    {
        // Asegurarse de que el outline est� desactivado al principio
        if (outline != null)
        {
            outline.enabled = false;
        }

        audioSource = gameObject.AddComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        XRGrabInteractable interactable = other.GetComponent<XRGrabInteractable>();

        if (interactable != null)
        {
            if (other.CompareTag(bokataTag))
            {
                // Si es un objeto correcto
                if (particulas != null)
                {
                    particulas.Play();  // Activar part�culas
                    task.TaskComplete(task);
                }

                if (sonidoDeposito != null)
                {
                    audioSource.PlayOneShot(sonidoDeposito);  // Reproducir sonido
                }

                // Desactivar la interacci�n para que no pueda volver a agarrarse
                interactable.enabled = false;

                // Hacer que el objeto sea hijo del contenedor
                other.transform.SetParent(this.transform);

                // Desactivar las part�culas y eliminar el objeto m�s r�pido
                Invoke("DetenerParticulas", 2.0f);
                Invoke("EliminarObjetoCorrecto", tiempoDesaparecer);
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
        if (particulas != null)
        {
            particulas.Stop();  // Detener part�culas r�pidamente
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
                Destroy(ArrowBokataFinal);
                Destroy(ArrowStoreBokata);
                Preparar_MesaProps.SetActive(true);
                PlatoSocket.SetActive(true);
                ArrowSetTable1.SetActive(true);
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
