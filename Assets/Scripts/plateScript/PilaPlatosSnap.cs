using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.XR.Interaction.Toolkit;

public class PilaPlatosSnap : MonoBehaviour
{
    private Renderer ren;
    public GameObject[] SnapPlaterrak;
    private int iZeinSnapPlaterra = 0;

    //private Task task;


    public Plato platoActivo;

    void Awake()
    {
        for (int i = 0; i < SnapPlaterrak.Length; i++)
        {
            SnapPlaterrak[i].transform.gameObject.SetActive(false);
        }       
    }

    void Update()
    {
        if (platoActivo.GetComponent<Plato>().limpio && SnapPlaterrak[iZeinSnapPlaterra] != null)
        {
            SnapPlaterrak[iZeinSnapPlaterra].transform.gameObject.SetActive(true); 

                        
        }

        if (!platoActivo.GetComponent<Plato>().limpio) 
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

        //task.TaskComplete(task);
    }

}
