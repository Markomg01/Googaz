using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PressButton : MonoBehaviour
{
    public InputActionReference UISkip = null;

    [SerializeField]
    UnityEvent buttonPressed;

    private void Awake()
    {
        UISkip.action.started += ButtonPressed;
     }

    private void OnDestroy()
    {
        UISkip.action.started -= ButtonPressed;
     }

    public void ButtonPressed(InputAction.CallbackContext context)
    {
        buttonPressed.Invoke();
    }
    
    public void NextScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
