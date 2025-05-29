using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class SandwichParts : MonoBehaviour, IPointerClickHandler
{
    static int partsTouching = 0;
    SandwichGame sandwichGame;
    bool partHasBeenMoved = false;

    public AudioSource sandwichSlapSFX;

    private void Start()
    {
        sandwichGame = GameObject.FindGameObjectWithTag("SandwichGame").GetComponent<SandwichGame>();
    }

    private void Update()
    {
        if(partsTouching == 5)
        {
            sandwichGame.EndSandwichGame();
            partsTouching = 0;
        }
    }

    public void OnPointerClick(PointerEventData pointerEventData)
    {
        if (partHasBeenMoved) return;
        partHasBeenMoved = true;
        transform.localPosition = Vector3.zero;
        partsTouching++;
        sandwichSlapSFX.Play();
    }
}
