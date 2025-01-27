using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SoundRandomiser : MonoBehaviour
{
    public AudioClip[] sounds;
    private AudioSource source;
    [Range(0.1f, 0.8f)]
    public float volumeChangeMultiplier = 0.2f;
    [Range(0.1f, 0.8f)]
    public float pitchChangeMultiplier = 0.2f;
    public float timeRemaining = 10f;
    public float secondTimeRemaining;

    private int lastSoundIndex = -1;  //esto es para que no se repita el sonido y haya mas variedad, para que en el ramdom no se ponga dos veces seguidas el ruido

    private void Start()
    {
        source = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime;
        }

        if (timeRemaining < 0)
        {
            timeRemaining = secondTimeRemaining;
            if (!source.isPlaying)
            {
                int newSoundIndex;

                do
                {
                    newSoundIndex = Random.Range(0, sounds.Length);
                } while (newSoundIndex == lastSoundIndex);

                lastSoundIndex = newSoundIndex;

                source.clip = sounds[newSoundIndex];
                source.volume = Random.Range(1 - volumeChangeMultiplier, 1);
                source.pitch = Random.Range(1 - pitchChangeMultiplier, 1 + pitchChangeMultiplier);
                source.PlayOneShot(source.clip);
            }            
        }       
        
    }
}
