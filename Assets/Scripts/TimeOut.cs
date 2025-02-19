using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TimeOut : MonoBehaviour
{
    public MachistaBotScript machistaBot;

    private void Update()
    {
        if(machistaBot.time == 0)
        {
            StartCoroutine(RestartScene());
        }
    }

    IEnumerator RestartScene()
    {
        gameObject.transform.DOScale(1, .5f);
        yield return new WaitForSeconds(4f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        yield return null;

    }
}
