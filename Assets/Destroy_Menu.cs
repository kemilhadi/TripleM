using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.UI;

public class Destroy_Menu : MonoBehaviour
{
    Toggle toggle;

    private GameObject currObj;


    // Start is called before the first frame update
    void Start()
    {
        toggle = this.GetComponent<Toggle>();    
        gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (toggle.isOn) 
        {            
            // Destroy the ruler instance
            Destroy(currObj);
            
        }
    }

    public void OnHoverEntered(HoverEnterEventArgs args)
    {
        if (int.TryParse(args.interactableObject.transform.name, out _))
        {
            return;
        }
        
        currObj = args.interactableObject.transform.parent.gameObject;;
        gameObject.SetActive(true);
    }

    public void OnHoverExited(HoverExitEventArgs args)
    {
        if (int.TryParse(args.interactableObject.transform.name, out _))
        {
            return;
        }

        toggle.isOn = false;
        gameObject.SetActive(false);
    }

}
