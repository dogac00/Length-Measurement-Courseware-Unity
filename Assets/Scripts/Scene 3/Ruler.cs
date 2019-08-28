using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ruler : DragToBoxObject, ICheckable
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
            this.transform.position = new Vector3(-0.84f, -2.58f, 0);
        }
        else
        {
            base.GoBack();
        }
    }
}
