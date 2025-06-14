using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int currentDay = 1;
    HousePuzzle hP;
    public bool sandwichMade = false;
    public bool slidingPuzzleSolved = false;
    public bool washingMachineStarted = false;
    public bool gameHasEnded = false;
    public GameObject fadeScreen;
    public GameObject gameEndText;

    public bool isInDevTool;
    //DevMenu devMenu;

    private void Start()
    {
        //devMenu = GameObject.FindGameObjectWithTag("Devmenu").GetComponent<DevMenu>();
        hP = GameObject.FindGameObjectWithTag("slidingPuzzle").GetComponent<HousePuzzle>();
    }

    private void Update()
    {
        //if (devMenu.uiIsActive) isInDevTool = true;
        //else isInDevTool = false;
        if (currentDay >= 4 && !gameHasEnded)
        {
            EndGame();
        }
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
        hP.cSprites();
    }

    private void EndGame()
    {
        gameHasEnded = true;
        CanvasGroup fader = fadeScreen.GetComponent<CanvasGroup>();
        fader.alpha = 1;
        gameEndText.SetActive(true);
    }
}
