using System.Collections;
using System.Collections.Generic;
using UnityEngine;







// Bastien BERNAND
// Reusable script
// Last edited on 06.10.2021

/// <summary>
/// This script is to trigger an animator / animation after a certain / random time in the scene.
/// </summary>

// VERSION
// Originally made for UNITY 2019.1.1f1
// Last tested on UNITY 2020.1.15f1
public class TriggerAnimatorAfterDuration : MonoBehaviour
{
    [SerializeField] Animator animatorToTrigger = null;
    [SerializeField] Animation animationToTrigger = null;
    [SerializeField] string animationName = "LanternWind01";
    [SerializeField] Vector2 randomDelayBetween = new Vector2(0.1f, 1f);













    void Start()                                                                                                            // START
    {
        if (animatorToTrigger != null)
            animatorToTrigger.enabled = false;
        

        Invoke("TriggerAnimation", Random.Range(randomDelayBetween.x, randomDelayBetween.y));
    }




    void TriggerAnimation()                                                                                                  // TRIGGER ANIMATION
    {
        GetMissingComponents();

        if (animationToTrigger != null && animationName != null && animationName != "" && animationToTrigger.GetClip(animationName) != null)
            animationToTrigger.Play(animationName, PlayMode.StopAll);
        if (animatorToTrigger != null)
            animatorToTrigger.enabled = true;
    }








    // See if it's possible to automatically get missing components
    void GetMissingComponents()                                                                                                            // GET COMPONENTS
    {
        if (animationToTrigger == null && GetComponent<Animation>())
            animationToTrigger = GetComponent<Animation>();
        if (animatorToTrigger == null && GetComponent<Animator>())
            animatorToTrigger = GetComponent<Animator>();
    }






    // Automatically gets the components references before the user has to assign them
    private void OnValidate()                                                                             // ON VALIDATE
    {
        GetMissingComponents();
    }
}
