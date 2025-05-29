using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnobControl : MonoBehaviour
{
    WashingMachineGame wmGame;
    WashingMachineSFX wmSFX;
    GameManager gManager;
    
    float speed = 30;
    public float timerLength = .55f;

    private void Start()
    {
        wmGame = GameObject.FindGameObjectWithTag("WashingMachineGame").GetComponent<WashingMachineGame>();
        wmSFX = GameObject.FindGameObjectWithTag("WashingMachineSFX").GetComponent<WashingMachineSFX>();
        gManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
    }

    void Update()
    {
        transform.Rotate(new Vector3(0,0, Input.GetAxis("Mouse X")) * Time.deltaTime * speed);
        if(transform.eulerAngles.z >= 260f && transform.eulerAngles.z <= 275f && gManager.currentDay == 1)
        {
            timerLength -= Time.deltaTime;
        }
        else if(gManager.currentDay == 2 && transform.eulerAngles.z >= 75 && transform.eulerAngles.z <= 110)
        {
            timerLength -= Time.deltaTime;
        }
        else
        {
            timerLength = .55f;
        }

        if(timerLength <= 0f)
        {
            wmGame.EndWashingMachineGame();
            wmSFX.WashingMachineSound();
        }
    }
}
