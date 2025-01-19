using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class WordManager : MonoBehaviour
{
    [Header(" Elements ")]
    [SerializeField] private string secretWord;

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
    }

    public string GetSecretWord()
    {
        return secretWord.ToUpper();
    }
}
