using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextUpdater : MonoBehaviour
{
    public TMP_InputField inputField;
    public TextMeshProUGUI textMeshPro;

    public void UpdateText()
    {
        textMeshPro.text = inputField.text;
        string inputValue = inputField.text;
        Debug.Log("Input Field Value: " + inputValue);
    }
}
