using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeterPerspectiveDrag : MonoBehaviour
{
    private bool drag = false;

    void Start()
    {
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
            Vector3 currentPos = Input.mousePosition;
            currentPos.z = 10;
            currentPos.x = currentPos.x + 0.5F;
            Vector3 newPos = Camera.main.ScreenToWorldPoint(currentPos);
            this.transform.position = newPos;
        }
    }

    void OnMouseUp()
    {
        drag = false;
    }
}
