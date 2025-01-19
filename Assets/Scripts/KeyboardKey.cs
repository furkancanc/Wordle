using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class KeyboardKey : MonoBehaviour
{
    [Header(" Elements ")]
    [SerializeField] private TextMeshProUGUI letterText;

    [Header(" Events ")]
    public static Action<char> onKeyPressed;

    private void Start()
    {
        GetComponent<Button>().onClick.AddListener(SendKeyPressedEvent);
    }

    private void SendKeyPressedEvent()
    {
        onKeyPressed?.Invoke(letterText.text[0]);
    }
}
