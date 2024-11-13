using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.XR.Interaction.Toolkit;

public class PilaPlatosSnap : MonoBehaviour
{
    private bool limpio;
    private Renderer ren;
    public GameObject[] SnapPlaterrak;
    private int iZeinSnapPlaterra = 0;


    void Awake()
    {
        limpio = false;

        for (int i = 0; i < SnapPlaterrak.Length; i++)
        {
            SnapPlaterrak[i].transform.gameObject.SetActive(false);
        }       
    }

    void Update()
    {
        if (limpio == true)
        {
            SnapPlaterrak[iZeinSnapPlaterra].transform.gameObject.SetActive(true);
            
        }

        if (limpio == false) 
        {
            SnapPlaterrak[iZeinSnapPlaterra].transform.gameObject.SetActive(false);
        }

    }

    public void ShowSnapPlate()
    {
        SnapPlaterrak[iZeinSnapPlaterra].transform.gameObject.SetActive(true);
    }

    public void HideSnapPlate()
    {
        SnapPlaterrak[iZeinSnapPlaterra].transform.gameObject.SetActive(false);
    }

    public void NextPlate()
    {
        iZeinSnapPlaterra++;
        limpio = false;
    }

    public void Limpiado()
    {
        limpio = true;


    }
}
