using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightSwitchController : MonoBehaviour
{
    public GameObject[] lightSources;
    bool lightSwitchesAreOn = true;
    public float brightness;

    public void ToggleLightSwitch()
    {
        foreach (GameObject lightSource in lightSources)
        {
            Light light = lightSource.GetComponent<Light>();
            if(light.intensity == 0)
            {
                light.intensity = brightness;
            }
            else
            {
                light.intensity = 0;
            }
        }
    }
}
