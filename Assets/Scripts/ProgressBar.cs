using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.Interaction.Toolkit;

public class ProgressBar : MonoBehaviour
{
    public Slider slider;
    public float fillSpeed = .5f;
    private float targetProcess = 0;
    public XRGrabInteractable interactable;
    public GameObject press;
    public GameObject wait;
    public GameObject take;
    public ParticleSystem particles;
    bool a = true;

    private void Awake()
    {
        interactable.enabled = false;
    }

    private void Update()
    {
        if (slider.value < targetProcess)
        {
            slider.value += fillSpeed * Time.deltaTime;
        }
        if (slider.value == 1 && a)
        {
            wait.SetActive(false);
            take.SetActive(true);
            interactable.enabled = true;
            particles.Play();
            a = !a;
        }
    }

    public void IncrementProgress()
    {
        press.SetActive(false);
        wait.SetActive(true);
        targetProcess = slider.value + 1;
    }
}
