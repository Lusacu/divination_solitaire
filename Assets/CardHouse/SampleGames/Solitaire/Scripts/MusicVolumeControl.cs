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
        // ��������� ���������� �������� �������� �� ������ ������� ���������
        musicVolumeSlider.value = musicAudioSource.volume;
    }

    private void Update()
    {
        // ��������� ��������� �������������� �� ������ �������� ��������
        musicAudioSource.volume = musicVolumeSlider.value;
    }
}
