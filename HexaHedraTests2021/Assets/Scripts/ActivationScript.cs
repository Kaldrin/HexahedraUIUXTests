using UnityEngine;





// Bastien BERNAND
// Reusable asset
// Last edited 07.10.2021

/// <summary>
/// This script allows to access more activation functions for an object
/// </summary>

// Originally made for UNITY 2019.1.13f1
// Last tested for UNITY 2020.1.15f1
public class ActivationScript : MonoBehaviour
{
    public void WaitAndDisable(float duration) => Invoke("Disable", duration);
    public void Disable() => SetActive(false);
    public void SetActive(bool state) => gameObject.SetActive(state);
    public void Switch() => gameObject.SetActive(!isActiveAndEnabled);
}
