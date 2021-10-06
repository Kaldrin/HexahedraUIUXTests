using System.Collections;
using System.Collections.Generic;
using UnityEngine;





// Bastien BERNAND
// Reusable asset
// Last edited on 06.10.2021

/// <summary>
/// Plays a Particle System at ranom time intervals
/// </summary>

// Originally made for UNITY 2020.1.15f1
// Last tested on UNITY 2020.1.15f1
public class RandomPlayFXR : MonoBehaviour
{
    [SerializeField] ParticleSystem fxToPlay = null;
    [SerializeField] Vector2 randomTimeInterval = new Vector2(3, 6);





    void Start()
    {
        GetMissingComponents();
        Invoke("PlayFX", Random.Range(randomTimeInterval.x, randomTimeInterval.y));
    }

    public void PlayFX()
    {
        if (fxToPlay)
            fxToPlay.Play();
        Invoke("PlayFX", Random.Range(randomTimeInterval.x, randomTimeInterval.y));
    }





    // EDITOR
    void GetMissingComponents()
    {
        if (!fxToPlay && GetComponent<ParticleSystem>())
            fxToPlay = GetComponent<ParticleSystem>();
    }

    private void OnValidate() => GetMissingComponents();
}
