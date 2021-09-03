using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using TMPro;



// Bastien BERNAND
// Reusable asset

// REQUIREMENTS
// TextMeshPro package

/// <summary>
/// This script allows to change the text of a UI TMP component to the child index of a chosen object automatically
/// </summary>

// Originally made for UNITY 2021.1.15f1
// Last tested on UNITY 2021.1.15f1
public class TMPSetChildIndexToText : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI tmpComponentToUpdate = null;
    [SerializeField] Transform transformToCheckForChildIndex = null;
    [SerializeField] int startCountingAt = 0;






    // EDITOR
    void GetMissingReferences()                                                                                                          // GET MISSING REFERENCES
    {
        if (!tmpComponentToUpdate && GetComponent<TextMeshProUGUI>())
            tmpComponentToUpdate = GetComponent<TextMeshProUGUI>();
        if (!transformToCheckForChildIndex && GetComponent<Transform>())
            transformToCheckForChildIndex = GetComponent<Transform>();
    }

    private void OnDrawGizmosSelected()                                                                                                 // ON DRAW GIZMOS SELECTED
    {
        GetMissingReferences();
    }

    private void OnDrawGizmos()                                                                                                         // ON DRAW GIZMOS
    {
        if (tmpComponentToUpdate && transformToCheckForChildIndex)
            if (tmpComponentToUpdate.text != (transformToCheckForChildIndex.GetSiblingIndex() + startCountingAt).ToString())
                tmpComponentToUpdate.text = (transformToCheckForChildIndex.GetSiblingIndex() + startCountingAt).ToString();
    }
}
