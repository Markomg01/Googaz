using System.Collections;
using System.Collections.Generic;
//using Unity.Burst.CompilerServices;
using UnityEngine;

public class DecalProjector : MonoBehaviour
{
    public GameObject paperPile;

    [SerializeField] GameObject bulletHolePrefab;
    [SerializeField] float destroyDelay;

    public float rayDistance;
    public GameObject origin;

    Ray currentRay;
    RaycastHit currentHit;

    public GameObject pileArrow;
    public GameObject stampArrow;
    public bool paperSigned;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Paper"))
        {
            GetComponent<AudioSource>().Play();
            paperPile.GetComponent<Outline>().OutlineWidth = 3;
            Ray ray = new Ray(origin.transform.position, origin.transform.forward);

            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, rayDistance))
            {
                SpawnBulletHole(hit, ray);
                pileArrow.SetActive(true);
                paperSigned = true;
                DeactivateArrow();
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

    public void ActivateArrow()
    {
        if(!paperSigned)
        {
            stampArrow.SetActive(true);
        }
    }

    public void DeactivateArrow()
    {
        stampArrow.SetActive(false);
    }

    public void resetPaperSigned()
    {
        paperSigned = false;
    }
}
