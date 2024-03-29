using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreStackWatcher : MonoBehaviour
{
    public CardHouse.CardGroup cardGroup; // Ссылка на компонент CardGroup
    public AudioClip placeCardSoundEffect; // Звуковой эффект для воспроизведения при перевороте карты
    public AudioClip shuffleSoundEffect; // Звуковой эффект для воспроизведения при перемешивании карт

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
                // Если значение MountedCards стало равным 0, значит карты были перемешаны
                if (cardGroup.MountedCards.Count == 0 && shuffleSoundEffect != null)
                {
                    PlaySound(shuffleSoundEffect);
                }
                // В противном случае воспроизводим звук переворота карты
                else if (placeCardSoundEffect != null)
                {
                    PlaySound(placeCardSoundEffect);
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

