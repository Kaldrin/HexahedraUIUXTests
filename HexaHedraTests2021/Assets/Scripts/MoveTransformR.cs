using System.Collections;
using System.Collections.Generic;
using UnityEngine;




// Bastien BERNAND
// Reusable asset
// Last edited 08.10.2021

/// <summary>
/// This script is a simple one to move a transform in a given direction.
/// </summary>

// Originally made for UNITY 2020.1.15f1
// Last tested on UNITY 2020.1.15f1
[RequireComponent(typeof(Transform))]
public class MoveTransformR : MonoBehaviour
{
    [SerializeField] Transform transformToMove = null;
    [SerializeField] Vector3 amount = new Vector3(0, 0, 0);
    Vector3 initialPosition = new Vector3();
    bool run = true;






    private void Start()
    {
        GetMissingReferences();
        initialPosition = transformToMove.position;
    }
    private void FixedUpdate()
    {
        if (transformToMove && run)
            transformToMove.Translate(amount);
    }
    public void Pause() => run = false;
    public void Play() => run = true;
    public void SetState(bool state) => run = state;
    public void ResetState()
    {
        run = true;
        transformToMove.position = initialPosition;
    }
        



    // EDITOR   
    void GetMissingReferences()                                                                                                 // GET MISSING REFERENCES
    {
        if (!transformToMove && GetComponent<Transform>())
            transformToMove = GetComponent<Transform>();
    }
    private void OnValidate() => GetMissingReferences();                                                                        // ON VALIDATE
}
