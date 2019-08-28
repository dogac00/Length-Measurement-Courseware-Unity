using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Hammer : DragToBoxObject, ICheckable
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
            this.transform.position = new Vector3(-0.62f, -2.52f, 0);
        }
        else
        {
            base.GoBack();
        }
    }
}
