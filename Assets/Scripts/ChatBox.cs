using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChatBox : MonoBehaviour
{
    public List<GameObject> texts = new List<GameObject>();

    public GameObject box;
    int currentText;
    bool canEnter = true;
    bool canExit = true;

    private void OnTriggerEnter(Collider other)
    {
        currentText = Random.Range(0, texts.Count);

        if (other.CompareTag("Player") && canEnter)
        {
            canExit = true;
            canEnter = false;
            box.transform.DOScale(1, .5f);
            texts[currentText].SetActive(true);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player") && canExit)
        {
            canEnter = true;
            canExit = false;
                        box.transform.DOScale(0, .5f);
            foreach (GameObject go in texts)
            {
                go.SetActive(false);
            }          
        }
    }
}
