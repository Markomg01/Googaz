using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

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
            tasksCompleted.Invoke();
        }
    }
}
