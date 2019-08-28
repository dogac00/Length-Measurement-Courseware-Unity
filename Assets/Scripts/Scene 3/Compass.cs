using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Compass : DragToBoxObject, ICheckable
{
    public bool Check()
    {
        return !inBox;
    }

    protected override void OnMouseUp()
    {
        base.OnMouseUp();

        if (inBox)
        {
            this.transform.position = new Vector3(-1.92f, -2.52f, 0);
        }
        else
        {
            base.GoBack();
        }
    }
}
