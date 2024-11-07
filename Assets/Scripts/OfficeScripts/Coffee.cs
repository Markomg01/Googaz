using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coffee : MonoBehaviour
{
    public bool isFilled = false;
    public bool socket = false;

    public Vector3 ReferenceVector = Vector3.up;


    private void Update()
    {
        var output = Vector3.Dot(ReferenceVector, transform.TransformVector(ReferenceVector));

        if (output <= 0)
        {
            Debug.Log("lo has tirado");
            isFilled = false;
            GetComponent<Animator>().SetBool("fill", false);
        }
    }

    public void Fill()
    {
        if (!isFilled && socket)
        {
            GetComponent<Animator>().SetBool("fill", true);
        }
    }

    public void InSocket()
    {
        socket = true;
    }

    public void NotInSocket()
    {
        socket = false;
    }
}
