using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastDistanceMeasure : MonoBehaviour
{

    float distanceinCM = 0f;


    // Update is called once per frame
    void Update()
    {

        if ( Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out RaycastHit hitinfo, 20f) ) 
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hitinfo.distance, Color.red);

            distanceinCM = Vector3.Distance(transform.position, transform.TransformDirection(Vector3.forward) * hitinfo.distance) * 100f;
            Debug.Log(distanceinCM);

        } else 
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 20f, Color.blue);
        }

    }
}
