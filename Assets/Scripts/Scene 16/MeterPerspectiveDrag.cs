using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeterPerspectiveDrag : DraggableObject
{
    protected override void OnMouseEnter()
    {
        PerspectiveHoveringHand.Enable();
    }

    protected override void OnMouseExit()
    {
        PerspectiveHoveringHand.Disable();
    }

    protected override void OnMouseDrag()
    {
        if (base.IsDragging)
        {
            Vector3 mousePosition = Input.mousePosition;

            Vector3 currentPos = new Vector3(mousePosition.x + 0.5F, mousePosition.y, 10);

            Vector3 newPos = Camera.main.ScreenToWorldPoint(currentPos);

            this.transform.position = newPos;
        }
    }
}