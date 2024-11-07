using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaperCollector : MonoBehaviour
{
    public int paperSigned;
    public int paperToSign;
    public ParticleSystem particles;
    public ParticleSystem spark;
    bool a = false;
    public FaxMachine faxMachine;
    public Task taskScript;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Signed"))
        {
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
            faxMachine.CantSpawn();
            a = true;
            particles.Play();
            taskScript.TaskComplete(true);
        }
    }
}
