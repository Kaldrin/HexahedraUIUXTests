using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;





// Bastien BERNAND
// Reusable asset
// Last edited 13.10.2021


/// <summary>
/// Allows to switch between multiple sprites to display on an Image component, left and right, with or without animation.
/// </summary>

// Originally made for UNITY 2020.1.15f1
// Last tested on UNITY 2020.1.15f1
public class SwitcherImageR : MonoBehaviour
{
    [SerializeField] Image ImageComponentToSwitch = null;
    [SerializeField] List<Sprite> listOfSpritesToCycleThrough = new List<Sprite>();

    [Header("ANIMATION")]
    [SerializeField] Animation animationComponentToUse = null;
    [SerializeField] string leftSwitchAnimationName = "SwitchLeft";
    [SerializeField] string rightSwitchAnimationName = "SwitchRight";
    [SerializeField] float imageChangeDelayForAnimation = 0.3f;
    int currentIndex = 0;



    private void OnEnable()                                                                                                                                   // ON ENABLE
    {
        GetMissingReferences();
        Switch(0);
    }

    /// <summary>
    /// Changes the switch index in the current direction and prepares the animation and text change
    /// </summary>
    /// <param name="direction">The direction in which it should cycle the <see cref="listOfSpritesToCycleThrough"/>, left or right, -1 or 1</param>
    public void Switch(int direction)                                                                                                                        // SWITCH
    {
        if (ImageComponentToSwitch && listOfSpritesToCycleThrough != null && listOfSpritesToCycleThrough.Count > 0)
        {
            // Index cycle
            int switchDirection = Mathf.FloorToInt(Mathf.Sign(direction));
            if (direction == 0)
                switchDirection = 0;
            currentIndex += switchDirection;
            if (currentIndex >= listOfSpritesToCycleThrough.Count)
                currentIndex = 0;
            else if (currentIndex < 0)
                currentIndex = listOfSpritesToCycleThrough.Count - 1;


            // ANIMATION
            if (animationComponentToUse)
            {
                if (switchDirection >= 0)
                    animationComponentToUse.Play(rightSwitchAnimationName, PlayMode.StopAll);
                else
                    animationComponentToUse.Play(leftSwitchAnimationName, PlayMode.StopAll);
            }


            Invoke("ApplyTextChange", imageChangeDelayForAnimation);
        }
    }

    /// <summary>
    /// Actually changes teh text targeted byt the switcher to correspond to the current index.
    /// </summary>
    void ApplyTextChange()                                                                                                                                // APPLY TEXT CHANGE
    {
        if (listOfSpritesToCycleThrough[currentIndex] != null)
            ImageComponentToSwitch.sprite = listOfSpritesToCycleThrough[currentIndex];
    }

    /// <summary>
    /// Sets the switch index to the desired number and prepares the text change and animation
    /// </summary>
    /// <param name="newIndex">The new index it should display from for the <see cref="listOfSpritesToCycleThrough"/></param>
    public void SetIndex(int newIndex)                                                                                                                    // SET INDEX
    {
        if (ImageComponentToSwitch && listOfSpritesToCycleThrough != null && listOfSpritesToCycleThrough.Count > newIndex)
        {
            currentIndex = newIndex;


            // ANIMATION
            if (animationComponentToUse)
                animationComponentToUse.Play(rightSwitchAnimationName, PlayMode.StopAll);


            Invoke("ApplyTextChange", imageChangeDelayForAnimation);
        }
    }




    // EDITOR
    void GetMissingReferences()                                                                                                                        // GET MISSING REFERENCES
    {
        if (!ImageComponentToSwitch && GetComponent<Image>())
            ImageComponentToSwitch = GetComponent<Image>();
        if (!animationComponentToUse && GetComponent<Animation>())
            animationComponentToUse = GetComponent<Animation>();
    }

    private void OnValidate()                                                                                                                            // ON VALIDATE
    {
        GetMissingReferences();
        Switch(0);
    }
}
