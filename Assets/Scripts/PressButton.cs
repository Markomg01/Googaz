using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PressButton : MonoBehaviour
{
    public InputActionReference UISkip = null;
 
    private void Awake()
    {
        UISkip.action.started += NextScene;
     }

    private void OnDestroy()
    {
        UISkip.action.started -= NextScene;
     }

    private void NextScene(InputAction.CallbackContext context)
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
