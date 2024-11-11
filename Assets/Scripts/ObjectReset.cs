using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class ObjectReset : MonoBehaviour
{
    private Vector3 initialPosition;  // Almacena la posici�n original del objeto
    private Quaternion initialRotation;  // Almacena la rotaci�n original del objeto
    private XRGrabInteractable grabInteractable;  // Para detectar cu�ndo el objeto es agarrado o soltado

    void Start()
    {
        // Guardar la posici�n y rotaci�n iniciales cuando el objeto aparece en la escena
        initialPosition = transform.position;
        initialRotation = transform.rotation;

        // Obtener el componente XRGrabInteractable para las interacciones
        grabInteractable = GetComponent<XRGrabInteractable>();

        // Suscribirse a los eventos cuando el objeto es soltado
        grabInteractable.selectExited.AddListener(OnDropObject);
    }

    // Cuando el objeto es soltado
    private void OnDropObject(SelectExitEventArgs args)
    {
        // Aqu� no hacemos nada por ahora, la l�gica de resetear estar� en el contenedor.
        // Simplemente se usa este evento para detectar el soltado.
    }

    // Llamar a esta funci�n para devolver el objeto a su posici�n original
    public void ResetPosition()
    {
        transform.position = initialPosition;  // Volver a la posici�n original
        transform.rotation = initialRotation;  // Volver a la rotaci�n original
    }
}