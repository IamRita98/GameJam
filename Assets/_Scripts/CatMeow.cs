using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatMeow : MonoBehaviour
{
    AudioSource aSource;
    public AudioClip cat1Meow;
    public AudioClip cat2Meow;
    GameManager gManage;

    private void Start()
    {
        aSource = gameObject.GetComponent<AudioSource>();
        gManage = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
    }

    private void Update()
    {
        if(gManage.currentDay >= 3)
        {
            aSource.clip = cat2Meow;
            aSource.volume = .7f;
        }
        else
        {
            aSource.clip = cat1Meow;
        }
    }

    public void Meow()
    {
        aSource.Play();
    }
}
