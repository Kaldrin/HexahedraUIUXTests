using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;







// Bastien BERNAND
// Reusable asset
// Last edited 13.10.2021

/// <summary>
/// Gives public functions to control sliders from buttons & co.
/// </summary>

// Originally made for UNITY 2020.1.15f1
// Last tested on UNITY 2020.1.15f1
public class SliderControllerR : MonoBehaviour
{
    [SerializeField] Slider sliderToControl = null;
    [SerializeField] float controlMultiplier = 0;
    bool controlSlider = false;




    private void FixedUpdate()                                                                                                      // FIXED UPDATE
    {
        if (enabled && isActiveAndEnabled)
            if (sliderToControl && controlSlider)
            {
                sliderToControl.value += controlMultiplier;


                if (sliderToControl.value <= sliderToControl.minValue)
                {
                    sliderToControl.value = sliderToControl.minValue;
                    EndSliderControl();
                }
                if (sliderToControl.value >= sliderToControl.maxValue)
                {
                    sliderToControl.value = sliderToControl.maxValue;
                    EndSliderControl();
                }
            }
    }


    /// <summary>
    /// Starts the modification of the slider's value according to the <see cref="controlMultiplier"/> value
    /// </summary>
    public void StartSliderControl()                                                                                                        // START SLIDER CONTROL
    {
        if (!controlSlider)
            controlSlider = true;
    }
    /// <summary>
    /// Ends the modification of the slider's value according to the <see cref="controlMultiplier"/> value
    /// </summary>
    public void EndSliderControl()                                                                                                          // END SLIDER CONTROL
    {
        if (controlSlider)
            controlSlider = false;
    }
}
