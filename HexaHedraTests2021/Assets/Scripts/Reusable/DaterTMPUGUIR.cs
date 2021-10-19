using UnityEngine;

using TMPro;




// Bastien BERNAND
// Reusable asset
// Last edited 19.10.2021

// REQUIREMENTS
// TextMeshPro package

/// <summary>
/// This script allows to apply the current date to TMPUGUI components with public functions.
/// </summary>

// Originally made for UNITY 2020.1.15f1
// Last tested on UNITY 2020.1.15f1
public class DaterTMPUGUIR : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI TMPUGUIComponentToTarget = null;
    [SerializeField] DateFormat defaultDateFormat = DateFormat.ddmmyyyy;
    public enum  DateFormat
    {
        ddmmyyyy,
        mmddyyyy
    }



    public void ApplyDate()                                                                                                 // APPLY DATE
    {
        if (TMPUGUIComponentToTarget)
            TMPUGUIComponentToTarget.text = CallDateSimple();
    }
    public void ApplyDateToCustomTMPUGUI(TextMeshProUGUI customTMPUGUI)                                                     // APPLY DATE TO CUSTOM MPUGUI
    {
        if (!customTMPUGUI && GetComponent<TextMeshProUGUI>())
            customTMPUGUI = GetComponent<TextMeshProUGUI>();
        if (customTMPUGUI)
            customTMPUGUI.text = CallDateSimple();
    }
    /// <summary>
    /// Returns a string of the current date in the referenced format
    /// </summary>
    /// <returns></returns>
    string CallDateSimple()                                                                                                   // CALL DATE SIMPLE
    {
        string dateString = System.DateTime.Now.ToString("dd.MM.yyyy");
        switch (defaultDateFormat)
        {
            case DateFormat.ddmmyyyy:
                dateString = System.DateTime.Now.ToString("dd.MM.yyyy");
                break;

            case DateFormat.mmddyyyy:
                dateString = System.DateTime.Now.ToString("MM.dd.yyyy");
                break;
        }
        return dateString;
    }
    /// <summary>
    /// Returns a string of the current date with the passed format
    /// </summary>
    /// <param name="customDateFormat"></param>
    /// <returns>Format of the returned date</returns>
    string CallDateCustom(DateFormat customDateFormat)                                                                      // CALL DATE CUSTOM
    {
        string dateString = System.DateTime.Now.ToString("dd.MM.yyyy");
        switch (customDateFormat)
        {
            case DateFormat.ddmmyyyy:
                dateString =  System.DateTime.Now.ToString("dd.MM.yyyy");
                break;

            case DateFormat.mmddyyyy:
                dateString =  System.DateTime.Now.ToString("MM.dd.yyyy");
                break;
        }
        return dateString;
    }



    // EDITOR
    /// <summary>
    /// Automically tries to fixe variables and missing references
    /// </summary>
    void GetMissingReferences()
    {
        if (!TMPUGUIComponentToTarget && GetComponent<TextMeshProUGUI>())
            TMPUGUIComponentToTarget = GetComponent<TextMeshProUGUI>();
    }
}
