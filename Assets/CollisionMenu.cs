using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.XR.Interaction.Toolkit;
using TMPro;
using UnityEngine.UI;

// TODO
// THIS SCRIPT SHOULD BE PUT INSIDE THE BUTTON'S TEXT TOGGLE ITSELF

public class CollisionMenu : MonoBehaviour
{
    // Reference to the TextMeshPro component
    public TextMeshProUGUI textMeshPro;

    public GameObject DescriptionUI;

    public WebAPI webAPI;

    public GameObject annotateToggle;

    // Cache the Toggle component reference
    Toggle toggle;

    void Start()
    {
        // Get the Toggle component from the annotateToggle GameObject
        toggle = annotateToggle.GetComponent<Toggle>();
        annotateToggle.SetActive(false);
    }

    public void OnHoverEntered(HoverEnterEventArgs args)
    {
        textMeshPro.text = $"{webAPI.DescriptionList[int.Parse(args.interactableObject.transform.name)]}";
        annotateToggle.SetActive(true);
    }

    public void OnHoverExited(HoverExitEventArgs args)
    {
        annotateToggle.SetActive(false);
    }

    void Update()
    {
        if (!toggle.isOn) {
            DescriptionUI.SetActive(false);
        } else 
        {
            DescriptionUI.SetActive(true);
        }
    }
 
}
