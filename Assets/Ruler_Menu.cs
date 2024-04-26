using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ruler_Menu : MonoBehaviour
{
    Toggle toggle;

    public GameObject rulerPrefb;

    private bool rulerInstantiated = false;

    // Start is called before the first frame update
    void Start()
    {
        toggle = this.GetComponent<Toggle>();        
    }

    // Update is called once per frame
    void Update()
    {
        if (!toggle.isOn || rulerInstantiated) 
        {
            return;
        }

        // Create prefab
        GameObject ruler = Instantiate(rulerPrefb);
        
        // Get the position of the main camera
        Vector3 cameraPosition = Camera.main.transform.position;;

        // Update the position of the ruler
        ruler.transform.position = new Vector3(cameraPosition.x, cameraPosition.y, cameraPosition.z - 0.5f);

        // Set the flag to indicate that the ruler has been instantiated
        rulerInstantiated = true;
        
        // Start a coroutine to delay setting toggle.isOn to false
        StartCoroutine(DelayToggleOff());
    }

    IEnumerator DelayToggleOff()
    {
        // Wait for 2 seconds
        yield return new WaitForSeconds(0.5f);

        // Set toggle.isOn to false after 2 seconds
        toggle.isOn = false;
        rulerInstantiated = false;
    }
}
