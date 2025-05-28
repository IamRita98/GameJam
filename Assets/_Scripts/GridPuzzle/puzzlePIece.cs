using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class puzzlePIece : MonoBehaviour
{
    public UnityEvent<GameObject> onClicked;

    private void OnMouseDown()
    {
        onClicked?.Invoke(gameObject);
    }
}
