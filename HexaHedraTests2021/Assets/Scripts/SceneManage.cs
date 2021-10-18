using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;





// Bastien BERNAND
// Reusable asset
// Last edited 14.10.2021

// REQUIREMENTS
// Old input system

/// <summary>
/// This script manages scene transitions and scene loading with smooth animations.
/// </summary>

// Originally made for Unity 2019.1.1f1
// Last test on UNITY 2021.1.15f1
public class SceneManage : MonoBehaviour
{
    public static SceneManage Instance;


    [Header("SCENE CHANGE")]
    [Tooltip("Should this script automatically load a referenced scene after a certain amount of time ?")]
    [SerializeField] bool autoLoadSceneAfterDuration = false;
    [SerializeField] float durationBeforeAutoLoadScene = 0.5f;
    [SerializeField] int sceneToAutoLoadIndex = 1;
    [SerializeField] Animator sceneSwitchAnimator = null;
    [SerializeField] string sceneExitAnimatorParameterName = "Exit";


    Scene sceneToLoad;
    public bool proceedToLoadScene = false;
    bool quit = false;
    bool canLoadScene = true;


    [Header("RESTART SCENE")]
    [Tooltip("Choose which keys should be pressed to restart the scene")]
    [SerializeField] KeyCode[] pressSimultaneousKeysToRestart = null;











    #region FUNCTIONS
    #region BASE FUNCTIONS
    void Awake() => Instance = this;
    void Start()                                                                                                                        // START
    {
        // If chosen, starts the coroutine that will load the indicated scene after the indicated duration
        if (autoLoadSceneAfterDuration)
            StartCoroutine(AutoLoadSceneAfterDuration());
    }


    void Update()                                                                                                                           // UPDATE
    {
        if (isActiveAndEnabled && enabled)
        {
            // Checks if the inputs to restart the scene were pressed
            if (CheckIfAllKeysPressed(pressSimultaneousKeysToRestart))
                Restart();


            // Is called when the scene switch screen finished fading on
            if (proceedToLoadScene)
            {
                if (quit)
                    Application.Quit();
                else if (canLoadScene)
                {
                    Debug.Log(sceneToLoad.name);
                    canLoadScene = false;
                    LoadScene(sceneToLoad);
                }
            }
        }
    }
    #endregion





    // SCENE LOADING
    // Automaticly loads the indicated scene after the indicated duration, without transition animation
    IEnumerator AutoLoadSceneAfterDuration()                                                                                        // AUTO LOAD SCENE AFTER DURATION
    {
        yield return new WaitForSecondsRealtime(durationBeforeAutoLoadScene);


        SceneManager.LoadSceneAsync(sceneToAutoLoadIndex);
    }

    public void LoadScene(Scene scene) => SceneManager.LoadSceneAsync(scene.name);
    public void SetLoadSceneViaIndex(int index)                                                                                         // SETR LOAD SCENE VIA INDEX
    {
        sceneToLoad = SceneManager.GetSceneByBuildIndex(index);
        sceneSwitchAnimator.SetTrigger(sceneExitAnimatorParameterName);
    }
    public void SetLoadSceneViaName(string name)
    {
        sceneToLoad = SceneManager.GetSceneByName(name);
        sceneSwitchAnimator.SetTrigger(sceneExitAnimatorParameterName);
    }

    // Set which scene should be loaded after the close scene anim
    public void SetLoadScene(Scene scene)                                                                                               // SET LOAD SCENE
    {
        sceneToLoad = scene;
        sceneSwitchAnimator.SetTrigger(sceneExitAnimatorParameterName);
    }

    /// <summary>
    /// Triggers the restart of the current scene, called by the restart inputs
    /// </summary>
    public void Restart() => SetLoadScene(SceneManager.GetActiveScene());

    /// <summary>
    /// // Sets the instruction to quit the game after after the close scene anim
    /// </summary>
    public void Quit()                                                                                                                  // QUIT
    {
        SetLoadScene(new Scene());
        quit = true;
    }





    // SECONDARY
    /// <summary>
    /// Checks if the given keys are being pressed
    /// </summary>
    /// <param name="keys">The list of keys to press</param>
    /// <returns>Returns if the keys have been pressed</returns>
    bool CheckIfAllKeysPressed(KeyCode[] keys)
    {
        bool notPressed = false;
        for (int i = 0; i < keys.Length; i++)
            if (!Input.GetKey(keys[i]))
                notPressed = true;
        return !notPressed;
    }
    #endregion
}
