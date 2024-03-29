using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuSound : MonoBehaviour
{
    public AudioClip menuSoundClip; // �������� ���� ��� ���������������
    private AudioSource menuSoundSource;

    void Start()
    {
        // �������� ��������� AudioSource
        menuSoundSource = GetComponent<AudioSource>();
        // ����������� �������� ����
        menuSoundSource.clip = menuSoundClip;

        // ������������� �� ������� ��������� �������
        gameObject.SetActive(true); // ��������, ��� ������ �������
        gameObject.SetActive(false); // ����� ������������, ����� ��������� �������
        gameObject.SetActive(true); // ���������� ������ �����, ����� ������� �������

        // ����������� ���� ����� ��������� ��������, ����� ���� ����� ��� �������� ��� �������� ����
        Invoke("PlayMenuSound", 0.1f);
    }

    // ����� ��� ��������������� �����
    void PlayMenuSound()
    {
        menuSoundSource.Play();
    }
}
