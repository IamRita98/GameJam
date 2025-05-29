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

    public Button btn;

    private void Start()
    {
        plyr = GameObject.FindGameObjectWithTag("Player");
        playerCont = plyr.GetComponent<PlayerCont>();
        gManage = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        btn.onClick.AddListener(EndWashingMachineGame);
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
    }

    public void EndWashingMachineGame()
    {
        playerCont.playerCanMove = true;
        washingMachineUI[gManage.currentDay - 1].SetActive(false);
        gManage.washingMachineStarted = true;
    }

    private void CloseWashingMachineGame()
    {
        playerCont.playerCanMove = true;
        washingMachineUI[gManage.currentDay - 1].SetActive(false);
    }
}
