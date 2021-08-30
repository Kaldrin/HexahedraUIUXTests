using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;



// Bastien BERNAND
// Reusable asset
// Last edited 25.08.2021

/// <summary>
/// Script to expose functions to swap sprites in flip-flop mode
/// </summary>

// Originally for UNITY 2021.1.15
// Last tested UNITY 2021.1.15
public class SwapSprite : MonoBehaviour
{
    [SerializeField] Image imageToSwap = null;
    [SerializeField] Button buttonToSwap = null;
    [SerializeField] Sprite sprite1 = null;
    [SerializeField] Sprite sprite1Highlight = null;
    [SerializeField] Sprite sprite1Pressed = null;
    [SerializeField] Sprite sprite2 = null;
    [SerializeField] Sprite sprite2Highlight = null;
    [SerializeField] Sprite sprite2Pressed = null;
    bool state = false;






    public void Swap()                                                                                                                          // SWAP
    {
        GetMissingReferences();


        if (state)
        {
            if (sprite1)
                imageToSwap.sprite = sprite1;
            SpriteState spriteState = new SpriteState();
            if (sprite1Highlight)
            {
                spriteState.highlightedSprite = sprite1Highlight;
                spriteState.selectedSprite = sprite1Highlight;
            }
            if (sprite1Pressed)
            {
                spriteState.pressedSprite = sprite1Pressed;
                spriteState.disabledSprite = sprite1Pressed;
            }
            buttonToSwap.spriteState = spriteState;
            

            state = false;
        }
        else if (!state)
        {
            if (sprite2)
                imageToSwap.sprite = sprite2;
            SpriteState spriteState = new SpriteState();
            if (sprite2Highlight)
            {
                spriteState.highlightedSprite = sprite2Highlight;
                spriteState.selectedSprite = sprite2Highlight;
            }
            if (sprite2Pressed)
            {
                spriteState.pressedSprite = sprite2Pressed;
                spriteState.disabledSprite = sprite2Pressed;
            }
            buttonToSwap.spriteState = spriteState;


            state = true;
        }
    }





    // EDITOR
    void GetMissingReferences()                                                                                                             // GET MISSING REFERENCES
    {
        if (!imageToSwap && GetComponent<Image>())
            imageToSwap = GetComponent<Image>();
        if (!buttonToSwap && GetComponent<Button>())
            buttonToSwap = GetComponent<Button>();
    }

    // Automatically get missing references
    private void OnDrawGizmos()                                                                                                             // ON DRAW GIZMOS
    {
        GetMissingReferences();
    }
}
