using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public string eszena;

    public GameObject sceneButtons;
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
            sceneButtons.SetActive(true);
        }
        else
        {
            settings = false;
            sceneButtons.SetActive(false);
        }
    }

    public void Exit()
    {
        Application.Quit();
    }
}
