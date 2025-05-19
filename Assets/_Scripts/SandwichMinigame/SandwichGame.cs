using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SandwichGame : MonoBehaviour
{
    PlayerCont playerCont;
    GameManager gameManager;

    public GameObject bread1;
    public GameObject bread2;
    public GameObject meat;
    public GameObject cheese;
    public GameObject lettuce;
    public GameObject sandwichUI;

    public int sandwichPartsStacked = 0;

    private void Start()
    {
        playerCont = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerCont>();
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
    }

    public void StartSandwichGame()
    {
        playerCont.playerCanMove = false;
        Cursor.lockState = CursorLockMode.Confined;
        sandwichUI.SetActive(true);
    }

    public void EndSandwichGame()
    {
        playerCont.playerCanMove = true;
        Cursor.lockState = CursorLockMode.Locked;
        sandwichUI.SetActive(false);
        gameManager.sandwichMade = true;
    }
}
