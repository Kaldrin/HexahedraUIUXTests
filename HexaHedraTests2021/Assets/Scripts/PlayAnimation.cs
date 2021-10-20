using System.Collections;
using System.Collections.Generic;
using UnityEngine;





// Bastien BERNAND
// Reusable asset
// Last edited 20.10.2021

/// <summary>
/// Script to expose play animation functions from Animation components
/// </summary>

// Originally for UNITY 2021.1.15
// Last tested UNITY 2021.1.15
public class PlayAnimation : MonoBehaviour
{
    [SerializeField] List<Animation> animationComponentsToPLay = new List<Animation>();
    [SerializeField] float durationToWaitBeforePlay = 0f;



    public void EnableAnimations(bool state = true)                                                                                                     // ENABLE ANIMATIONS
    {
        if (animationComponentsToPLay != null && animationComponentsToPLay.Count > 0)
            for (int i = 0; i < animationComponentsToPLay.Count; i++)
                if (animationComponentsToPLay[i] != null)
                    animationComponentsToPLay[i].enabled = state;
    }

    public void PlayAfterDuration(string animationName) => StartCoroutine(PlayAfterDurationCoroutine(animationName));
    IEnumerator PlayAfterDurationCoroutine(string animationName)
    {
        yield return new WaitForSecondsRealtime(durationToWaitBeforePlay);
        Play(animationName);
    }
    public void Play(string animationName)                                                                                                                  // PLAY
    {
        if (animationComponentsToPLay != null && animationComponentsToPLay.Count > 0)
            for (int i = 0; i < animationComponentsToPLay.Count; i++)
                if (animationComponentsToPLay[i] != null && animationComponentsToPLay[i].GetClip(animationName))
                    animationComponentsToPLay[i].Play(animationName, PlayMode.StopAll);
    }

    public void Stop()                                                                                                                                          // STOP
    {
        if (animationComponentsToPLay != null && animationComponentsToPLay.Count > 0)
            for (int i = 0; i < animationComponentsToPLay.Count; i++)
                if (animationComponentsToPLay[i] != null)
                    animationComponentsToPLay[i].Stop();
    }

}
