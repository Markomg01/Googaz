using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeInOut : MonoBehaviour
{
    public bool fadeOnStart = true;
    public float fadeDuration = 1.5f;
    public Color fadecolor;
    private Renderer rend;

    private void Start()
    {
        rend = GetComponent<Renderer>();
        if (fadeOnStart)
            FadeIn();
    }

    public void FadeIn()
    {
        Fade(1, 0);
    }

    public void FadeOut()
    {
        Fade(0, 1);
        gameObject.SetActive(true);
    }

    public void Fade(float alphaIn, float alphaOut)
    {
        StartCoroutine(FadeRoutine(alphaIn, alphaOut));
    }

    public IEnumerator FadeRoutine(float alphaIn, float alphaOut)
    {
        float timer = 0;
        while (timer <= fadeDuration)
        {
            Color newcolor = fadecolor;
            newcolor.a = Mathf.Lerp(alphaIn, alphaOut, timer / fadeDuration);

            rend.material.SetColor("_Color", newcolor);

            timer += Time.deltaTime;
            yield return null;
        }

        Color newcolor2 = fadecolor;
        newcolor2.a = alphaOut;

        rend.material.SetColor("_Color", newcolor2);

        if (alphaOut == 0)
        {
            gameObject.SetActive(false);
        }
    }
}
