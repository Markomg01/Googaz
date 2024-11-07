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

    private void Start()
    {
        CanSpawn();
    }

    public void SpawnPaper()
    {
        if (canSpawn)
        {
            Instantiate(paper, paperSpawner.transform.position, paperSpawner.transform.rotation);
            CantSpawn();
        }
    }

    public void CanSpawn()
    {
        faxLight.DOColor(Color.green, .01f);
        canSpawn = true;
    }

    public void CantSpawn()
    {
        faxLight.DOColor(Color.red, .01f);
        canSpawn = false;
    }
}
