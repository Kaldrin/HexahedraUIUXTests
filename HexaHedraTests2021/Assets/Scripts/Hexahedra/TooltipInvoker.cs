using System.Collections;
using System.Collections.Generic;
using UnityEngine;




// Bastien BERNAND
// Hexahedra UI / UX tests
// Last edited on 08.09.2021

// REQUIREMENTS
// Tooltip script (Single instance)

/// <summary>
/// This script allows to expose functions and objects of the tooltip to manipulate and enable it with different buttons & co.
/// </summary>

// Originally made for UNITY 2021.1.15f1
// Last tested on UNITY 2021.1.15f1
public class TooltipInvoker : MonoBehaviour
{
    [SerializeField] Tooltip tooltipObject = null;
    [SerializeField] string tooltipTitle = "Tooltip title";
    [SerializeField] string tooltipText = "Tooltip text";
    [SerializeField] string tooltipKey = "K";


    public void CallToolTip(bool state)                                                                                                     // CALL TOOLTIP
    {
        GetMissingReferences();
        if (tooltipObject)
            tooltipObject.CallTooltip(state, tooltipTitle, tooltipText, tooltipKey);
    }



    void GetMissingReferences()                                                                                                                 // GET MISSING REFERENCES
    {
        if (!tooltipObject && GameObject.FindObjectOfType<Tooltip>())
            tooltipObject = GameObject.FindObjectOfType<Tooltip>();
        if (!tooltipObject && GameObject.Find("Tooltip").GetComponent<Tooltip>())
            tooltipObject = GameObject.Find("Tooltip").GetComponent<Tooltip>();
    }

    private void OnDrawGizmosSelected()                                                                                                     // ON DRAW GIZMOS SELECTED
    {
        GetMissingReferences();
    }
}
