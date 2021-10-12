using System.Collections;
using System.Collections.Generic;
using UnityEngine;





// Bastien BERNAND
// Reusable asset
// Last edited 12.10.2021

// REQUIREMENTS
// CursorData scriptable object class

/// <summary>
/// Manages the cursor changes and animations. Uses Update
/// </summary>

// Originally made for UNITY 2020.1.15f1
// Last tested on UNITY 2020.1.15f1
public class CursorManager : MonoBehaviour
{
    [SerializeField] CursorData defaultCursor = null;
    CursorData currentCursor = null;
    bool currentCursorIsAnimated = false;
    float frameDuration = 0;
    float frameTimer = 0;
    int currentCursorAnimationFrame = 0;



    private void Start() => SetDefaultCursor();                                                                                                         // START
    private void Update()                                                                                                                               // UPDATE
    {
        if (isActiveAndEnabled && enabled)
            if (currentCursor && currentCursorIsAnimated)
            {
                if (frameTimer > 0)
                    frameTimer -= Time.deltaTime;
                else
                    NextCursorAnimationFrame();
            }
    }

    void NextCursorAnimationFrame()                                                                                                                         // NEXT CURSOR ANIMATION FRAME
    {
        frameTimer = frameDuration;
        currentCursorAnimationFrame++;
        if (currentCursorAnimationFrame >= currentCursor.frames.Length)
            currentCursorAnimationFrame = 0;

        if (currentCursor.frames[currentCursorAnimationFrame])
            Cursor.SetCursor(currentCursor.frames[currentCursorAnimationFrame], currentCursor.cursorHotspot, CursorMode.Auto);
    }


    /// <summary>
    /// Changes the active cursor
    /// </summary>
    /// <param name="newCursor">The new cursor to set, requires the CursorData scriptable object class</param>
    public void SetCursor(CursorData newCursor)                                                                                                                 // SET CURSOR
    {
        if (newCursor)
        {
            currentCursor = newCursor;

            // If no default cursor yet, this one becomes the efault cursor
            if (!defaultCursor)
                defaultCursor = currentCursor;


            currentCursorAnimationFrame = 0;
            if (newCursor.cursorAnimationFramerate > 0)
                frameDuration = 1f / newCursor.cursorAnimationFramerate;
            else
                frameDuration = 1f / 24f;
            frameTimer = frameDuration;


            if (newCursor.frames.Length <= 1)
                currentCursorIsAnimated = false;
            else
                currentCursorIsAnimated = true;
        }
    }


    /// <summary>
    /// Sets the default cursor if there is one referenced, called on Start.
    /// </summary>
    void SetDefaultCursor()                                                                                                                                     // SET DEFAULT CURSOR
    {
        if (defaultCursor)
            SetCursor(defaultCursor);
    }
}
