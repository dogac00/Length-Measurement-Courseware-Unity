using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeterDragScript : DragandDrop
{
    public GameObject dragHand;

    void OnMouseDown()
    {
        if (ModeScript.isInDragMode)
        {
            drag = true;
        }
    }

    void Update()
    {
        if (ModeScript.isInDragMode)
        {
            Vector3 mousePosition = mainCamera.ScreenToWorldPoint(Input.mousePosition);

            if (!Cursor.visible)
            {
                dragHand.transform.position = new Vector3(mousePosition.x, mousePosition.y);
            }

            SetCursorVisibility(mousePosition);
        }
    }

    private void SetCursorVisibility(Vector3 mousePosition)
    {
        if (mousePosition.x > 6.1F || mousePosition.y > 2.87F)
        {
            Cursor.visible = true;
        }
        else
        {
            Cursor.visible = false;
        }
    }
}
