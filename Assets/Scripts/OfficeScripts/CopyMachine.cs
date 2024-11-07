using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Samples.StarterAssets;

public class CopyMachine : MonoBehaviour
{
    public GameObject copies;
    public GameObject fakeCopies;
    public Animator copyMachine;
    bool paperInPrinter =  false;
    public bool topClosed;
    public GameObject printerTop;

    Vector3 ReferenceVector = -Vector3.up;

    private void Update()
    {
        var output = Vector3.Dot(ReferenceVector, printerTop.transform.TransformVector(ReferenceVector));
        if (output <= -10f)
        {
            topClosed = false;
        }
        else 
        {
            topClosed= true;
        }
    }

    public void PrintPaper()
    {
        if (paperInPrinter && topClosed)
        {
            copyMachine.Play("CopyMachine");
        }
    }

    public void PaperInPrinter()
    {
        paperInPrinter = true;
    }

    public void PaperOutPrinter() 
    {
        paperInPrinter = false;
    }

    public void PrintingEnd()
    {
        copies.SetActive(true);
        fakeCopies.SetActive(false);
    }
}
