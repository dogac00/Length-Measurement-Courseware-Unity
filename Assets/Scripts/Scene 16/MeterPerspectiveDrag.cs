using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeterPerspectiveDrag : HoveringDraggable
{
    protected override void OnMouseDrag()
    {
        Vector3 mousePosition = Input.mousePosition;

        Vector3 currentPos = new Vector3(mousePosition.x + 0.5F, mousePosition.y, 10);

        Vector3 newPos = Camera.main.ScreenToWorldPoint(currentPos);

        this.transform.position = newPos;
    }
}