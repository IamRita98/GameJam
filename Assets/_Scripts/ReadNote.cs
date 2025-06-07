using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReadNote : MonoBehaviour
{
    public GameObject noteText;
    public GameObject note;
    bool noteIsActive = false;
    PlayerCont playerCont;

    private void Start()
    {
        playerCont = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerCont>();
    }

    private void Update()
    {
        if(noteIsActive && Input.GetKeyDown(KeyCode.Escape))
        {
            noteText.SetActive(false);
            noteIsActive = false;
            playerCont.playerCanMove = true;
        }
    }

    public void ShowNote()
    {
        note.SetActive(false);
        noteText.SetActive(true);
        noteIsActive = true;
        playerCont.playerCanMove = false;
    }
}
