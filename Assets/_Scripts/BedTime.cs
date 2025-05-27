using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BedTime : MonoBehaviour
{
    GameManager gManager;
    PlayerCont playerCont;
    public AudioSource yawnSFX;
    ScreenFade screenFade;
    bool yawnHasPlayed = false;

    private void Start()
    {
        gManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        screenFade = GameObject.FindGameObjectWithTag("Fade").GetComponent<ScreenFade>();
        playerCont = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerCont>();
    }

    private void Update()
    {
        if (gManager.ReadyToSleep() && !yawnHasPlayed)
        {
            yawnSFX.Play();
            yawnHasPlayed = true;
        }
    }

    public void Sleep()
    {
        playerCont.playerCanMove = false;
        StartCoroutine(FadeOutThenIn());
        gManager.NewDay();
    }

    IEnumerator FadeOutThenIn()
    {
        screenFade.Fade();
        yield return new WaitForSeconds(3);
        screenFade.Fade();
        yield return new WaitForSeconds(1);
        playerCont.playerCanMove = true;
    }
}
