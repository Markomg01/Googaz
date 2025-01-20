using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Samples.StarterAssets;

public class FaxMachine : MonoBehaviour
{
    public GameObject paper;
    public GameObject paperSpawner;
    public bool canSpawn;
    public Material faxLight;

    public GameObject buttonArrow;
    public GameObject stampArrow;
    public GameObject pileArrow;
    public bool stampIsBeingGrabbed;

    public bool taskEnded = false;

    private void Start()
    {
        CanSpawn();
    }

    public void SpawnPaper()
    {
        if (!taskEnded)
        {
            if (canSpawn)
            {
                buttonArrow.SetActive(false);
                if (!stampIsBeingGrabbed)
                {
                    stampArrow.SetActive(true);
                }
                GetComponent<AudioSource>().Play();
                Instantiate(paper, paperSpawner.transform.position, paperSpawner.transform.rotation);
                CantSpawn();
            }
        }
    }

    public void CanSpawn()
    {
        buttonArrow.SetActive(true);
        faxLight.DOColor(Color.green, .01f);
        faxLight.DOColor(Color.green, "_EmissionColor", .1f);
        canSpawn = true;
    }

    public void CantSpawn()
    {
        faxLight.DOColor(Color.red, .01f);
        faxLight.DOColor(Color.red, "_EmissionColor", .1f);
        canSpawn = false;
    }

    public void stampGrabbed()
    {
        stampIsBeingGrabbed = true;
    }

    public void stampNotGrabbed()
    {
        stampIsBeingGrabbed = false;
    }
}
