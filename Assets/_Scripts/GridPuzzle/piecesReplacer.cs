using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class piecesReplacer : MonoBehaviour
{
    public GameObject oldGO;
    public GameObject newGO;
    public GameObject newGO2;

    GameManager gManage;

    private void Start()
    {
        gManage = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
    }

    public void changeSprites() { 
      if (gManage.currentDay ==2)
        {
            oldGO.SetActive(false);
            newGO.SetActive(true);
        }
        if (gManage.currentDay == 3)
        {
            newGO.SetActive(false);
            newGO2.SetActive(true);
        }
    }
}
