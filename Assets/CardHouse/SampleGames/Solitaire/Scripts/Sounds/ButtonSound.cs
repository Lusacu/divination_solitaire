using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ButtonSound : MonoBehaviour, IPointerClickHandler
{

    public AudioClip clickSound;

    public void OnPointerClick(PointerEventData eventData)
    {
        if (clickSound != null)
        {
            // Создаем временный объект AudioSource
            GameObject audioGO = new GameObject("TempAudio");
            AudioSource audioSource = audioGO.AddComponent<AudioSource>();
            audioSource.clip = clickSound;
            audioSource.playOnAwake = false;

            // Воспроизводим звук и уничтожаем временный объект AudioSource
            audioSource.PlayOneShot(clickSound);
            Destroy(audioGO, clickSound.length);
        }
        else
        {
            Debug.LogWarning("AudioClip is not assigned!");
        }
    }
}
