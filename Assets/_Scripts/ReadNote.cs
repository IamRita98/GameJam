using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReadNote : MonoBehaviour
{
    public GameObject noteText;
    public GameObject note;
    public bool noteIsActive = false;
    PlayerCont playerCont;

    private void Start()
    {
        playerCont = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerCont>();
    }

    private void Update()
    {
        if(noteIsActive && Input.GetKeyDown(KeyCode.Escape))
        {
            note.SetActive(false);
            noteText.SetActive(false);
            noteIsActive = false;
            playerCont.playerCanMove = true;
        }
    }

    public void ShowNote()
    {
        
        noteText.SetActive(true);
        noteIsActive = true;
        playerCont.playerCanMove = false;
    }
}
