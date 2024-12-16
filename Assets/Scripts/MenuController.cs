using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public string eszena;

    public GameObject settingsButtons;
    public bool settings =  false;

    public void LoadScene(string eszena)
    {
        SceneManager.LoadScene(eszena);
    }

    public void SceneButtons()
    {
        if(!settings)
        {
            settings = true;
            settingsButtons.SetActive(true);
        }
        else
        {
            settings = false;
            settingsButtons.SetActive(false);
        }
    }

    public void Exit()
    {
        Application.Quit();
    }
}
