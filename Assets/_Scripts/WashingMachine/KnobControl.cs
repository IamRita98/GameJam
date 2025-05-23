using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnobControl : MonoBehaviour
{
    WashingMachineGame wmGame;
    float speed = 30;
    float timerLength = .35f;

    private void Start()
    {
        wmGame = GameObject.FindGameObjectWithTag("WashingMachineGame").GetComponent<WashingMachineGame>();
    }

    void Update()
    {
        transform.Rotate(new Vector3(0,0, Input.GetAxis("Mouse X")) * Time.deltaTime * speed);
        if(transform.eulerAngles.z >= 260f && transform.eulerAngles.z <= 275f)
        {
            timerLength -= Time.deltaTime;
        }
        else
        {
            timerLength = .35f;
        }

        if(timerLength <= 0f)
        {
            wmGame.EndWashingMachineGame();
        }
    }
}
