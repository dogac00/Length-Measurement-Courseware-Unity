using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RulerDrag : DraggableObject
{
    protected override void OnMouseUp()
    {
        base.OnMouseUp();

        base.GoBack();
    }
}
