using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WashingMachineSFX : MonoBehaviour
{
    public AudioSource washingMachineSFX;
    public void WashingMachineSound()
    {
        washingMachineSFX.Play();
    }
}
