using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.IO;

public class pathTester : MonoBehaviour
{
		
    public TextMeshProUGUI textMeshToCopyTo;
	
    public void click()
	{
		string csvFileName = Path.Combine(Application.streamingAssetsPath, "divin.csv");
        textMeshToCopyTo.text = csvFileName;
    }
}
