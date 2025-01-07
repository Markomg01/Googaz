using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class TaskManager : MonoBehaviour
{
    public List<Task> tasksInScene = new List<Task>();

    public FadeInOut fade;

    public MachistaBotScript machistaBot;

    public AudioSource taskCompleteAudio;
    public AudioSource allTaskCompleteAudio;

    [SerializeField]
    UnityEvent tasksCompleted;

    public void CheckTasksCompleted()
    {
        int howManyFinished = 0;
        for (int i = 0; i < tasksInScene.Count; i++)
        {
            if (tasksInScene[i].IsFinished())
            {
                howManyFinished++;
                machistaBot.CheckTask(tasksInScene[i].taskName);
                taskCompleteAudio.Play();
            }
        }

        if (howManyFinished == tasksInScene.Count)
        {
            allTaskCompleteAudio.Play();
            machistaBot.display.transform.DOScale(0, 1);
            machistaBot.settingsButtons.transform.DOScale(0, 1);
            machistaBot.finalText.gameObject.transform.DOScale(1, 1);
            tasksCompleted.Invoke();
        }
    }

    public string nextSceneName;

    public void ChangeScene()
    {
        fade.FadeOut();
    SceneManager.LoadScene(nextSceneName);
    }
}
