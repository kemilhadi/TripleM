using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using SimpleJSON; 
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using TMPro;
using UnityEngine.XR.Interaction.Toolkit;

// TODO
// CLEAN UP NESTED CODES

public class Canvas : MonoBehaviour
{

    // URL of the API
    // GET NEW ACCESS TOKEN
    private string apiUrl = "https://rmit.instructure.com/api/v1/courses/70814/files?access_token=9595~6ZKrkZZAhgtFjJwIh8lktvMf4Wkm12uHJrjszXUDM8EXXhI1baCECHprFHSNEJGA"; 

    // Declare a list of strings
    public List<string> displayNameList = new List<string>();
    public List<string> urlList = new List<string>();

    private bool isFinished = true;

    // Reference to the TextMeshPro component
    public TextMeshProUGUI textMeshPro;
   

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(GetDataFromAPI());

        // Set initial text
        textMeshPro.text = "Starting to generate UID";
        // print("Starting to generate UID");
    }

    IEnumerator GetDataFromAPI()
    {
        // Create a UnityWebRequest object
        using (UnityWebRequest webRequest = UnityWebRequest.Get(apiUrl))
        {
            // Send the request and wait for a response
            yield return webRequest.SendWebRequest();

            // Check for errors
            if (webRequest.result != UnityWebRequest.Result.Success)
            {
                Debug.LogError("Error: " + webRequest.error);
            }
            else
            {
                // Parse the JSON response
                string jsonResponse = webRequest.downloadHandler.text;

                // Filter JSON
                generateList(jsonResponse);
            }
        }

        isFinished = false;
    }

    private void generateList(string jsonString)
    {
        // Parse JSON data
        var jsonNode = JSON.Parse(jsonString);

        // Check if JSON data is an array
        if (jsonNode.IsArray)
        {
            // Iterate over each item in the array
            foreach (JSONNode item in jsonNode.AsArray)
            {
                // Get display name and URL from each item
                string displayName = item["display_name"];
                string url = item["url"];

                if (displayName.EndsWith(".glb", System.StringComparison.OrdinalIgnoreCase))
                {
                    // Add display name and URL to respective lists
                    displayNameList.Add(displayName);
                    urlList.Add(url);
                }

            }
        }
    }

}
