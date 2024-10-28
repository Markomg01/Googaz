using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class PlatesCleanedDetector : MonoBehaviour
{
    public int socketsToFill;
    int num = 0;
    bool a = true;
    public ParticleSystem particles;

    private void Update()
    {
        if(num == socketsToFill && a)
        {
            a = !a;
            particles.Play();   
        }
    }

    public void SocketFull()
    {
        num++;
    }
}
