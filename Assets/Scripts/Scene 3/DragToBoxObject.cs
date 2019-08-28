using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragToBoxObject : HoveringDraggableObject
{
    protected bool inBox;

    void OnTriggerEnter2D(Collider2D col)
    {
        inBox = true;
    }

    void OnTriggerExit2D(Collider2D col)
    {
        inBox = false;
    }
}