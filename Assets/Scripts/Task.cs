using UnityEngine;
using UnityEngine.UI;

public class Task : MonoBehaviour
{
    public string taskName;
    public bool finished;

    public Toggle toggle;

    TaskManager manager;

    private void Start()
    {
        manager = GameObject.Find("GameManager").GetComponent<TaskManager>();
    }


    public Task(string name)
    {
        TaskComplete(false);

        taskName = name;
    }

    public void TaskComplete(bool completed)
    {
                finished = completed;
        toggle.isOn = completed;
        manager.CheckTasksCompleted();
    }

    public bool IsFinished()
    {
        return finished;
    }

}



