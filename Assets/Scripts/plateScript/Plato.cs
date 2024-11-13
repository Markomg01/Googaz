using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.XR.Interaction.Toolkit;

public class Plato : MonoBehaviour
{
    private bool limpio;
    private Renderer ren;

    public Task task;

    [SerializeField] GameObject PilaPlatosSnap; 


    void Awake()
    {
        limpio = false;
    }

    void Update()
    {
        if (limpio == true)
        {
            ren = GetComponent<Renderer>();
            ren.material.color = Color.green;
            PilaPlatosSnap.GetComponent<PilaPlatosSnap>().ShowSnapPlate();
        }

        if (limpio == false) 
        {
            ren = GetComponent<Renderer>();
            ren.material.color = Color.grey;
            PilaPlatosSnap.GetComponent<PilaPlatosSnap>().HideSnapPlate();
        }
    }

    public void Limpios()
    {
        limpio = true;
        PilaPlatosSnap.GetComponent<PilaPlatosSnap>().Limpiado();

    }

}
