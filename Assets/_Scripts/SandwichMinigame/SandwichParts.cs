using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class SandwichParts : MonoBehaviour, IPointerClickHandler
{
    static int partsTouching = 0;
    SandwichGame sandwichGame;


    private void Start()
    {
        sandwichGame = GameObject.FindGameObjectWithTag("SandwichGame").GetComponent<SandwichGame>();
    }

    private void Update()
    {
        if(partsTouching == 5)
        {
            sandwichGame.EndSandwichGame();
        }
    }

    public void OnPointerClick(PointerEventData pointerEventData)
    {
        transform.localPosition = Vector3.zero;
        partsTouching++;
    }
}
