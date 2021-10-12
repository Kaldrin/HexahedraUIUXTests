using UnityEngine;






// Bastien BERNAND
// Reusable asset
// Last edited 12.10.2021

/// <summary>
/// Gives public functions to delete a targeted object from a button & co
/// </summary>

// Originally made for UNITY 2020.1.15f1
// Last tested on UNITY 2020.1.15f1
public class TargetedDeleteR : MonoBehaviour
{
    [SerializeField] GameObject objectToDelete = null;





    public void DeleteTheObject()                                                                                   // DELETE THE OBJECT
    {
        if (objectToDelete)
            Destroy(objectToDelete);
    }

    public void SetObjectToDelete(GameObject newObjectToDelete)                                                       // SET OBJECT TO DELETE   
    {
        if (newObjectToDelete)
            objectToDelete = newObjectToDelete;
    }
}
