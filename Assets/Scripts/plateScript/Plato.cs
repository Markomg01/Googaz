using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.XR.Interaction.Toolkit;

public class Plato : MonoBehaviour
{
    public bool limpio;
    private Renderer ren;

    //public Task task;

    [SerializeField] GameObject PilaPlatosSnap;


    void Awake()
    {
        limpio = false;
        ren = GetComponent<Renderer>();
       // ren.material.color = Color.grey;
        PilaPlatosSnap.GetComponent<PilaPlatosSnap>().HideSnapPlate();
    }

    void Update()
    {
         
    }

    public void Limpios()
    {
        limpio = true;
        ren = GetComponent<Renderer>();
       // ren.material.color = Color.green;
        PilaPlatosSnap.GetComponent<PilaPlatosSnap>().ShowSnapPlate();

        
    }

}
