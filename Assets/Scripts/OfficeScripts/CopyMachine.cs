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
    bool paperInPrinter = false;
    public bool topClosed;
    public GameObject printerTop;

    public GameObject paperArrow;
    public GameObject printerArrow;
    public GameObject socketArrow;
    public GameObject copiesInPrinterArrow;
    public GameObject copiesArrow;

    public GameObject socket;

    public GameObject socketHologram;
    public GameObject finalHologram;

    Vector3 ReferenceVector = -Vector3.up;

    private void Update()
    {
        var output = Vector3.Dot(ReferenceVector, printerTop.transform.TransformVector(ReferenceVector));
        if (output <= -10f)
        {
            topClosed = false;
            socket.SetActive(true);
            if (!paperInPrinter)
            {
                socketArrow.SetActive(true);
                socketHologram.SetActive(true);
            }
        }
        else
        {
            topClosed = true;
            if (!paperInPrinter)
            {
                socket.SetActive(false);
            }
            socketArrow.SetActive(false);
            socketHologram.SetActive(false);
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
        copiesInPrinterArrow.SetActive(true);
        copies.SetActive(true);
        finalHologram.SetActive(true);
        fakeCopies.SetActive(false);
    }

    public void ActivatePaperArrow(bool a)
    {
        paperArrow.SetActive(a);
    }

    public void ActivatePrinterArrow(bool a)
    {
        if(!paperInPrinter)
        {
            printerArrow.SetActive(a);
        }
    }

    public void ActivateCopiesArrow(bool a)
    {
        copiesArrow.SetActive(a);
    }

    public void ActivateFinalHologram(bool a)
    {
        finalHologram.SetActive(a);
    }
}
