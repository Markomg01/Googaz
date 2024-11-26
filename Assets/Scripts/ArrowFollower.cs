using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowFollower : MonoBehaviour
{
    public Transform objectToFollow;

    private void Update()
    {
            transform.position = new Vector3(objectToFollow.transform.position.x, objectToFollow.transform.position.y, objectToFollow.transform.position.z);
    }
}
