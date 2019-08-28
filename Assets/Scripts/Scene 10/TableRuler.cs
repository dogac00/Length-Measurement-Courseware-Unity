using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TableRuler : HoveringDraggableObject
{
    protected override void OnMouseUp()
    {
        base.OnMouseUp();

        base.GoBack();
    }
}
