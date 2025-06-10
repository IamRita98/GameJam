using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectReplacer : MonoBehaviour
{
    public GameObject oldGO;
    public GameObject newGO;
    public int dayToReplaceOn;

    GameManager gManage;

    private void Start()
    {
        gManage = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
    }

    private void Update()
    {
        if(gManage.currentDay >= dayToReplaceOn)
        {
            oldGO.SetActive(false);
            newGO.SetActive(true);
        }
    }
}
