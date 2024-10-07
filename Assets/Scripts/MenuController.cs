using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public string eszena;

    public void LoadScene(string eszena)
    {
        SceneManager.LoadScene(eszena);
    }

    public void Exit()
    {
        Application.Quit();
    }
}
