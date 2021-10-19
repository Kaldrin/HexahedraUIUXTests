using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;





// Bastien BERNAND
// Reusable asset
// Last edited 19.10.2021
// Clean organized and optimzed

/// <summary>
/// Manages scene loading, transitions & animations. To place on a Canvas dedicated to scene transitions.
/// </summary>

// Originally made for UNITY 2020.1.15f1
// Last tested on UNITY 2020.1.15f1
public class SceneTransitionManagerR : MonoBehaviour
{
    int sceneToLoadIndex = 0;
    [SerializeField] Animation animationComponentToUse = null;
    [SerializeField] string quitSceneAnimationName = "Quit";
    [SerializeField] List<KeyCode> keysToRestart = new List<KeyCode>();



    void Update()
    {
        if (enabled && isActiveAndEnabled)
            if (CheckIfAllKeysArePressed())
                RestartScene();
    }

    public void LoadSceneByIndex(int index)
    {
        GetMissingReferences();
        sceneToLoadIndex = index;
        // ANIMATION
        PlayQuitAnimation();
    }


    /// <summary>
    /// Quits the game, using the transition animation and the index -1 which <see cref="ProceedToLoadScene"/> will understand as quit the game.
    /// </summary>
    public void QuitGame()
    {
        sceneToLoadIndex = -1;
        // ANIMATION
        PlayQuitAnimation();
    }
    /// <summary>
    /// Restarts the current scene if all referenced keys of <see cref="keysToRestart"/>are pressed.
    /// </summary>
    public void RestartScene() => LoadSceneByIndex(SceneManager.GetActiveScene().buildIndex);
    /// <summary>
    /// Immediately starts to load the scene of <see cref="sceneToLoadIndex"/> asynchronously. Usually shouldn't be called manually but rathered called by the quit animation of <see cref="animationComponentToUse"/>
    /// </summary>
    void ProceedToLoadScene() => StartCoroutine(ProceedToLoadSceneAsync());
    /// <summary>
    /// Coroutine used by <see cref="ProceedToLoadScene"/>
    /// </summary>
    IEnumerator ProceedToLoadSceneAsync()
    {
        if (sceneToLoadIndex == -1)
            Application.Quit();
        else
        {
            AsyncOperation asyncOp = SceneManager.LoadSceneAsync(sceneToLoadIndex, LoadSceneMode.Single);
            while (!asyncOp.isDone)
                yield return null;
        }
    }

    /// <summary>
    /// Use by the Load secen functions to start the scene transition animation. This animation should trigger the <see cref="ProceedToLoadScene"/> function with an animation event
    /// </summary>
    void PlayQuitAnimation()
    {
        if (animationComponentToUse)
            animationComponentToUse.Play(quitSceneAnimationName, PlayMode.StopAll);
    }
    






    // EDITOR
    /// <summary>
    /// Immediately gets the missing references
    /// </summary>
    void GetMissingReferences()
    {
        if (!animationComponentToUse && GetComponent<Animation>())
            animationComponentToUse = GetComponent<Animation>();
        if (quitSceneAnimationName == "")
            quitSceneAnimationName = "Quit";
        if (sceneToLoadIndex < 0)
            sceneToLoadIndex = 0;
    }
    private void OnValidate() => GetMissingReferences();





    // SECONDARY
    bool CheckIfAllKeysArePressed()
    {
        if (keysToRestart != null && keysToRestart.Count > 0)
        {
            bool allKeysPressed = true;

            for (int i = 0; i < keysToRestart.Count; i++)
                if (!(keysToRestart[i] != null && Input.GetKey(keysToRestart[i])))
                    allKeysPressed = false;

            return allKeysPressed;
        }
        else
            return false;
    }
}
