using UnityEngine;
using System.Collections;

using UnityEngine.UI;





// Bastien BERNAND
// Reusable asset

/// <summary>
/// This script allows to serialize the alpha hit test treshold property of UI images so that raycast events are not called on invisible pixels
/// </summary>

// Originally made for UNITY 2021.1.15f1
// Last tested on UNITY 2021.1.15f1
public class ButtonAlphaHitTest : MonoBehaviour
{
    [SerializeField] Image imageToModifyTresholOf;
    [SerializeField] float alphaHitTestMinimumTreshold = 0.95f;





    void Start()                                                                                    // START
    {
        GetMissingReferences();
        SetAlphaHitTreshold(alphaHitTestMinimumTreshold);
    }

    private void OnEnable()                                                                         // ON ENABLE
    {
        GetMissingReferences();
        SetAlphaHitTreshold(alphaHitTestMinimumTreshold);
    }


    public void SetAlphaHitTreshold(float value)                                                     // SET ALPHA HIT TRESHOLD
    {
        if (imageToModifyTresholOf && value >= 0 && value <= 1)
            imageToModifyTresholOf.alphaHitTestMinimumThreshold = value;
    }




    // EDITOR
    void GetMissingReferences()                                                                        // GET MISSING REFERENCES
    {
        if (!imageToModifyTresholOf && GetComponent<Image>())
            imageToModifyTresholOf = GetComponent<Image>();

        if (alphaHitTestMinimumTreshold < 0)
            alphaHitTestMinimumTreshold = 0;
        if (alphaHitTestMinimumTreshold > 1)
            alphaHitTestMinimumTreshold = 1;
    }

    private void OnDrawGizmosSelected()                                                                 // ON DRAW GIZMOS SELECTED
    {
        GetMissingReferences();
    }
}