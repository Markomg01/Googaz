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





    private void Awake()
    {
        for (int i = 0; i < Platerrak.Length; i++)
        {
            Platerrak[i].transform.GetChild(0).gameObject.SetActive(false);
            Platerrak[i].transform.GetChild(1).gameObject.SetActive(false);
            Platerrak[i].transform.GetChild(2).gameObject.SetActive(false);
            Platerrak[i].transform.GetChild(3).gameObject.SetActive(false);
        }


        Platerrak[0].transform.GetChild(0).gameObject.SetActive(true);
        count = 0;

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

                //brillo1.Play();


            }

            if (collision.gameObject.CompareTag("cuboRgt"))
            {
                Platerrak[iZeinPlaterra].transform.GetChild(1).gameObject.SetActive(false);
                Platerrak[iZeinPlaterra].transform.GetChild(2).gameObject.SetActive(true);

                count++;

                Fregar.Play();

                //brillo2.Play();



            }

            if (collision.gameObject.CompareTag("cuboBot"))
            {
                Platerrak[iZeinPlaterra].transform.GetChild(2).gameObject.SetActive(false);
                Platerrak[iZeinPlaterra].transform.GetChild(3).gameObject.SetActive(true);

                count++;

                //brillo3.Play();


            }

            if (collision.gameObject.CompareTag("cuboLft"))
            {
                Platerrak[iZeinPlaterra].transform.GetChild(3).gameObject.SetActive(false);
                Platerrak[iZeinPlaterra].transform.GetChild(0).gameObject.SetActive(true);

                count++;

                //brillo4.Play();


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
                if (Platerrak[iZeinPlaterra] != null)
                {
                    Platerrak[iZeinPlaterra].transform.GetChild(0).gameObject.SetActive(true);
                }
               
            }
        }       
    }
}
