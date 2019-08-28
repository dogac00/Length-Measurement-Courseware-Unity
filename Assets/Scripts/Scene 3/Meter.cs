using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meter : DragToBoxObject, ICheckable
{
    public bool Check()
    {
        return inBox;
    }

    protected override void OnMouseUp()
    {
        base.OnMouseUp();

        if (inBox)
        {
            this.transform.position = new Vector3(-0.60f, -2.75f, 0);
        }
        else
        {
            base.GoBack();
        }
    }
}
