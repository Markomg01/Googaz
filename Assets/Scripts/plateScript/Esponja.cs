using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Esponja : MonoBehaviour
{

    public GameObject[] Platerrak;
    private int count;
    private int iZeinPlaterra = 0;
    public AudioSource Fregar;

    public ParticleSystem brillo1;
    public ParticleSystem brillo2;
    public ParticleSystem brillo3;
    public ParticleSystem brillo4;

    public ParticleSystem brillo5;
    public ParticleSystem brillo6;
    public ParticleSystem brillo7;
    public ParticleSystem brillo8;

    public ParticleSystem brillo9;
    public ParticleSystem brillo10;
    public ParticleSystem brillo11;
    public ParticleSystem brillo12;

    public ParticleSystem brillo13;
    public ParticleSystem brillo14;
    public ParticleSystem brillo15;
    public ParticleSystem brillo16;

    public ParticleSystem brillo17;
    public ParticleSystem brillo18;
    public ParticleSystem brillo19;
    public ParticleSystem brillo20;

    //public Material sucio5;
    //public Material sucio4;
    //public Material sucio3;
    //public Material sucio2;
    //public Material limpio1;

    Color PlaterrenHasieraKolorea;

    public Material suciedad;

    //public float mierdaInicial = 0f;




    private void Awake()
    {
        for (int i = 0; i < Platerrak.Length; i++)
        {
            Platerrak[i].transform.GetChild(0).gameObject.SetActive(false);
            Platerrak[i].transform.GetChild(1).gameObject.SetActive(false);
            Platerrak[i].transform.GetChild(2).gameObject.SetActive(false);
            Platerrak[i].transform.GetChild(3).gameObject.SetActive(false);
        }

       // mierdaInicial = Platerrak[0].GetComponent<Renderer>().material.GetFloat("_Activate");
       // 
        Platerrak[0].transform.GetChild(0).gameObject.SetActive(true);
        count = 0;

    }

    void KoloreaJeitzi()
    {
        float mierda = Platerrak[iZeinPlaterra].GetComponent<Renderer>().material.GetFloat("_Activate");
        mierda = mierda  - 0.1f;
        Platerrak[iZeinPlaterra].GetComponent<Renderer>().material.SetFloat("_Activate", mierda);


      /*  float kolorin = Platerrak[0].GetComponent<Renderer>().material.GetFloat("_Activate");
        kolorin.r = kolorin.r + ((1-PlaterrenHasieraKolorea.r) / 20);
        kolorin.g = kolorin.g + ((1 - PlaterrenHasieraKolorea.g) / 20);
        kolorin.b = kolorin.b + ((1 - PlaterrenHasieraKolorea.b) / 20);
        Platerrak[iZeinPlaterra].GetComponent<Renderer>().material.color=kolorin;*/
        
    }



    private void OnTriggerEnter(Collider collision)
    {

        if (collision.gameObject.transform.parent.gameObject.name.EndsWith(iZeinPlaterra.ToString()))
        {
            if (collision.gameObject.CompareTag("cuboTop"))
            {
                Platerrak[iZeinPlaterra].transform.GetChild(0).gameObject.SetActive(false);
                Platerrak[iZeinPlaterra].transform.GetChild(1).gameObject.SetActive(true);
                count++;

                brillo1.Play();
                
                brillo5.Play();
                brillo9.Play();
                brillo13.Play();
                brillo17.Play();


                KoloreaJeitzi();
            }

            if (collision.gameObject.CompareTag("cuboRgt"))
            {
                Platerrak[iZeinPlaterra].transform.GetChild(1).gameObject.SetActive(false);
                Platerrak[iZeinPlaterra].transform.GetChild(2).gameObject.SetActive(true);

                count++;

                Fregar.Play();

                brillo2.Play();
                
                brillo6.Play();
                brillo10.Play();
                brillo14.Play();
                brillo18.Play();


                KoloreaJeitzi();

            }

            if (collision.gameObject.CompareTag("cuboBot"))
            {
                Platerrak[iZeinPlaterra].transform.GetChild(2).gameObject.SetActive(false);
                Platerrak[iZeinPlaterra].transform.GetChild(3).gameObject.SetActive(true);

                count++;

                brillo3.Play();
                
                brillo7.Play();
                brillo11.Play();
                brillo15.Play();
                brillo19.Play();

                KoloreaJeitzi();

            }

            if (collision.gameObject.CompareTag("cuboLft"))
            {
                Platerrak[iZeinPlaterra].transform.GetChild(3).gameObject.SetActive(false);
                Platerrak[iZeinPlaterra].transform.GetChild(0).gameObject.SetActive(true);

                count++;

                brillo4.Play();
                
                brillo8.Play();
                brillo12.Play();
                brillo16.Play();
                brillo20.Play();

                KoloreaJeitzi();
            }

            if (count == 20)
            {
                count = 0;

                Platerrak[iZeinPlaterra].GetComponent<Plato>().Limpios();
                Platerrak[iZeinPlaterra].transform.GetChild(0).gameObject.SetActive(false);
                Platerrak[iZeinPlaterra].transform.GetChild(1).gameObject.SetActive(false);
                Platerrak[iZeinPlaterra].transform.GetChild(2).gameObject.SetActive(false);
                Platerrak[iZeinPlaterra].transform.GetChild(3).gameObject.SetActive(false);
                iZeinPlaterra++;
                if (iZeinPlaterra < Platerrak.Length)
                {
                    if (Platerrak[iZeinPlaterra] != null)
                    {
                        Platerrak[iZeinPlaterra].transform.GetChild(0).gameObject.SetActive(true);
                    }
                }
            }
        }       
    }
}
