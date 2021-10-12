using UnityEngine;

using UnityEngine.UI;





// Bastien BERNAND
// Hehexadra UI / UX tests
// Last edited 12.10.2021

/// <summary>
/// Script to prevent the player from deleting the last remaining profile.
/// </summary>

// Originally made for UNITY 2020.1.15f1
// Last tested on UNITY 2020.1.15f1
public class DisableSpecificChildButtonIfOnlyOneChild : MonoBehaviour
{
    void Start() => Check();                                                                                                   // START
    private void OnTransformChildrenChanged() => Check();                                                                        // ON TRANSFORM CHILDREN CHANGED
    void Check()                                                                                                              // CHECK
    {
        if (transform.childCount <= 2)
            for (int i = 0; i < transform.childCount; i++)
                transform.GetChild(i).GetChild(3).GetComponent<Button>().interactable = false;
        else
            for (int i = 0; i < transform.childCount; i++)
                transform.GetChild(i).GetChild(3).GetComponent<Button>().interactable = true;
    }
}
