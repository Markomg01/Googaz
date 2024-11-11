using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class TaskManager : MonoBehaviour
{
    public List<Task> tasksInScene = new List<Task>();

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
            }
        }

        if (howManyFinished == tasksInScene.Count)
        {
            Debug.Log("All Tasks Completed");
            tasksCompleted.Invoke();
        }
    }

    public string nextSceneName;

    public void ChangeScene()
    {
        Debug.Log(nextSceneName + " sceneLoaded");
        SceneManager.LoadScene(nextSceneName);
    }
}
