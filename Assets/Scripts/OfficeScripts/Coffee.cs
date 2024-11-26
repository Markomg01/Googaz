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

    public GameObject coffeeArrow;
    public GameObject socketArrow;
    public GameObject buttonArrow;
    public GameObject finalArrow;

    private void Update()
    {
        if (isFilled)
        {
            socketArrow.SetActive(false);
            buttonArrow.SetActive(false);
            finalArrow.SetActive(true);
            coffeeInMachine.SetActive(false);
            finalRef.SetActive(true);
        }
        var output = Vector3.Dot(ReferenceVector, transform.TransformVector(ReferenceVector));

        if (output <= 0)
        {
            Debug.Log("lo has tirado");
            socketArrow.SetActive(true);
            finalArrow.SetActive(false);
            buttonArrow.SetActive(false);
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

    public void ActivateCoffeeArrow(bool a)
    {
        coffeeArrow.SetActive(a);
    }

    public void ActivateSocketArrow(bool a)
    {
        if(!socket)
        {
            socketArrow.SetActive(a);
        }
    }

    public void ActivateButtonArrow(bool a)
    {
        if(!isFilled)
        {
            buttonArrow.SetActive(a);
        }
    }
}
