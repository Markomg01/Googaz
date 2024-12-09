using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PaperCollector : MonoBehaviour
{
    public int paperSigned;
    public int paperToSign;
    public ParticleSystem particles;
    public ParticleSystem spark;
    bool a = false;
    public FaxMachine faxMachine;
    public Task taskScript;

    public GameObject pileArrow;
    public GameObject arrows;

    public AudioSource endSound;

    [SerializeField]
    UnityEvent paperCollected;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Signed"))
        {
            GetComponent<AudioSource>().Play();
            pileArrow.SetActive(false);
            paperCollected.Invoke();
            GetComponent<Outline>().OutlineWidth = 0;
            faxMachine.CanSpawn();
            paperSigned++;
            spark.Play();
            Destroy(collision.gameObject);
        }
    }

    private void Update()
    {
        if (paperSigned >= paperToSign && !a)
        {
            faxMachine.taskEnded = true;
            arrows.SetActive(false);
            faxMachine.CantSpawn();
            a = true;
            particles.Play();
            taskScript.TaskComplete(true);
        }
    }
}
