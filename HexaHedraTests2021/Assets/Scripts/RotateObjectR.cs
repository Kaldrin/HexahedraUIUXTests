using System.Collections;
using System.Collections.Generic;
using UnityEngine;






// Bastien BERNAND
// Reusable asset
// Last edited on 05.10.2021

/// <summary>
/// Rotates a transform in FixedUpdate by the indicated amounts.
/// </summary>

// Originally made for UNITY 2020..1.15f1
// Last tested on UNITY 2020.1.15f1
public class RotateObjectR : MonoBehaviour
{
    /// <summary>
    /// Transform component to rotate each FixedUpdate frame by the selected amounts
    /// </summary>
    [SerializeField] Transform transformToRotate = null;
    [SerializeField] float xAmount = 0;
    [SerializeField] float yAmount = 0;
    [SerializeField] float zAmount = 1;





    private void Start() => GetMissingReferences();                                                                                 // START
    void FixedUpdate() => transformToRotate.Rotate(xAmount, yAmount, zAmount);                                                           // UPDATE





    // EDITOR
    void GetMissingReferences()                                                                                                        // GET MISSING REFERENCES
    {
        if (!transformToRotate && GetComponent<Transform>())
            transformToRotate = GetComponent<Transform>();
    }
    void OnValidate() => GetMissingReferences();                                                                                    // ON VALIDATE
}
