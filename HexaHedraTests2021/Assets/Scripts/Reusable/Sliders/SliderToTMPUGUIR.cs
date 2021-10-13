using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;
using TMPro;




// Bastien BERNAND
// Reusable asset
// Last edited 13.10.2021

// REQUIREMENTS
// TextMeshPro package

/// <summary>
/// Allows to write a slider's volume to a TMPUGUI component
/// </summary>

// Originally made for UNITY 2020.1.15f1
// Last tested on UNITY 2020.1.15f1
public class SliderToTMPUGUIR : MonoBehaviour
{
    [SerializeField] Slider sliderToCheck = null;
    [SerializeField] TextMeshProUGUI TMPUGUIToWrite = null;




    private void OnEnable() => GetMissingReferences();
    private void FixedUpdate()                                                                                                                  // FIXED UPDATE
    {
        if (enabled && isActiveAndEnabled)
            Apply();
    }
    void Apply()                                                                                                                            // APPLY
    {
        if (sliderToCheck && TMPUGUIToWrite && Mathf.FloorToInt(sliderToCheck.value).ToString() != TMPUGUIToWrite.text)
            TMPUGUIToWrite.text = Mathf.FloorToInt(sliderToCheck.value).ToString();
    }


    // EDITOR
    void GetMissingReferences()                                                                                                                 // GET  MISSING REFERENCES
    {
        if (!sliderToCheck && GetComponent<Slider>())
            sliderToCheck = GetComponent<Slider>();
        if (!TMPUGUIToWrite && GetComponent<TextMeshProUGUI>())
            TMPUGUIToWrite = GetComponent<TextMeshProUGUI>();
    }
    private void OnValidate() => GetMissingReferences();
    private void OnDrawGizmos()                                                                                                                // ON DRAW GIZMOS
    {
        if (enabled && isActiveAndEnabled)
            Apply();
    }
}
