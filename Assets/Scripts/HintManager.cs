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
        Debug.Log("Keyboard Hint Activated");
    }

    public void LetterHint()
    {
        Debug.Log("Letter Hint Activated");
    }
}
