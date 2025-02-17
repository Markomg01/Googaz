using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    [SerializeField]
    private float timeMax;
    [SerializeField]
    private Image stressBar;

    public void ChangeScene()
    {
        SceneManager.LoadScene("kotxea");
    }

    //public int xPos;
    //public int yPos;
    //public int zPos;
    private float actualTime;
    //public AudioSource faputa;
    //bool song = false;

    private bool activateTime = false;

    private void Start()
    {
        Activartemporizador();
        //faputa.Stop();
        //song = false;
    }
    private void Update()
    {
        if (activateTime)
        {
            CambiarContador();
        }
    }

    private void CambiarContador()
    {
        actualTime -= Time.deltaTime;

        if (actualTime >= 0)
        {
            stressBar.fillAmount = actualTime / timeMax;
        }
        if (actualTime <= 112)
        {
            /*if (!song)
            {
                                faputa.Play();
                song = true;
            }
            */
        }
        if (actualTime <= 0)
        {
            ChangeScene();
        }

    }

    private void CambiarTemporizador(bool estado)
    {
        activateTime = estado;
    }

    public void Activartemporizador()
    {
        actualTime = timeMax;
        stressBar.fillAmount = 1;
        CambiarTemporizador(true);
    }

    public void DesactivarTemporizador()
    {
        CambiarTemporizador(false);
    }
}

