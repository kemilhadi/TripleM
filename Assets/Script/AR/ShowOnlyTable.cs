using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class ShowOnlyTable : MonoBehaviour
{
    public ARPlaneManager planeManager;
    public PlaneClassification classification;
    public GameObject prefabObj;

    // Vector3 variable
    public Vector3 tableVector = Vector3.zero;

    private void OnEnable()
    {
        planeManager.planesChanged += SetupPlane;
    }

    private void OnDisable()
    {
        planeManager.planesChanged -= SetupPlane;
    }

    private void SetupPlane(ARPlanesChangedEventArgs obj)
    {
        List <ARPlane> newPlane = obj.added;

        foreach (var item in newPlane)
        {
            Renderer itemRend = item.GetComponent<Renderer>();

            if (item.classification != classification) 
            {
                Destroy(itemRend);
            } else {
                Vector3 planePos = itemRend.transform.position;
                float rendererSizeY = GetRendererSizeY(itemRend);

                // Calculate the position for the new object based on the size of the renderer
                Vector3 positionB = planePos + Vector3.up * rendererSizeY * 0.5f;

                tableVector = positionB;
                // GameObject newObject = Instantiate(prefabObj, positionB, Quaternion.identity);
            }
        }
    }

    // Helper function to get the size.y of a Renderer's bounds
    float GetRendererSizeY(Renderer renderer)
    {
        Bounds bounds = renderer.bounds;
        return bounds.size.y;
    }

}
