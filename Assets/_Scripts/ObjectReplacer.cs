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
            OldGO();
            NewGO();
        }
    }

    private void OldGO()
    {
        if (oldGO == null) return;
        oldGO.SetActive(false);
    }

    private void NewGO()
    {
        if (newGO == null) return;
        newGO.SetActive(true);
    }
}
