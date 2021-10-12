using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "CursorData01", menuName = "Cursor/Cursor data")]
public class CursorData : ScriptableObject
{
    public string cursorName;
    public int cursorAnimationFramerate;
    public Vector2 cursorHotspot;
    public Texture2D[] frames;
}
