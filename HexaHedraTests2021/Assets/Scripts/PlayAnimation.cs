﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;





// Bastien BERNAND
// Reusable asset
// Last edited 24.08.2021

/// <summary>
/// Script to expose play animation functions from Animation components
/// </summary>

// Originally for UNITY 2021.1.15
// Last tested UNITY 2021.1.15
public class PlayAnimation : MonoBehaviour
{
    [SerializeField] List<Animation> animationComponentsToPLay = new List<Animation>();



    public void EnableAnimations(bool state = true)                                                                                                     // ENABLE ANIMATIONS
    {
        if (animationComponentsToPLay != null && animationComponentsToPLay.Count > 0)
            for (int i = 0; i < animationComponentsToPLay.Count; i++)
                if (animationComponentsToPLay[i] != null)
                    animationComponentsToPLay[i].enabled = state;
    }

    public void Play(string animationName)                                                                                                                  // PLAY
    {
        if (animationComponentsToPLay != null && animationComponentsToPLay.Count > 0)
            for (int i = 0; i < animationComponentsToPLay.Count; i++)
                if (animationComponentsToPLay[i] != null && animationComponentsToPLay[i].GetClip(animationName))
                    animationComponentsToPLay[i].Play(animationName, PlayMode.StopAll);
    }

}