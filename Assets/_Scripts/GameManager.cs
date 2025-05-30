using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int currentDay = 1;

    public bool sandwichMade = false;
    public bool slidingPuzzleSolved = false;
    public bool washingMachineStarted = false;

    public bool isInDevTool;
    DevMenu devMenu;

    private void Start()
    {
        devMenu = GameObject.FindGameObjectWithTag("Devmenu").GetComponent<DevMenu>();
    }

    private void Update()
    {
        if (devMenu.uiIsActive) isInDevTool = true;
        else isInDevTool = false;
    }

    public bool ReadyToSleep ()
    {
        if(sandwichMade && slidingPuzzleSolved && washingMachineStarted)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public void NewDay()
    {
        sandwichMade = false;
        slidingPuzzleSolved = false;
        washingMachineStarted = false;
        currentDay++;
    }
}
