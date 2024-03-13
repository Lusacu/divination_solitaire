using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public GameObject mainUIWindow; // �������� UI ����
    public GameObject infoUIWindow; // ���� � �����������

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
