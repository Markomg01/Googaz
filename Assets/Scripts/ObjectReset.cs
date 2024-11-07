using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class ObjectReset : MonoBehaviour
{
    private Vector3 initialPosition;  // Almacena la posición original del objeto
    private Quaternion initialRotation;  // Almacena la rotación original del objeto
    private XRGrabInteractable grabInteractable;  // Para detectar cuándo el objeto es agarrado o soltado

    void Start()
    {
        // Guardar la posición y rotación iniciales cuando el objeto aparece en la escena
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
        // Aquí no hacemos nada por ahora, la lógica de resetear estará en el contenedor.
        // Simplemente se usa este evento para detectar el soltado.
    }

    // Llamar a esta función para devolver el objeto a su posición original
    public void ResetPosition()
    {
        transform.position = initialPosition;  // Volver a la posición original
        transform.rotation = initialRotation;  // Volver a la rotación original
    }
}