using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChatBox : MonoBehaviour
{
    public List<GameObject> texts = new List<GameObject>();

    public GameObject box;
    int a;

    private void OnTriggerEnter(Collider other)
    {
        a = Random.Range(0, texts.Count);
        if(other.CompareTag("Player"))
        {
            box.transform.DOScale(1, .5f);
            texts[a].SetActive(true);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            box.transform.DOScale(0, .5f);
            texts[a].SetActive(false);

        }
    }
}
