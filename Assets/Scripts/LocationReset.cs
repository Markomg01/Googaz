using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocationReset : MonoBehaviour
{
    public Transform resetLocationTransform;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Reset"))
        {
            ResetLocation();
        }
    }

    private void ResetLocation()
    {
            gameObject.transform.position = resetLocationTransform.position;
    }
}
