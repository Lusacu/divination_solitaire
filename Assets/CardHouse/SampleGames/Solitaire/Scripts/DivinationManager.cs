using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using System.IO;
using TMPro;
using System.Collections;
using UnityEngine.Networking;
using System.Text;
using System;

public class DivinationManager : MonoBehaviour
{
    public static string[] divinations;
    public static bool divinationsReady = false;
    public TMP_InputField textInput;
    public string relativeCsvFilePath = "divinations.csv";

    void Start()
    {
        string csvFileName = Path.Combine(Application.streamingAssetsPath, relativeCsvFilePath);
        if (!divinationsReady) { 
            if (Application.platform == RuntimePlatform.WebGLPlayer)
            {
                StartCoroutine(GetText());
            }
            else
            {
                LoadDivinations(csvFileName);
            }
        } 
        else
        {
            string[] lines = divinations;
            string randomLine = lines[UnityEngine.Random.Range(0, lines.Length)];
            textInput.text = randomLine;
        }
    }
    

    IEnumerator GetText()
    {
        UnityWebRequest www = UnityWebRequest.Get("https://www.my-server.com");
        yield return www.SendWebRequest();

        if (www.result != UnityWebRequest.Result.Success)
        {
            //Debug.Log(www.error);
        }
        else
        {
            // Or retrieve results as binary data
            byte[] results = www.downloadHandler.data;
            divinations = stringify(results);
            string[] lines = divinations;
            string randomLine = lines[UnityEngine.Random.Range(0, lines.Length)];
            textInput.text = randomLine;
            divinationsReady = true;
        }
    }
    string[] stringify(byte[] byteArray)
    {
        return Encoding.UTF8.GetString(byteArray).Split(new[] { '\0' }, StringSplitOptions.RemoveEmptyEntries);
    }



    void LoadDivinations(string csvFilePath)
    {
        if (!File.Exists(csvFilePath))
        {
            Debug.LogError("CSV file not found: " + csvFilePath);
            return;
        }

        string[] lines = divinations;
        if (!divinationsReady) { 
            // Read all lines from the CSV file
            lines = File.ReadAllLines(csvFilePath);
            divinations = lines;
        } 
        
        // Choose a random line
        string randomLine = lines[UnityEngine.Random.Range(0, lines.Length)];

        // Assign the random divination to the UI text input
        textInput.text = randomLine;
        divinationsReady = true;
        // Debug.Log("Input divination: " + textInput.text);
    }

    // Метод для кнопки, который повторно загружает гадания
    public void ReloadDivinations()
    {
        string csvFileName = Path.Combine(Application.streamingAssetsPath, relativeCsvFilePath);
        LoadDivinations(csvFileName);
    }
}