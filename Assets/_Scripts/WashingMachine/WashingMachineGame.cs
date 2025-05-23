using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WashingMachineGame : MonoBehaviour
{
    PlayerCont playerCont;
    GameManager gManage;
    GameObject plyr;
    public GameObject washingMachineUI;

    private void Start()
    {
        plyr = GameObject.FindGameObjectWithTag("Player");
        playerCont = plyr.GetComponent<PlayerCont>();
        gManage = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
    }

    public void StartWashingMachineGame()
    {
        playerCont.playerCanMove = false;
        washingMachineUI.SetActive(true);
    }

    public void EndWashingMachineGame()
    {
        playerCont.playerCanMove = true;
        washingMachineUI.SetActive(false);
        gManage.washingMachineStarted = true;
    }
}
