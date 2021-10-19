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
/// This script allows to copy the fill amount of a UI image to another UI image/ Requires Gizmos enabled to work
/// </summary>

// Originally made for UNITY 2021.1.15f1
// Last tested on UNITY 2021.1.15f1
public class CopyFillAmount : MonoBehaviour
{
    [SerializeField] Image imageToCopyFillAmountFrom = null;
    [SerializeField] Image imageToSetFillAmountOf = null;





    private void Start()                                                                                                                // START
    {
        GetMissingReferences();
        DoCopyFillAmount();
    }


    private void OnEnable()                                                                                                             // ON ENABLE
    {
        GetMissingReferences();
        DoCopyFillAmount();
    }

    void DoCopyFillAmount()                                                                                                                 // DO COPY FILL AMOUNT
    {
        if (imageToCopyFillAmountFrom && imageToCopyFillAmountFrom.type == Image.Type.Filled && imageToSetFillAmountOf && imageToSetFillAmountOf.type == Image.Type.Filled)
            if (imageToCopyFillAmountFrom.fillAmount != imageToSetFillAmountOf.fillAmount)
                imageToSetFillAmountOf.fillAmount = imageToCopyFillAmountFrom.fillAmount;
    }

    private void Update()                                                                                                                       // UPDATE
    {
        DoCopyFillAmount();
    }





    // EDITOR
    void GetMissingReferences()                                                                                                             // GET MISSING REFERENCES
    {
        if (!imageToSetFillAmountOf && GetComponent<Image>())
            imageToSetFillAmountOf = GetComponent<Image>();
    }

    private void OnDrawGizmos()                                                                                                             // ON DRAW GIZMOS
    {
        GetMissingReferences();
        DoCopyFillAmount();

        #if UNITY_EDITOR
            HandleUtility.Repaint();
        #endif
    }
}
