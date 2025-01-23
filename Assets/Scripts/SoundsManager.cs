using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundsManager : MonoBehaviour
{
    public static SoundsManager instance;

    [Header(" Sounds ")]
    [SerializeField] private AudioSource buttonSound;
    [SerializeField] private AudioSource letterAddedSound;
    [SerializeField] private AudioSource letterRemovedSound;
    [SerializeField] private AudioSource levelCompleteSound;
    [SerializeField] private AudioSource gameOverSound;

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

    private void Start()
    {
        InputManager.onLetterAdded += PlayLetterAddedCallback;
        InputManager.onLetterRemoved += PlayLetterRemovedCallback;

        GameManager.onGameStateChanged += GameStateChangedCallback;
    }

    private void OnDestroy()
    {
        InputManager.onLetterAdded -= PlayLetterAddedCallback;
        InputManager.onLetterRemoved -= PlayLetterRemovedCallback;

        GameManager.onGameStateChanged -= GameStateChangedCallback;

    }

    private void GameStateChangedCallback(GameState gameState)
    {
        switch(gameState)
        {
            case GameState.LevelComplete:
                levelCompleteSound.Play();
                break;
            case GameState.GameOver:
                gameOverSound.Play();
                break;
        }

    }

    private void PlayLetterRemovedCallback()
    {
        letterAddedSound.Play();
    }

    private void PlayLetterAddedCallback()
    {
        letterRemovedSound.Play();
    }

    public void PlayButtonSound()
    {
        buttonSound.Play();
    }

    internal void EnableSounds()
    {
        buttonSound.volume = 1;
        letterAddedSound.volume = 1;
        letterRemovedSound.volume = 1;
        levelCompleteSound.volume = 1;
        gameOverSound.volume = 1;
    }

    internal void DisableSounds()
    {
        buttonSound.volume = 0;
        letterAddedSound.volume = 0;
        letterRemovedSound.volume = 0;
        levelCompleteSound.volume = 0;
        gameOverSound.volume = 0;
    }
}
