using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.UI;

// TODO
// THIS SCRIPT SHOULD BE PUT INSIDE THE BUTTON'S TEXT TOGGLE ITSELF

public class Pin_Menu : MonoBehaviour
{
    public GameObject pinToggle;

    private GameObject currGLB;

    // Cache the Toggle component reference
    Toggle toggle;

    void Start()
    {
        // Get the Toggle component from the annotateToggle GameObject
        toggle = pinToggle.GetComponent<Toggle>();
        // pinToggle.SetActive(false);
    }

    void Update()
    {
        if (currGLB == null) { return; }

        if (pinToggle.active)
        {
            if (toggle.isOn)
            {
                currGLB.GetComponent<Rigidbody>().isKinematic = true;
            } else 
            {
                currGLB.GetComponent<Rigidbody>().isKinematic = false;
            }
        }
    }

    public void OnHoverEntered(HoverEnterEventArgs args)
    {
        currGLB = args.interactableObject.transform.gameObject;
        // pinToggle.SetActive(true);

        if (!currGLB.GetComponent<Rigidbody>().isKinematic) 
        {
            toggle.isOn = false;
        } else
        {
            toggle.isOn = true;
        }


    }

    public void OnHoverExited(HoverExitEventArgs args)
    {
        // pinToggle.SetActive(false);
        currGLB = null;
    }
 
}
