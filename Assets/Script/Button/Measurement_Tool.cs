using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


using TMPro;

public class Measurement_Tool : MonoBehaviour
{
    public TextMeshProUGUI textMeshPro;

    public LineRenderer lineRenderer;
    public GameObject startPoint;
    public GameObject endPoint;

    float distanceinCM = 0f;
    Camera mainCamera;

    // Start is called before the first frame update
    void Start()
    {
        mainCamera = Camera.main;

        lineRenderer.positionCount = 2;
    }

    // Update is called once per frame
    void Update()
    {
        // Update Line Renderer
        lineRenderer.SetPosition(0, startPoint.transform.position);
        lineRenderer.SetPosition(1, endPoint.transform.position);

        // Calculate the distance in CM
        distanceinCM = Vector3.Distance(startPoint.transform.position, endPoint.transform.position) * 100f;

        // Calculate midpoint between A and B
        Vector3 midpoint = endPoint.transform.position + (startPoint.transform.position - endPoint.transform.position) / 2f;
        midpoint += new Vector3(0.2f, -0.2f, 0f);
        // textMeshPro.text = $"{midpoint}"; 


        // // Convert world position to screen coordinates
        // Vector3 screenPos = mainCamera.WorldToScreenPoint(midpoint);

        // Update position of measurement cm ui
        textMeshPro.rectTransform.position = midpoint;

        textMeshPro.text = $"{distanceinCM}cm"; 

    }
}
