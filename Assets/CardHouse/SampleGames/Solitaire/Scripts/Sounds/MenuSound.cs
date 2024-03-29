using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuSound : MonoBehaviour
{
    public AudioClip menuSoundClip; // звуковой файл для воспроизведения
    private AudioSource menuSoundSource;

    void Start()
    {
        // Получаем компонент AudioSource
        menuSoundSource = GetComponent<AudioSource>();
        // Присваиваем звуковой файл
        menuSoundSource.clip = menuSoundClip;

        // Подписываемся на событие активации объекта
        gameObject.SetActive(true); // убедимся, что объект активен
        gameObject.SetActive(false); // снова деактивируем, чтобы сработало событие
        gameObject.SetActive(true); // активируем объект снова, чтобы вызвать событие

        // Проигрываем звук после небольшой задержки, чтобы дать время для анимации или эффектов меню
        Invoke("PlayMenuSound", 0.1f);
    }

    // Метод для воспроизведения звука
    void PlayMenuSound()
    {
        menuSoundSource.Play();
    }
}
