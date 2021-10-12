using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;





// Bastien BERNAND
// Hexahedra UI / UX

/// <summary>
/// This script allows to move the time handle through the timeline with the mouse
/// </summary>*

// Originally made for UNITY 2021.1.15f1
// Last tested on UNITY 2021.1.15f1
public class MoveTimeHandle : MonoBehaviour
{
    [SerializeField] Image timelineImage = null;
    [SerializeField] Transform handleTransformToRotate = null;
    [SerializeField] float multiplier = 2;
    [SerializeField] float safeZone = 5;
    bool dragging = false;




    private void Update()
    {
        if (dragging)
            handleTransformToRotate.Rotate(0, 0, - Input.GetAxis("Mouse X") * multiplier);

        
        if (handleTransformToRotate.eulerAngles.z < (360 - (timelineImage.fillAmount * 360) / 2) + safeZone && handleTransformToRotate.eulerAngles.z > 180)
        {
            Vector3 newEulerAngles = new Vector3(handleTransformToRotate.eulerAngles.x, handleTransformToRotate.eulerAngles.y, (360 - (timelineImage.fillAmount * 360) / 2) + safeZone);
            handleTransformToRotate.eulerAngles = newEulerAngles;
        }
        if (handleTransformToRotate.eulerAngles.z > ((timelineImage.fillAmount * 360) / 2) - safeZone && handleTransformToRotate.eulerAngles.z < 180)
        {
            Vector3 newEulerAngles = new Vector3(handleTransformToRotate.eulerAngles.x, handleTransformToRotate.eulerAngles.y, ((timelineImage.fillAmount * 360) / 2) - safeZone);
            handleTransformToRotate.eulerAngles = newEulerAngles;
        }
        
    }


    public void StartDrag(bool state)
    {
        dragging = state;
    }
}
