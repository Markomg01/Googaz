using System.Collections;
using System.Collections.Generic;
//using Unity.Burst.CompilerServices;
using UnityEngine;

public class DecalProjector : MonoBehaviour
{
    [SerializeField] GameObject bulletHolePrefab;
    [SerializeField] GameObject bulletHoleContainer;
    [SerializeField] float destroyDelay;

    public float rayDistance;
    public GameObject origin;

    Ray currentRay;
    RaycastHit currentHit;

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.transform.name);
        if (other.CompareTag("Paper"))
        {
            Ray ray = new Ray(origin.transform.position, origin.transform.forward);

            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, rayDistance))
            {
                Debug.Log(hit.transform.name);
                SpawnBulletHole(hit, ray);
                hit.transform.tag = "Signed";
            }

            currentRay = ray;
            currentHit = hit;
        }
    }


    void SpawnBulletHole(RaycastHit hit, Ray ray)
    {
        GameObject spawnedObject = Instantiate(bulletHolePrefab, hit.point, Quaternion.identity);
        Quaternion targetRotation = Quaternion.LookRotation(-hit.normal);

        spawnedObject.transform.rotation = targetRotation;
        spawnedObject.transform.SetParent(hit.transform);
        spawnedObject.transform.Rotate(Vector3.forward, Random.Range(0f, 360f));
        Destroy(spawnedObject, destroyDelay);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(origin.transform.position, origin.transform.position + origin.transform.forward * rayDistance);
    }
}
