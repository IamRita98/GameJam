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
    public MusicPlayer musicPlayer;

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
        StartCoroutine(musicPlayer.StartFade(GameObject.FindGameObjectWithTag("MusicPlayer").GetComponent<AudioSource>()));
        StartCoroutine(FadeOutThenIn());
    }

    IEnumerator FadeOutThenIn()
    {
        screenFade.Fade();
        yield return new WaitForSeconds(3);
        gManager.NewDay();
        yawnHasPlayed = false;
        screenFade.Fade();
        yield return new WaitForSeconds(1);
        StartCoroutine(musicPlayer.StartFade(GameObject.FindGameObjectWithTag("MusicPlayer").GetComponent<AudioSource>()));
        playerCont.playerCanMove = true;
    }
    
}
