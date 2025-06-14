using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class puzzlePIece : MonoBehaviour
{
    public int gridX; // X position in the grid
    public int gridY; // Y position in the grid
    public int correctX; 
    public int correctY;
    public UnityEvent<GameObject> onClick;

    private void OnMouseDown()
    {
        onClick?.Invoke(gameObject);
    }
    private void Awake()
    {
        if (onClick == null)
            onClick = new UnityEvent<GameObject>();
    }
}
