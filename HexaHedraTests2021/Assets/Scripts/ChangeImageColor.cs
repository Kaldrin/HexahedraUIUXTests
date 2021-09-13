using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;






// Bastien BERNAND
// Reusable asset
// Last edited on 13.09.2021

/// <summary>
/// This script exposes functions to chan ge the color of images components. It must be placed on an object with an Image component.
/// </summary>

// Originally made for UNITY 2021.1.15f1
// Last tested on UNITY 2021.1.15f1
[RequireComponent(typeof(Image))]
public class ChangeImageColor : MonoBehaviour
{
    [SerializeField] Image image = null;
    [SerializeField] List<Color> colorsList = new List<Color>();





    public void ChangeColor(int colorIndex)                                                                                                         // CHANGE COLOR
    {
        GetMissingReferences();
        if (colorIndex >= 0 && colorsList.Count > 0 && colorIndex < colorsList.Count && colorsList[colorIndex] != null)
            image.color = colorsList[colorIndex];
    }




    // EDITOR
    void GetMissingReferences()                                                                                                                     // GET MISSING REFERENCES
    {
        if (!image && GetComponent<Image>())
            image = GetComponent<Image>();
    }

    private void OnDrawGizmosSelected()                                                                                                             // ON DRAW GIZMOS SELECTED
    {
        GetMissingReferences();
    }
}
