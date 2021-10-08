using System.Collections;
using System.Collections.Generic;
using UnityEngine;






// Reusable asset
// Bastien BERNAND
// Last edited 07.10.2021

/// <summary>
/// This script provides functions to open links to web pages from the game
/// </summary>

// Originally made for UNITY 2020.3
// Last tested on UNITY 2020.1.15f1
public class OpenLinkFromBuild : MonoBehaviour
{
    public void OpenLink(string link) => Application.OpenURL(link);                                                                             // ONPEN LINK
}
