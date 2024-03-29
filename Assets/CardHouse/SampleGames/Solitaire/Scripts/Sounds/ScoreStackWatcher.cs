using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreStackWatcher : MonoBehaviour
{
    public CardHouse.CardGroup cardGroup; // Ссылка на компонент CardGroup
    public AudioClip soundEffect; // Звуковой эффект для воспроизведения

    private int previousMountedCardCount; // Предыдущее значение MountedCards

    void Start()
    {
        if (cardGroup == null)
        {
            Debug.LogError("CardGroup reference is not set in ScoreStackWatcher!");
            return;
        }

        // Запоминаем начальное значение MountedCards
        previousMountedCardCount = cardGroup.MountedCards.Count;

        // Запускаем Coroutine для отслеживания изменений в количестве карт
        StartCoroutine(CheckCardCount());
    }

    IEnumerator CheckCardCount()
    {
        while (true)
        {
            // Проверяем, изменилось ли значение MountedCards
            if (cardGroup.MountedCards.Count != previousMountedCardCount)
            {
                // Если да, воспроизводим звуковой эффект через AudioSource объекта PlaceCard_Sound
                GameObject placeCardSoundObject = GameObject.Find("PlaceCard_Sound"); // Ищем объект с именем "PlaceCard_Sound"
                if (placeCardSoundObject != null)
                {
                    AudioSource audioSource = placeCardSoundObject.GetComponent<AudioSource>(); // Получаем компонент AudioSource у найденного объекта
                    if (audioSource != null && soundEffect != null)
                    {
                        audioSource.PlayOneShot(soundEffect); // Воспроизводим звук через AudioSource
                    }
                }

                // Обновляем значение предыдущего количества карт
                previousMountedCardCount = cardGroup.MountedCards.Count;
            }

            yield return null; // Ждем один кадр
        }
    }
}

