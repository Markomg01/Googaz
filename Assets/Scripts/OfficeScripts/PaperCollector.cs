using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaperCollector : MonoBehaviour
{
    public int paperSigned;
    public int paperToSign;
    public ParticleSystem particles;
    bool a = false;
    public FaxMachine faxMachine;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Signed"))
        {
            faxMachine.CanSpawn();
            paperSigned++;
            Destroy(other.gameObject);
        }
    }

    private void Update()
    {
        if(paperSigned >= paperToSign && !a)
        {
            faxMachine.CantSpawn();
            a = true;
            particles.Play();
        }
    }
}
