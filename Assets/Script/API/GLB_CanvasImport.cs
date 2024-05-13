using System.Collections;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using Siccity.GLTFUtility;

public class GLB_CanvasImport : MonoBehaviour
{
    public Canvas canvas_API;
    private bool check = false;
    public ShowOnlyTable showOnlyTable;

    void Update()
    {
        // Make the import run once only
        if (check)
        {
            return;
        }

        if (canvas_API.urlList.Count == 0)
        {
            return;
        }

        StartCoroutine(Start());

        check = true;

        // foreach (string str in canvas_API.urlList)
        // {
        //     canvas_API.textMeshPro.text = str;
        //     print(str);
        // }
    }

    IEnumerator Start()
    {
        foreach (string str in canvas_API.urlList)
        {
            UnityWebRequest www = UnityWebRequest.Get(str);
            yield return www.SendWebRequest();

            if (www.result != UnityWebRequest.Result.Success)
            {
                 canvas_API.textMeshPro.text = "Failed to download GLB file: " + www.error;
                yield break;
            }

            byte[] glbData = www.downloadHandler.data;
            print("LMAO " + System.Text.Encoding.UTF8.GetString(glbData));

            canvas_API.textMeshPro.text = System.Text.Encoding.UTF8.GetString(glbData);

            // Load the GLB data using GLTFUtility's LoadFromBytes method
            GameObject loadedObject = Importer.LoadFromBytes(glbData);

            canvas_API.textMeshPro.text = "DONE LOADING";

            // Move the parent GameObject's position by 3 units on the x-axis
            Vector3 newPosition = new Vector3(1, 1, 1);
            Vector3 combinedPosition = showOnlyTable.tableVector + newPosition;
            loadedObject.transform.position = combinedPosition;

            loadedObject.name = "PEPE";
        }

        GameObject sketchfabModel = GameObject.Find("PEPE");
        if (sketchfabModel != null)
        {
            // Sketchfab_model GameObject exists in the scene
            canvas_API.textMeshPro.text = "PEPE FOUND";
        } else {
            canvas_API.textMeshPro.text = "PEPE NOT FOUND";
        }
    }


}
