using System.Collections;
using System.Collections.Generic;
using UnityEngine;




public class DragToSelect : MonoBehaviour
{
    [SerializeField] RectTransform selectionObject = null;
    [SerializeField] float multiplier = 10;
    bool dragging = false;
    Vector2 firstPos = new Vector2(0, 0);





    private void Update()                                                                                                               // UPDATE
    {
        // Detect mouse drag
        if (Input.GetMouseButtonDown(0))
            StartDragging(true);
        if (Input.GetMouseButtonUp(0))
            StartDragging(false);


        if (dragging)
            Drag();
    }



    void StartDragging(bool state)                                                                                                              // START DRAGGING
    {
        Debug.Log(Input.mousePosition);
        dragging = state;
        selectionObject.gameObject.SetActive(state);
        if (state)
        {
            firstPos = Input.mousePosition;
            selectionObject.position = Input.mousePosition;
            selectionObject.sizeDelta = new Vector2(0, 0);
        }
    }


    private void Drag()                                                                                                                             // DRAG
    {
        Vector2 currentMousePos = Input.mousePosition;
        selectionObject.sizeDelta = new Vector2(Mathf.Abs(currentMousePos.x - firstPos.x) * multiplier, Mathf.Abs(currentMousePos.y - firstPos.y) * multiplier);
        selectionObject.position = (firstPos + currentMousePos) / 2;
    }
}
