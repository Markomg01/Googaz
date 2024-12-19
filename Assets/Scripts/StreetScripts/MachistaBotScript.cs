using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.XR.CoreUtils;
using UnityEngine;
using UnityEngine.UI;

public class MachistaBotScript : MonoBehaviour
{
    public float distanciaRaycastRobot = 100f;
    public Camera camera;
    public Canvas canvasFaces;
    public Canvas canvasScreen;
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

    private void Awake()
    {
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

    void Update()
    {
        LanzarRaycast();
        if (Input.GetKeyDown(KeyCode.J))
        {
            FillTaskList();
        }
    }

    void LanzarRaycast()
    {
        Ray ray = new Ray(camera.transform.position, camera.transform.forward);
        RaycastHit hit;

        Debug.DrawRay(camera.transform.position, camera.transform.forward * distanciaRaycastRobot, Color.green, .1f);

        if (Physics.Raycast(ray, out hit, distanciaRaycastRobot, machistaBotLayer))
        {
            canvasScreen.gameObject.SetActive(true);
            screenCollider.gameObject.SetActive(true);
        }
        else if (Physics.Raycast(ray, out hit, distanciaRaycastRobot, computerScreenLayer))
        {
            startText.transform.DOScale(0, 1);
            tasksParent.transform.DOScale(1, 1);
        }
        else
        {
            canvasScreen.gameObject.SetActive(false);
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
