using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreStackWatcher : MonoBehaviour
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
                // ���� ��, ������������� �������� ������ ����� AudioSource ������� PlaceCard_Sound
                GameObject placeCardSoundObject = GameObject.Find("PlaceCard_Sound"); // ���� ������ � ������ "PlaceCard_Sound"
                if (placeCardSoundObject != null)
                {
                    AudioSource audioSource = placeCardSoundObject.GetComponent<AudioSource>(); // �������� ��������� AudioSource � ���������� �������
                    if (audioSource != null && soundEffect != null)
                    {
                        audioSource.PlayOneShot(soundEffect); // ������������� ���� ����� AudioSource
                    }
                }

                // ��������� �������� ����������� ���������� ����
                previousMountedCardCount = cardGroup.MountedCards.Count;
            }

            yield return null; // ���� ���� ����
        }
    }
}

