using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PencilScript : MonoBehaviour
{
    private Camera mainCamera;
    private Vector3 mousePosition;

    void Start()
    {
        Cursor.visible = false;
        mainCamera = Camera.main;
    }

    void Update()
    {
        if (ModeScript.isInDrawMode && !DrawCode.isDrawing)
        {
            mousePosition = mainCamera.ScreenToWorldPoint(Input.mousePosition);

            if (!Cursor.visible)
            {
                this.transform.position = new Vector3(mousePosition.x, mousePosition.y);
            }

            SetCursorVisibility();
        }
    }

    private void SetCursorVisibility()
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
