using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.XR.Interaction.Toolkit;

public class CoffeeMachine : MonoBehaviour
{
    public GameObject coffeeVisual;
    public ParticleSystem particles;
    public GameObject coffee;
    public Collider finalSocket;
    public GameObject finalRef;

    private void Start()
    {
        particles.Stop();
    }

    public void CoffeeFill()
    {
        StartCoroutine(FillCoffee());
    }

    IEnumerator FillCoffee()
    {
        if (coffee.GetComponent<Coffee>().socket)
        {
            finalSocket.enabled = true;
            finalRef.SetActive(true);
            coffee.GetComponent<Coffee>().isFilled = true;
            coffee.GetComponent<Collider>().enabled = false;
            coffee.GetComponent<Animator>().SetBool("fill", true);
        }
        coffeeVisual.transform.DOScaleZ(1, .1f);
        particles.Play();
        yield return new WaitForSeconds(2);
        if (coffee.GetComponent<Coffee>().socket)
        {
            coffee.GetComponent<Collider>().enabled = true;
        }
        coffeeVisual.transform.DOScaleZ(0, .1f);
        particles.Stop();
    }
}
