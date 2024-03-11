using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using CardHouse; // �������� ������ � ������������ ���� CardHouse, ����� ����������������� � CardGroup

public class WinMenuController : MonoBehaviour
{
    public GameObject[] scoreStacks; // ������ �������� ScoreStack
    public GameObject winMenu; // UI ���� Win_menu_1
    private bool win_menu_opened = false; // ����������, ����� �����������, ������� �� ���� ��������
    private bool buttonClicked = false; // ���� ��� ������������ ������� ������

    void Update()
    {
        if (!buttonClicked)
        {
            bool allScoreStacksComplete = true; // ����������, ����� �����������, ��� �� ScoreStacks �������� 13 ����

            foreach (GameObject scoreStack in scoreStacks)
            {
                // �������� ��������� CardGroup ��� ������� ������� ScoreStack
                CardGroup cardGroup = scoreStack.GetComponent<CardGroup>();

                // ���������, ���� MountedCards � ������� ScoreStack ����� 13
                if (cardGroup.MountedCards.Count != 13)
                {
                    allScoreStacksComplete = false; // ���� ���������� ���� �� ����� 13, ������������� � false
                    break; // ��������� ����, ��� ��� ��� ���� �� ������ ScoreStack
                }
            }

            // ���� ��� ScoreStacks �������� �� 13 ����, �������� UI ����
            if (allScoreStacksComplete && !win_menu_opened)
            {
                winMenu.SetActive(true); // �������� ���� ������ ���� someCondition ������� � winMenu �� �������
                win_menu_opened = true; // ������������� ����, ��� ���� �������� �������
            }
        }
    }

    // ��������� ����� ��� ��������� ������� ������ Button_divination
    public void OnButtonDivinationClicked()
    {
        
        // ���������, ������� �� ���� Win_menu_1
        if (winMenu.activeSelf)
        {
            
            // ���� ��, ��������� ���
            winMenu.SetActive(false);
            win_menu_opened = false; // ������������� ����, ��� ���� �������� �������
            buttonClicked = true; // ������������� ����, ��� ������ ���� ������
            
        }
    }
    // ���������� ��������� ����� ������ ����� ����
    public void NewGameOnButtonDivinationClicked()
    {
        if (buttonClicked == true)
        {
            buttonClicked = false;
        }
    }

}
