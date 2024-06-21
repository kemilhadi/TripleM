using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq; // Required for LINQ methods

public class Spawn_Menu : MonoBehaviour
{
    public ToggleGroup toggleGroup; // Reference to the ToggleGroup component

    // The gameobject that is bound to this script
    Toggle toggle;

    private bool checker;
    public WebAPI webAPI;

    void Start()
    {
        toggle = this.GetComponent<Toggle>();    
        checker = true;    
    }

    void Update()
    {

        if (toggle.isOn & checker) {
            // Get the active toggle in the group
            Toggle activeToggle = GetActiveToggle(toggleGroup);

            // Make sure that if statement only run once (will run only after startCoroutine is finished)
            checker = false;

            if (activeToggle != null)
            {
                print("Active Toggle: " + activeToggle.name);
                webAPI.DownloadModel(activeToggle.name);
            }
            else
            {
                print("No Toggle is currently active.");
            }

            StartCoroutine(DelayToggleOff());
        }

    }

    // Function to get the active toggle in the group
    Toggle GetActiveToggle(ToggleGroup toggleGroup)
    {
        // Use LINQ to find the first active toggle in the group
        return toggleGroup.ActiveToggles().FirstOrDefault();
    }

    IEnumerator DelayToggleOff()
    {
        // Wait for 0.5f seconds
        yield return new WaitForSeconds(0.5f);

        // Set toggle.isOn to false after 0.5f seconds
        toggle.isOn = false;
        checker = true;
    }
}
