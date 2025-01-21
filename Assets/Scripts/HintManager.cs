using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class HintManager : MonoBehaviour
{
    [Header(" Elements ")]
    [SerializeField] private Transform keyboard;
    private KeyboardKey[] keys;

    private void Awake()
    {
        keys = keyboard.GetComponentsInChildren<KeyboardKey>();
    }

    public void KeyboardHint()
    {
        string secretWord = WordManager.instance.GetSecretWord();

        List<KeyboardKey> untouchedKeys = new List<KeyboardKey>();

        for (int i = 0; i < keys.Length; ++i)
        {
            if (keys[i].IsUntouched())
            {
                untouchedKeys.Add(keys[i]);
            }
        }

        // At this pont, we have a list of all the untouched keys
        // Let's remove the ones that are in the secret word to avoid graying them out

        List<KeyboardKey> t_untouchedKeys = new List<KeyboardKey>(untouchedKeys);

        for (int i = 0; i < untouchedKeys.Count; ++i)
        {
            if (secretWord.Contains(untouchedKeys[i].GetLetter()))
            {
                t_untouchedKeys.Remove(untouchedKeys[i]);
            }
        }

        // At this point, we have a list of all the untouched keys, not contained into the secret word

        if (t_untouchedKeys.Count < 1)
        {
            return;
        }

        int randomKeyIndex = Random.Range(0, t_untouchedKeys.Count);
        t_untouchedKeys[randomKeyIndex].SetInvalid();
    }

    List<int> letterHintGivenIndices = new List<int>();
    public void LetterHint()
    {
        if (letterHintGivenIndices.Count >= 5)
        {
            return;
        }

        List<int> letterHintNotGivenIndices = new List<int>();

        for (int i = 0; i < 5; ++i)
        {
            if(!letterHintGivenIndices.Contains(i))
            {
                letterHintNotGivenIndices.Add(i);
            }
        }

        WordContainer currentWordContainer = InputManager.instance.GetCurrentWordContainer();

        string secretWord = WordManager.instance.GetSecretWord();
        int randomIndex = letterHintNotGivenIndices[Random.Range(0, letterHintGivenIndices.Count)];
        letterHintGivenIndices.Add(randomIndex);

        currentWordContainer.AddAsHint(randomIndex, secretWord[randomIndex]);
    }
}
