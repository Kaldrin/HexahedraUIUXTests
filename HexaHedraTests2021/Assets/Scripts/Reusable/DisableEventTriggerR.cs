using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.EventSystems;




// Bastien BERNAND
// Reusable asset
// Last edited 18.10.2021

/// <summary>
/// This script serves the specific function of disabling the EventTrigger component of a component on Start, as it's not a serialized property.
/// </summary>

// Originally made for UNITY 2020.1.15f1
// Last tested on UNITY 2020.1.15f1
[RequireComponent(typeof(EventTrigger))]
public class DisableEventTriggerR : MonoBehaviour
{
    [SerializeField] EventTrigger eventTriggerToDisable = null;




    void Start()
    {
        GetMissingComponents();
        if (eventTriggerToDisable)
            eventTriggerToDisable.enabled = false;
    }

    void GetMissingComponents()
    {
        if (!eventTriggerToDisable && GetComponent<EventTrigger>())
            eventTriggerToDisable = GetComponent<EventTrigger>();
    }
    private void OnValidate() => GetMissingComponents();
}
