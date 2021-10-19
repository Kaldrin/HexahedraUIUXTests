using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using TMPro;







// Bastien BERNAND
// Reusable asset
// Last edited 19.10.2021

// REQUIREMENTS
// TextMeshPro package

/// <summary>
/// This script provides public functions to change the color of a TMPUGUI component's text from buttons & stuff.
/// </summary>

// Originally made for UNITY 2020.1.15f1
// Last tested on UNITY 2021.1.15f1
[RequireComponent(typeof(TextMeshProUGUI))]
public class ChangeTMPUGUIColorR : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI TMPUGUIComponentToChangeColorOf = null;
    [SerializeField] Color colorToUseForCustomFunction = Color.white;
    [SerializeField] List<Color> colorsToUse = new List<Color>();



    /// <summary>
    /// Changes the color of the referenced TMPUGUI component <see cref="TMPUGUIComponentToChangeColorOf"/> with the parameter color.
    /// </summary>
    /// <param name="newColor">The new color of the text</param>
    public void ChangeColor(Color newColor)
    {
        GetMissingReferences();
        if (TMPUGUIComponentToChangeColorOf)
            TMPUGUIComponentToChangeColorOf.color = newColor;
    }
    /// <summary>
    /// Changes the color of the referenced TMPUGUI component <see cref="TMPUGUIComponentToChangeColorOf"/> with a color from the colors list <see cref="colorsToUse"/> corresponding to the parameter index.
    /// </summary>
    /// <param name="colorIndex">Index of the color to use in the <see cref="colorsToUse"/></param>
    public void ChangeColorWithIndex(int colorIndex)
    {
        GetMissingReferences();
        if (TMPUGUIComponentToChangeColorOf)
            TMPUGUIComponentToChangeColorOf.color = colorsToUse[colorIndex];
    }
    /// <summary>
    /// Changes the color of the parameter TMPUGUI component with the custom referenced color <see cref="colorToUseForCustomFunction"/>
    /// </summary>
    /// <param name="customTMPUGUIComponentToChangeColorOf">Text component to change color of</param>
    public void ChangeCustomTMPUGUIComponentColor(TextMeshProUGUI customTMPUGUIComponentToChangeColorOf)
    {
        if (customTMPUGUIComponentToChangeColorOf)
            customTMPUGUIComponentToChangeColorOf.color = colorToUseForCustomFunction;
    }



    // EDITOR
    /// <summary>
    /// Automatically gets missing references if possible.
    /// </summary>
    void GetMissingReferences() 
    {
        if (!TMPUGUIComponentToChangeColorOf && GetComponent<TextMeshProUGUI>())
            TMPUGUIComponentToChangeColorOf = GetComponent<TextMeshProUGUI>();
    }
    private void OnValidate() => GetMissingReferences();
}
