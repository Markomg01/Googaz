using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.XR.CoreUtils;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MachistaBotScript : MonoBehaviour
{
    public float distanciaRaycastRobot = 100f;
    public Camera camera;
    public Canvas canvasFaces;
    public GameObject canvasScreenParent;
    public Collider screenCollider;
    public LayerMask machistaBotLayer;
    public LayerMask computerScreenLayer;
    public TaskManager taskManager;
    public GameObject taskTogglePrefab;
    public GameObject tasksParent;
    public GameObject display;
    public string finalTextString;
    public GameObject finalText;
    public string startTextString;
    public GameObject startText;
    public GameObject settingsButtons;
    public bool settings = false;

    public float time;
    public Image fill;
    public float max;
    public int cuarto = 1;
    public Animator redFilterAnimator;

    private void Awake()
    {
        max = time;
        finalText.GetComponent<TextMeshProUGUI>().text = finalTextString;
        startText.GetComponent<TextMeshProUGUI>().text=startTextString;
        FillTaskList();
        tasksParent.transform.DOScale(0, 0);
    }

    private void FillTaskList()
    {
        foreach (Task task in taskManager.tasksInScene)
        {
            taskTogglePrefab.GetComponent<Toggle>().isOn = task.GetComponent<Task>().finished;
            taskTogglePrefab.GetComponentInChildren<TextMeshProUGUI>().text = task.GetComponent<Task>().taskName;
            Instantiate(taskTogglePrefab, tasksParent.transform);
        }
    }

    bool a = true;

    void Update()
    {
        LanzarRaycast();
        Timer();
    }

    void Timer()
    {
        time -= Time.deltaTime;
        fill.fillAmount = time / max;

        if((time <= (max/4)*3) && (cuarto == 1))
        {
            redFilterAnimator.SetTrigger("playRed");
            cuarto += 1;
        }

        if (time <= max / 2 && cuarto == 2)
        {
            redFilterAnimator.SetTrigger("playRed");
            cuarto += 1;
        }

        if (time <= (max / 4) && cuarto == 3)
        {
            redFilterAnimator.SetTrigger("playRed");
            cuarto += 1;
        }

        if (time < 0)
        {
            time = 0;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    void LanzarRaycast()
    {
        Ray ray = new Ray(camera.transform.position, camera.transform.forward);
        RaycastHit hit;

        Debug.DrawRay(camera.transform.position, camera.transform.forward * distanciaRaycastRobot, Color.green, .1f);

        if (Physics.Raycast(ray, out hit, distanciaRaycastRobot, machistaBotLayer))
        {
            canvasScreenParent.gameObject.transform.DOScaleY(1, .5f);
            screenCollider.gameObject.transform.DOScaleY(1, 1);
            screenCollider.gameObject.SetActive(true);
        }
        else if (Physics.Raycast(ray, out hit, distanciaRaycastRobot, computerScreenLayer))
        {
            startText.transform.DOScale(0, 1);
            tasksParent.transform.DOScale(1, 1);
        }
        else
        {
            canvasScreenParent.gameObject.transform.DOScaleY(0, .1f);
            screenCollider.gameObject.transform.DOScaleY(0, 1);
            screenCollider.gameObject.SetActive(false);
        }
    }


    public void CheckTask(string Name)
    {
        for (int i = 0; i < tasksParent.transform.childCount; i++)
        {
            if (tasksParent.transform.GetChild(i).GetComponentInChildren<TextMeshProUGUI>().text == Name)
            {
                tasksParent.transform.GetChild(i).GetComponent<Toggle>().isOn = true;
            }
        }
    }

    public void SettingsButtons()
    {
        if (!settings)
        {
            settings = true;
            //sceneButtons.SetActive(true);
            settingsButtons.transform.DOScale(1,1);
            display.transform.DOScale(0, 1);
            //tasksParent.SetActive(false);
        }
        else
        {
            settings = false;
            //sceneButtons.SetActive(false);
            settingsButtons.transform.DOScale(0, 1);
            display.transform.DOScale(1, 1);
            //tasksParent.SetActive(true);
        }
    }
}
