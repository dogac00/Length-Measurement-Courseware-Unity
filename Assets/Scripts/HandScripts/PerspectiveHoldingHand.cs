using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PerspectiveHoldingHand : HoldingHand
{
    protected override void Update()
    {
        Vector3 mousePosition = Input.mousePosition;

        Vector3 currentPos = new Vector3(mousePosition.x + 0.5F, mousePosition.y, 10);

        Vector3 newPos = MainCamera.ScreenToWorldPoint(currentPos);

        this.transform.position = newPos;
    }
}
