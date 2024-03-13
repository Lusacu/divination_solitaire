using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public GameObject mainUIWindow; // Основное UI окно
    public GameObject infoUIWindow; // Окно с информацией

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ToggleUIWindow(mainUIWindow);
        }
        else if (Input.GetKeyDown(KeyCode.I))
        {
            ToggleUIWindow(infoUIWindow);
        }
    }

    void ToggleUIWindow(GameObject window)
    {
        if (window != null)
        {
            window.SetActive(!window.activeSelf);
        }
    }
}
