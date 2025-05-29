using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WashingMachineGame : MonoBehaviour
{
    PlayerCont playerCont;
    GameManager gManage;
    GameObject plyr;
    public GameObject[] washingMachineUI;
    bool washingMachineGameIsActive;
    private void Start()
    {
        plyr = GameObject.FindGameObjectWithTag("Player");
        playerCont = plyr.GetComponent<PlayerCont>();
        gManage = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
    }

    private void Update()
    {
        if (washingMachineGameIsActive && Input.GetKeyDown(KeyCode.Escape))
        {
            CloseWashingMachineGame();
        }
    }

    public void StartWashingMachineGame()
    {
        playerCont.playerCanMove = false;
        washingMachineUI[gManage.currentDay - 1].SetActive(true);
        washingMachineGameIsActive = true;
        if(gManage.currentDay == 3)
        {
            Cursor.lockState = CursorLockMode.Confined;
        }
    }

    public void EndWashingMachineGame()
    {
        playerCont.playerCanMove = true;
        washingMachineUI[gManage.currentDay - 1].SetActive(false);
        gManage.washingMachineStarted = true;
        if(gManage.currentDay == 3)
        {
            Cursor.lockState = CursorLockMode.Locked;
        }
    }

    private void CloseWashingMachineGame()
    {
        playerCont.playerCanMove = true;
        washingMachineUI[gManage.currentDay - 1].SetActive(false);
        if (gManage.currentDay == 3)
        {
            Cursor.lockState = CursorLockMode.Locked;
        }
    }
}
