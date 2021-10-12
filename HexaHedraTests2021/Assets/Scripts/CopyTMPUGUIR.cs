using UnityEngine;

using TMPro;





// Bastien BERNAND
// Reusable asset
// Last edited 12.10.2021

// REQUIREMENTS
// TextMeshPro package

/// <summary>
/// Gives public functions to copy the text of TextMeshProUGUI components via buttons and co.
/// </summary>

// Originally made for UNITY 2020.1.15f1
// Last tested on UNITY 2020.1.15f1
[RequireComponent(typeof(TextMeshProUGUI))]
public class CopyTMPUGUIR : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI TMPUGUIComponent = null;
    /// <summary>
    /// TMPUGUI component which text will be copied using the <see cref="Copy"/> function
    /// </summary>
    [SerializeField] TextMeshProUGUI TMPUGUIToCopy = null;









    /// <summary>
    /// Sets the component that will be copied for the <see cref="Copy"/> function
    /// </summary>
    public void SetComponentToCopy(TextMeshProUGUI TMPUGUIComponentToSet)                                                           // SET COMPONET TO COPY
    {
        if (TMPUGUIComponentToSet)
            TMPUGUIToCopy = TMPUGUIComponentToSet;
    }

    public void Copy()                                                                                                                 // COPY
    {
        if (TMPUGUIToCopy && TMPUGUIComponent)
            TMPUGUIComponent.text = TMPUGUIToCopy.text;
    }
    /// <summary>
    /// Different from the <see cref="Copy"/> function, lets you enter a custom component to copy from.
    /// </summary>
    public void CopyTMPUGUI(TextMeshProUGUI TMPUGUIToCopy)                                                                            // COPY TMPUGUI
    {
        GetMissingComponent();

        if (TMPUGUIComponent && TMPUGUIToCopy)
            TMPUGUIComponent.text = TMPUGUIToCopy.text;
    }




    // EDITOR
    void GetMissingComponent()                                                                                      // GET MISSING COMPONENTS
    {
        if (!TMPUGUIComponent && GetComponent<TextMeshProUGUI>())
            TMPUGUIComponent = GetComponent<TextMeshProUGUI>();
    }

    private void OnValidate() => GetMissingComponent();
}
