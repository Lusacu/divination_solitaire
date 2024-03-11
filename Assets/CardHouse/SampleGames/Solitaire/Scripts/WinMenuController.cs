using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using CardHouse; // получаем доступ к пространству имен CardHouse, чтобы взаимодействовать с CardGroup

public class WinMenuController : MonoBehaviour
{
    public GameObject[] scoreStacks; // Массив объектов ScoreStack
    public GameObject winMenu; // UI окно Win_menu_1

    void Update()
    {
        bool allScoreStacksComplete = true; // Переменная, чтобы отслеживать, все ли ScoreStacks достигли 13 карт

        foreach (GameObject scoreStack in scoreStacks)
        {
            // Получаем компонент CardGroup для каждого объекта ScoreStack
            CardGroup cardGroup = scoreStack.GetComponent<CardGroup>();

            // Проверяем, если MountedCards в текущем ScoreStack равно 13
            if (cardGroup.MountedCards.Count != 13)
            {
                allScoreStacksComplete = false; // Если количество карт не равно 13, устанавливаем в false
                break; // Прерываем цикл, так как уже есть не полный ScoreStack
            }
        }

        // Если все ScoreStacks содержат по 13 карт, включаем UI окно
        if (allScoreStacksComplete)
        {
            winMenu.SetActive(true);
        }
    }
}
