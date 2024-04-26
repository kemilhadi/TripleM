using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using SimpleJSON; 
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using TMPro;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Transformers;

// TODO
// CLEAN UP NESTED CODES

public class WebAPI : MonoBehaviour
{
    public string APIToken;
    public string ModelUIDToDownload;

    // URL of the API
    private string apiUrl = "https://api.sketchfab.com/v3/collections/44e295f367b54084a83366d3da68e68c/models"; 
    // fab7532b13a541e4958246de7f0a520f
    // 44e295f367b54084a83366d3da68e68c

    // Declare a list of strings
    private List<string> UIDList = new List<string>();
    public List<string> DescriptionList = new List<string>();

    private bool isFinished = true;

    // Placeholder to spread out the items on the table by xPos temporarily
    private int xPos = 0;

    public ShowOnlyTable showOnlyTable;

    // Reference to the TextMeshPro component
    public TextMeshProUGUI textMeshPro;

    void Start()
    {
        // Authorize with the provided API token
        SketchfabAPI.AuthorizeWithAPIToken(APIToken);        

        StartCoroutine(GetDataFromAPI());

    }

    void Update()
    {
        // If sketchfab API is not yet finished then it will not start to download the models
        if (!isFinished)
        {
            if (showOnlyTable.tableVector == Vector3.zero)
            {
                return;
            }

            for (int i = 0; i < UIDList.Count; i++)
            {
                DownloadModel(UIDList[i], i);
            }

            isFinished = true;
        }
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
                // textMeshPro.text = jsonResponse;

                generateList(jsonResponse);
            }
        }

        isFinished = false;
    }

    private void generateList(string jsonString)
    {
        // Parse JSON data
        var jsonNode = JSON.Parse(jsonString);

        // Check if JSON data contains "results" array
        if (jsonNode["results"] != null && jsonNode["results"].IsArray)
        {
            // Iterate over each item in the "results" array
            foreach (JSONNode result in jsonNode["results"].AsArray)
            {
                // Check if the item contains "uid" field
                if (result["uid"] != null)
                {
                    // Add UID to the filtered list
                    UIDList.Add(result["uid"]);

                    // Add description to the description list
                    DescriptionList.Add(result["description"]);
                }

            }
        }

    }

    private void DownloadModel(string UID, int numTrack) 
    {
        // This first call will get the model information
        // bool enableCache = true;
        SketchfabAPI.GetModel(UID, (resp) =>
        {

            // This second call will get the model information, download it and instantiate it
            SketchfabModelImporter.Import(resp.Object, (obj) =>
            {

                if(obj != null)
                {
                    Transform parent = obj.gameObject.transform;

                    // Access RootNode
                    Transform rootNode = parent.GetChild(0).GetChild(0).GetChild(0);

                    // Update Name
                    rootNode.name = numTrack.ToString();

                    // Rendering Variables
                    var renderers = rootNode.GetComponentsInChildren<Renderer>();
                    var bound = renderers[0].bounds;    // Initialize bounds

                    // Scale the max value
                    float maxValue = 0.5f / Mathf.Max(bound.size.y, Mathf.Max(bound.size.x, bound.size.z));

                    // Accumulate and Access all parts
                    for (int i = 0; i < rootNode.childCount; i++)
                    {
                        // Access Parts
                        Transform parts = rootNode.GetChild(i).GetChild(0);

                        // Accumulate the part sizes
                        if(renderers != null)
                        {
                            // Get the bounds of the GameObject's mesh
                            bound.Encapsulate(renderers[i].bounds);

                        } else 
                        {
                            print(parts.name + " is null");
                        }

                        // Add Mesh Collider to the parts
                        MeshCollider meshCollider = parts.gameObject.AddComponent<MeshCollider>();

                        // Enable convex for the Mesh Collider
                        meshCollider.convex = true;
                    }

                    createComponents(rootNode, bound);

                        // SIZE AND POSITION ADJUSTMENT

                    // Approximate Real Values or could just swap all with 0.5f
                    Vector3 scale = new Vector3(maxValue, maxValue, maxValue);
                    rootNode.localScale = scale;

                    // Move the parent GameObject's position by 3 units on the x-axis
                    Vector3 newPosition = parent.position + new Vector3(0f, 0f, xPos);
                    
                    // Enable
                    Vector3 combinedPosition = showOnlyTable.tableVector + newPosition;

                    // Change to combinedPosition
                    parent.position = combinedPosition;
                    xPos -= 1;

        //         }
        //     }, enableCache);
        // }, enableCache);
                }
            });
        });

    }

    private void createComponents(Transform rootNode, Bounds bound)
    {
        // Add Rigidbody to RootNode
        Rigidbody rb = rootNode.gameObject.AddComponent<Rigidbody>();

        // XR Grab
        XRGrabInteractable grabObj = rootNode.gameObject.AddComponent<XRGrabInteractable>();          
        grabObj.useDynamicAttach = true;
        grabObj.selectMode = InteractableSelectMode.Multiple;;

        // XR Transform
        XRGeneralGrabTransformer transformObj = rootNode.gameObject.AddComponent<XRGeneralGrabTransformer>();          
        transformObj.allowTwoHandedScaling = true;
        transformObj.thresholdMoveRatioForScale = 0.01f;
        transformObj.maximumScaleRatio = 3;
    }

}