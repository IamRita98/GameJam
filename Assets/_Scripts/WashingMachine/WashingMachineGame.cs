using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WashingMachineGame : MonoBehaviour
{
    PlayerCont playerCont;
    GameManager gManage;
    GameObject plyr;
    public GameObject washingMachineUI;
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
        washingMachineUI.SetActive(true);
        washingMachineGameIsActive = true;
    }

    public void EndWashingMachineGame()
    {
        playerCont.playerCanMove = true;
        washingMachineUI.SetActive(false);
        gManage.washingMachineStarted = true;
    }

    private void CloseWashingMachineGame()
    {
        playerCont.playerCanMove = true;
        washingMachineUI.SetActive(false);
    }
}
