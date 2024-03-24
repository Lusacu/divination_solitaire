using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MusicVolumeControl : MonoBehaviour
{
    public Slider musicVolumeSlider;
    public AudioSource musicAudioSource;

    private void Start()
    {
        // Настройка начального значения слайдера на основе текущей громкости
        musicVolumeSlider.value = musicAudioSource.volume;
    }

    private void Update()
    {
        // Изменение громкости аудиоисточника на основе значения слайдера
        musicAudioSource.volume = musicVolumeSlider.value;
    }
}
