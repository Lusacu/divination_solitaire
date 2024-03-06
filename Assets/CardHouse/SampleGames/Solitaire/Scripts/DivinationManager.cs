using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using System.IO;
using TMPro;

public class DivinationManager : MonoBehaviour
{
    public TMP_InputField textInput;
    public string relativeCsvFilePath = "divinations.csv";

    void Start()
    {
        string csvFileName = Path.Combine(Application.streamingAssetsPath, relativeCsvFilePath);
        LoadDivinations(csvFileName);
    }

    void LoadDivinations(string csvFilePath)
    {
        if (!File.Exists(csvFilePath))
        {
            Debug.LogError("CSV file not found: " + csvFilePath);
            return;
        }

        // Read all lines from the CSV file
        string[] lines = File.ReadAllLines(csvFilePath);

        // Choose a random line
        string randomLine = lines[Random.Range(0, lines.Length)];

        // Assign the random divination to the UI text input
        textInput.text = randomLine;
    }
}