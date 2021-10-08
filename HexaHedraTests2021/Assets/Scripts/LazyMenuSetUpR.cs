using System.Collections;
using System.Collections.Generic;
using UnityEngine;




// Bastien BERNAND
// Reusable asset
// Last edited 08.10.2021

/// <summary>
/// This script is just to enable / disable the right menus on start. To put on the parent on the menus.
/// </summary>
 
// Originally made for UNITY 2019.1.14
// Last tested on UNITY 2020.1.15f1
public class LazyMenuSetUpR : MonoBehaviour
{
    [Tooltip("The menu that will be active on start")]
    [SerializeField] GameObject menuToActivateOnStart = null;







    void Awake()                                                                                                                                    // AWAKE
    {
        GetMissingComponents();

        // Disable all menus
        if (transform.childCount > 0)
            for (int i = 0; i < transform.childCount; i++)
                if (transform.GetChild(i).gameObject != null)
                {
                    GameObject menuObject = transform.GetChild(i).gameObject;
                    if (menuObject.activeInHierarchy != false)
                        menuObject.SetActive(false);
                }
                else
                    Debug.Log("Problem with disabling the menu index " + " i");

        // Activate required menu
        if (menuToActivateOnStart != null)
            if (menuToActivateOnStart.activeInHierarchy != true)
                menuToActivateOnStart.SetActive(true);
    }





    // EDITOR
    void GetMissingComponents()
    {
        if (menuToActivateOnStart == null)
            menuToActivateOnStart = transform.GetChild(0).gameObject;
    }

    private void OnValidate() => GetMissingComponents();
}
