using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LetterContainer : MonoBehaviour
{
    [Header(" Elemenets ")]
    [SerializeField] private TextMeshPro letter;

    public void Initialize()
    {
        letter.text = "";
    }

    public void SetLetter(char letter)
    {
        this.letter.text = letter.ToString();
    }

    public char GetLetter()
    {
        return letter.text[0];
    }
}
