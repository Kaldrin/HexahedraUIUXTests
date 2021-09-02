using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;
#if UNITY_EDITOR
    using UnityEditor;
    using UnityEditor.Experimental.SceneManagement;
#endif






// Bastien BERNAND
// Reusable asset
// Last edited on 31.08.2021

/// <summary>
/// This script allows to automatically modify the Z rotation of a UI object depending on an image's fill amount
/// </summary>

// Originally made for UNITY 2021.1.15f1
// Last tested on UNITY 2021.1.15f1
public class RotateObjectByImageFillAmount : MonoBehaviour
{
    [SerializeField] Transform objectToRotate = null;
    [SerializeField] Image imageToCheck = null;
    [SerializeField] float multiplier = 180;
    [SerializeField] float adder = 180;
    [SerializeField] bool notInPlayMode = false;






    private void Start()                                                                                                    // START
    {
        GetMissingReferences();
        Rotate();
    }

    private void OnEnable()                                                                                                   // ON ENABLE
    {
        GetMissingReferences();
        Rotate();
    }

    void Rotate()                                                                                                           // ROTATE   
    {
        if (imageToCheck && objectToRotate && imageToCheck.type == Image.Type.Filled)
        {
            Vector3 newRotation = new Vector3(objectToRotate.localEulerAngles.x, objectToRotate.localEulerAngles.y, adder + imageToCheck.fillAmount * multiplier);
            objectToRotate.localEulerAngles = newRotation;
        }
    }

    private void Update()                                                                                                       // UPDATE
    {
        if (!notInPlayMode)
            Rotate();
    }





    // EDITOR
    void GetMissingReferences()                                                                                     // GET MISSING REFERENCES
    {
        if (!objectToRotate)
            objectToRotate = GetComponent<Transform>();
        if (!imageToCheck && GetComponent<Image>())
            imageToCheck = GetComponent<Image>();
    }


    private void OnDrawGizmos()                                                                                 // ON DRAW GIZMOS
    {
        if (enabled)
        {
            if (notInPlayMode && Application.isPlaying)
            {

            }
            else
            {
                GetMissingReferences();
                Rotate();

                #if UNITY_EDITOR
                    HandleUtility.Repaint();
                #endif
            }
        }
    }
}
