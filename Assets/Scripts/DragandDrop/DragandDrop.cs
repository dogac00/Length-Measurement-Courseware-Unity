using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragandDrop : MonoBehaviour
{
    protected bool drag = false;
    protected Camera mainCamera;

    void Start()
    {
        mainCamera = Camera.main;
        drag = false;
    }

    void OnMouseDown()
    {
        drag = true;
    }

    void OnMouseDrag()
    {
        if (drag)
        {
            Vector3 currentPos = mainCamera.ScreenToWorldPoint(Input.mousePosition);
            this.transform.position = new Vector3(currentPos.x + 0.4F, currentPos.y, 0);
        }
    }

    void OnMouseUp()
    {
        drag = false;
    }
}
