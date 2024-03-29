using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreStackWatcherDeck : MonoBehaviour
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
                // Если предыдущее значение было равно 0, а текущее больше 0, воспроизводим звуковой эффект
                if (previousMountedCardCount == 0 && cardGroup.MountedCards.Count > 0 && soundEffect != null)
                {
                    PlaySound(soundEffect);
                }

                // Обновляем значение предыдущего количества карт
                previousMountedCardCount = cardGroup.MountedCards.Count;
            }

            yield return null; // Ждем один кадр
        }
    }

    void PlaySound(AudioClip clip)
    {
        GameObject placeCardSoundObject = GameObject.Find("PlaceCard_Sound");
        if (placeCardSoundObject != null)
        {
            AudioSource audioSource = placeCardSoundObject.GetComponent<AudioSource>();
            if (audioSource != null)
            {
                audioSource.PlayOneShot(clip);
            }
        }
    }
}
