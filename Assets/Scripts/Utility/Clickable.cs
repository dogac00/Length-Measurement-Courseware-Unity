using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Clickable : MonoBehaviour
{
    public UnityEvent OnClick;

    void OnMouseDown()
    {
        OnClick.Invoke();
    }
}
