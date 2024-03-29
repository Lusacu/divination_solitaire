using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreStackWatcherDeck : MonoBehaviour
{
    public CardHouse.CardGroup cardGroup; // ������ �� ��������� CardGroup
    public AudioClip soundEffect; // �������� ������ ��� ���������������

    private int previousMountedCardCount; // ���������� �������� MountedCards

    void Start()
    {
        if (cardGroup == null)
        {
            Debug.LogError("CardGroup reference is not set in ScoreStackWatcher!");
            return;
        }

        // ���������� ��������� �������� MountedCards
        previousMountedCardCount = cardGroup.MountedCards.Count;

        // ��������� Coroutine ��� ������������ ��������� � ���������� ����
        StartCoroutine(CheckCardCount());
    }

    IEnumerator CheckCardCount()
    {
        while (true)
        {
            // ���������, ���������� �� �������� MountedCards
            if (cardGroup.MountedCards.Count != previousMountedCardCount)
            {
                // ���� ���������� �������� ���� ����� 0, � ������� ������ 0, ������������� �������� ������
                if (previousMountedCardCount == 0 && cardGroup.MountedCards.Count > 0 && soundEffect != null)
                {
                    PlaySound(soundEffect);
                }

                // ��������� �������� ����������� ���������� ����
                previousMountedCardCount = cardGroup.MountedCards.Count;
            }

            yield return null; // ���� ���� ����
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
