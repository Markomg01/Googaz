using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coffee : MonoBehaviour
{
    public bool isFilled = false;
    public bool socket = false;
    public Collider finalSocket;
    public GameObject coffeeInMachine;
    public GameObject finalRef;

    public Vector3 ReferenceVector = Vector3.up;


    private void Update()
    {
        if (isFilled)
        {
            coffeeInMachine.SetActive(false);
            finalRef.SetActive(true);
        }
        var output = Vector3.Dot(ReferenceVector, transform.TransformVector(ReferenceVector));

        if (output <= 0)
        {
            Debug.Log("lo has tirado");
            coffeeInMachine.SetActive(true);
            finalSocket.enabled = false;
            finalRef.SetActive(false);
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
