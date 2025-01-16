using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollower : MonoBehaviour
{
        public Transform objectToFollow;

    private void Update()
    {
        transform.LookAt(objectToFollow.transform.position);    
    }
    
}
