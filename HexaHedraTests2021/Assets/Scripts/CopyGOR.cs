using UnityEngine;






// Bastien BERNAND
// Reusable asset
// Last edited 12.10.2021

/// <summary>
/// Gives public functions to duplicate game objects from buttons & co
/// </summary>

// Originally made for UNITY 2020.1.15f1
// Last tested on UNITY 2020.1.15f1
public class CopyGOR : MonoBehaviour
{
    [SerializeField] bool activateCopy = true;

    public void Copy(GameObject objectToCopy)                                                                                               // COPY
    {
        if (objectToCopy && objectToCopy.transform.parent)
        {
            GameObject copy = Instantiate(objectToCopy, objectToCopy.transform.parent);
            if (activateCopy)
                copy.SetActive(true);
        }
    }
}
