using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using CardHouse; // �������� ������ � ������������ ���� CardHouse, ����� ����������������� � CardGroup

public class WinMenuController : MonoBehaviour
{
    public GameObject[] scoreStacks; // ������ �������� ScoreStack
    public GameObject winMenu; // UI ���� Win_menu_1

    void Update()
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
        if (allScoreStacksComplete)
        {
            winMenu.SetActive(true);
        }
    }
}
