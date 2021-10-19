using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlurRenderer : MonoBehaviour
{
    [SerializeField] Camera blurCam = null;
    [SerializeField] Material blurMat = null;


    private void Update()
    {
        if (blurCam & blurMat)
        {
            if (blurCam.targetTexture != null)
                blurCam.targetTexture.Release();
            blurCam.targetTexture = new RenderTexture(Screen.width, Screen.height, 24, RenderTextureFormat.ARGB32, 1);
            blurMat.SetTexture("_RenTex", blurCam.targetTexture);
        }
    }
}
