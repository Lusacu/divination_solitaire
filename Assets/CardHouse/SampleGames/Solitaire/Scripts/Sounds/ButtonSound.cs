using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ButtonSound : MonoBehaviour
{

    public AudioClip clickSound;
    public AudioSource audioSource;

    public void ClickSound()
    {
        audioSource.PlayOneShot(clickSound);
    }


   
}
