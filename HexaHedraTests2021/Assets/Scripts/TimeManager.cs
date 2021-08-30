using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;




// Bastien BERNAND
// Hexahera tests
// Last edited 30.08.2021

/// <summary>
/// This script managed the behaviour of the timewheel
/// </summary>

// Originally made for UNITY 2021.1.15f1
// Last tested on UNITY 2021.1.15f1
public class TimeManager : MonoBehaviour
{
    [SerializeField] float baseRotationSpeedPerSecond = 1;
    [SerializeField] float rewindSpeed = 5;
    [SerializeField] float stepPlaySpeed = 10;
    [HideInInspector] public float timeSpeed = 1;
    bool playing = false;
    float elapsedTime = 0;


    [Header("BUTTONS")]
    [SerializeField] Button playStepButton = null;
    [SerializeField] GameObject playButton = null;
    [SerializeField] GameObject pauseButton = null;
    [SerializeField] Button speed1Button = null;
    [SerializeField] Button speed2Button = null;
    [SerializeField] Button speed3Button = null;
    [SerializeField] Button stopButton = null;
 

    [Header("GRAPHIC COMPONENTS")]
    [SerializeField] GameObject outerWheel3 = null;
    [SerializeField] GameObject mainGear = null;
    [SerializeField] GameObject outerWheel2 = null;
    [SerializeField] GameObject outerWheel1 = null;
    [SerializeField] GameObject bgWheel = null;






    private void FixedUpdate()
    {
        if (playing)
        {
            elapsedTime += Time.fixedDeltaTime;

            RotateGraphicElements(baseRotationSpeedPerSecond);
        }
    }


    public void Play()
    {
        playing = true;


        if (playButton)
            playButton.SetActive(false);
        if (pauseButton)
            pauseButton.SetActive(true);
        if (stopButton)
            stopButton.interactable = true;
    }


    public void Pause()
    {
        playing = false;
        timeSpeed = 1;

        if (playButton)
            playButton.SetActive(true);
        if (pauseButton)
            pauseButton.SetActive(false);
    }


    public void PlayOneStep(int frames)
    {
        Play();
        Pause();
        StartCoroutine(PlayOneStepCoroutine(frames));
    }

    IEnumerator PlayOneStepCoroutine(int frames)
    {
        int cycles = frames;

        while (cycles > 0)
        {
            cycles--;
            yield return new WaitForSecondsRealtime(Time.fixedDeltaTime / stepPlaySpeed);
            elapsedTime += Time.fixedDeltaTime;

            RotateGraphicElements(baseRotationSpeedPerSecond);
        }

        if (playStepButton)
            playStepButton.interactable = true;
        if (playButton && playButton.GetComponent<Button>())
            playButton.GetComponent<Button>().interactable = true;
        if (speed1Button)
            speed1Button.interactable = true;
        if (speed2Button)
            speed2Button.interactable = true;
        if (speed3Button)
            speed3Button.interactable = true;
    }


    public void Stop()
    {
        playing = false;

        if (stopButton)
            stopButton.interactable = false;
        if (playButton)
            playButton.SetActive(true);
        if (pauseButton)
            pauseButton.SetActive(false);

        StartCoroutine(Rewind());
        
    }

    IEnumerator Rewind()
    {
        while(elapsedTime > 0)
        {
            elapsedTime -= Time.fixedDeltaTime;
            RotateGraphicElements(- baseRotationSpeedPerSecond);
            yield return new WaitForSecondsRealtime(Time.fixedDeltaTime / rewindSpeed);
        }
    }

    public void SetSpeed(int amount)
    {
        timeSpeed = amount;
    }


    void RotateGraphicElements(float amount)
    {
        if (outerWheel3)
            outerWheel3.transform.Rotate(0, 0, - amount * Time.fixedDeltaTime * timeSpeed);
        if (mainGear)
            mainGear.transform.Rotate(0, 0, amount * Time.fixedDeltaTime * timeSpeed);
        if (outerWheel2)
            outerWheel2.transform.Rotate(0, 0, - amount * Time.fixedDeltaTime * timeSpeed);
        if (outerWheel1)
            outerWheel1.transform.Rotate(0, 0, amount * Time.fixedDeltaTime * timeSpeed);
        if (bgWheel)
            bgWheel.transform.Rotate(0, 0, - amount * Time.fixedDeltaTime * timeSpeed);
    }
}
