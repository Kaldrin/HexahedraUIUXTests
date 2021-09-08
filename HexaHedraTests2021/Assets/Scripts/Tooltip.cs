using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using TMPro;






// Bastien BERNAND
// Hexahedra UI / UX tests
// Last edited on 08.09.2021

// REQUIREMENTS
// TextMeshPro package

/// <summary>
/// This script is for managing the tooltip for the game. To be placed ON the tooltip object
/// </summary>

// Originally made for UNITY 2021.1.15f1
// Last tested on UNITY 2021.1.15f1
public class Tooltip : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI tooltipTitle = null;
    [SerializeField] TextMeshProUGUI tooltipText = null;
    [SerializeField] TextMeshProUGUI tooltipKey = null;
    [SerializeField] RectTransform selfRectTransform = null;


    private void Start()                                                                                                                                                // START
    {
        GetMissingReferences();
        gameObject.SetActive(false);
    }

    private void Update()                                                                                                                                               // UPDATE
    {
        if (enabled && isActiveAndEnabled)
            transform.position = Input.mousePosition + new Vector3(selfRectTransform.sizeDelta.x / 2, selfRectTransform.sizeDelta.y / 2, 0);
    }

    private void OnEnable()                                                                                                                                     // ON ENABLE
    {
        transform.position = Input.mousePosition + new Vector3(selfRectTransform.sizeDelta.x / 2, selfRectTransform.sizeDelta.y / 2, 0); ;
    }

    public void CallTooltip(bool state, string title = "Tooltip title", string text = "Tooltip text", string key = "K")                                             // CALL TOOLTIP
    {
        if (tooltipTitle && tooltipTitle.text != title)
            tooltipTitle.text = title;
        if (tooltipText && tooltipText.text != text)
            tooltipText.text = text;
        if (tooltipKey && tooltipKey.text != key[0].ToString())
            tooltipKey.text = key[0].ToString();

        gameObject.SetActive(state);
    }






    // EDITOR
    void GetMissingReferences()                                                                                                                                 // GET MISSING REFERENCES
    {
        if (!selfRectTransform && GetComponent<RectTransform>())
            selfRectTransform = GetComponent<RectTransform>();
    }

    private void OnDrawGizmosSelected()                                                                                                                                 // ON DRAW GIEMOS SELECTED
    {
        GetMissingReferences();
    }

    private void OnDrawGizmos()                                                                                                                                    // ON DRAW GIZMOS
    {
        if (gameObject.name != "Tooltip")
            gameObject.name = "Tooltip";
    }
}
