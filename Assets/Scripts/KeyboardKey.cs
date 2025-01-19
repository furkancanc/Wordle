using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class KeyboardKey : MonoBehaviour
{
    [Header(" Elements ")]
    [SerializeField] private TextMeshProUGUI letterText;

    private void Start()
    {
        GetComponent<Button>().onClick.AddListener(Test);
    }

    private void Test()
    {
        Debug.Log(letterText.text);
    }
}
