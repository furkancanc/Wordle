using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class WordManager : MonoBehaviour
{
    [Header(" Elements ")]
    [SerializeField] private string secretWord;
    [SerializeField] private TextAsset wordsText;
    private string words;

    public static WordManager instance;

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

        words = wordsText.text;
    }

    private void Start()
    {
        SetNewSecretWord();
    }

    public string GetSecretWord()
    {
        return secretWord.ToUpper();
    }

    private void SetNewSecretWord()
    {
        int wordCount = (words.Length + 2) / 7;
        int wordIndex = Random.Range(0, wordCount);
        int wordStartIndex = wordIndex * 7;

        secretWord = words.Substring(wordStartIndex, 5);
    }
}
