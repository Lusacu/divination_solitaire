using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreStackWatcher : MonoBehaviour
{
    public CardHouse.CardGroup cardGroup; // ������ �� ��������� CardGroup
    public AudioClip placeCardSoundEffect; // �������� ������ ��� ��������������� ��� ���������� �����
    public AudioClip shuffleSoundEffect; // �������� ������ ��� ��������������� ��� ������������� ����

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
                // ���� �������� MountedCards ����� ������ 0, ������ ����� ���� ����������
                if (cardGroup.MountedCards.Count == 0 && shuffleSoundEffect != null)
                {
                    PlaySound(shuffleSoundEffect);
                }
                // � ��������� ������ ������������� ���� ���������� �����
                else if (placeCardSoundEffect != null)
                {
                    PlaySound(placeCardSoundEffect);
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

