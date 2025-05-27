using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ScreenFade : MonoBehaviour
{
    public CanvasGroup canvasgroup;
    float currentAlpha;
    float desiredAlpha;
    public float fadeSpeed;
    public bool startFading;

    void Start()
    {
        currentAlpha = 0;
    }

    private void Update()
    {
        currentAlpha = Mathf.MoveTowards(currentAlpha, desiredAlpha, fadeSpeed * Time.deltaTime);

        canvasgroup.alpha = currentAlpha;

        //This is just to test the script in the Unity editor, from script we can just call Fade() instead of making startFading true
        if (startFading)
        {
            Fade();
        }
    }

    public void Fade()
    {
        startFading = false;
        if(currentAlpha == 0)
        {
            desiredAlpha = 1;
        }
        else
        {
            desiredAlpha = 0;
        }
    }
}
