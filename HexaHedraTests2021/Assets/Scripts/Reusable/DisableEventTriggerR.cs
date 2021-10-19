using UnityEngine;

using UnityEngine.EventSystems;




// Bastien BERNAND
// Reusable asset
// Last edited 19.10.2021

/// <summary>
/// This script serves the specific function of disabling the EventTrigger component of a component on Start, as it's not a serialized property.
/// </summary>

// Originally made for UNITY 2020.1.15f1
// Last tested on UNITY 2020.1.15f1
[RequireComponent(typeof(EventTrigger))]
public class DisableEventTriggerR : MonoBehaviour
{
    [SerializeField] EventTrigger eventTriggerToDisable = null;




    void Start()                                                                                                        // START
    {
        GetMissingComponents();
        if (eventTriggerToDisable)
            eventTriggerToDisable.enabled = false;
    }



    // EDITOR
    /// <summary>
    /// Automatically assigns missing components.
    /// </summary>
    void GetMissingComponents()                                                                                         // GET MISSING COMPONENTS
    {
        if (!eventTriggerToDisable && GetComponent<EventTrigger>())
            eventTriggerToDisable = GetComponent<EventTrigger>();
    }
    private void OnValidate() => GetMissingComponents();
}
