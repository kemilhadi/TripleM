using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

using UnityEngine.UI;
using TMPro;

public class RotationalConvertion : MonoBehaviour
{
    public TextMeshProUGUI textMeshPro;
    private bool isSelecting = false;
    public XRBaseInteractor interactor;




    public void OnSelectEntered(SelectEnterEventArgs args)
    {
        textMeshPro.text = "Point Started at: " + args.interactor.attachTransform.position;
        
    }

    public void OnSelectExited(SelectExitEventArgs args)
    {
        // Do something when pinch action ends
        textMeshPro.text = "Point ended at: " + args.interactor.attachTransform.position;
    }

}
