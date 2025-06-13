using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    AudioSource audioSource;
    public AudioClip day1Mus;
    public AudioClip day2Mus;
    public AudioClip day3Mus;
    GameManager gManage;

    private void Start()
    {
        gManage = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        audioSource = this.gameObject.GetComponent<AudioSource>();
    }

    private void Update()
    {
        if(gManage.currentDay == 2 && audioSource.clip != day2Mus)
        {
            audioSource.Stop();
            audioSource.clip = day2Mus;
            audioSource.Play();
        }
        else if(gManage.currentDay == 3 && audioSource.clip != day3Mus)
        {
            audioSource.Stop();
            audioSource.clip = day3Mus;
            audioSource.Play();
        }
    }

    public IEnumerator StartFade(AudioSource audioSource)
    {
        float currentTime = 0;
        float duration = 2;
        float startVolume;
        float destVolume;
        if(audioSource.volume == 0)
        {
            startVolume = 0;
            if(gManage.currentDay > 1)
            {
                destVolume = .2f;
            }
            else
            {
                destVolume = .3f;
            }
        }
        else
        {
            startVolume = .3f;
            destVolume = 0;
        }
        while(currentTime < duration)
        {
            currentTime += Time.deltaTime;
            audioSource.volume = Mathf.Lerp(startVolume, destVolume, currentTime / duration);
            yield return null;
        }
        yield break;
    }
}
