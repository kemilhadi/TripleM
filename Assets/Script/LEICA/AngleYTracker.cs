using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AngleYTracker : MonoBehaviour
{
    private float totalRotation = 0;

    public int nrOfRotations {
        get {
            return ((int) totalRotation)/360;  
        }  
    }
   
    private Vector3 lastPoint;
   
    // Use this for initialization
    void Start () {
        lastPoint = transform.TransformDirection(Vector3.forward);
        lastPoint.y = 0;
    }
   
    // Update is called once per frame
    void Update () {
        Vector3 facing = transform.TransformDirection(Vector3.forward);
        facing.y = 0;
       
        float angle = Vector3.Angle(lastPoint, facing);
        if (Vector3.Cross(lastPoint, facing).y < 0)
            angle *= -1;
           
        totalRotation += angle;
        lastPoint = facing;

        print("Y: " + totalRotation);
    }
}
