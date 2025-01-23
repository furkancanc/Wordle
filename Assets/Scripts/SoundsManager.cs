using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundsManager : MonoBehaviour
{
    public static SoundsManager instance;

    [Header(" Sounds ")]
    [SerializeField] private AudioSource buttonSound;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void PlayButtonSound()
    {
        buttonSound.Play();
    }

    internal void EnableSounds()
    {
        buttonSound.volume = 1;
    }

    internal void DisableSounds()
    {
        buttonSound.volume = 0;
    }
}
