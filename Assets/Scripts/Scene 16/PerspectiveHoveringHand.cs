using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PerspectiveHoveringHand : HoveringHand
{
    protected override void Update()
    {
        Vector3 mousePosition = Input.mousePosition;

        Vector3 currentPos = new Vector3(mousePosition.x + 0.5F, mousePosition.y, 10);

        Vector3 newPos = Camera.main.ScreenToWorldPoint(currentPos);

        this.transform.position = newPos;
    }

    public static void Enable()
    {
        if (HoldingHand.Enabled) return;

        Cursor.visible = false;

        if (_instance == null) _instance = Finder.FindObjectByName(nameof(HoveringHand));

        _instance.SetActive(true);
    }

    public static void Disable()
    {
        if (HoldingHand.Enabled) return;

        Cursor.visible = true;

        if (_instance == null) _instance = Finder.FindObjectByName(nameof(HoveringHand));

        _instance.SetActive(false);
    }
}
