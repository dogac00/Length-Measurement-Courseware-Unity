using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RulerDrag : MonoBehaviour
{
    private bool drag;
    private Vector3 firstPosition;

    void Start()
    {
        drag = false;
        firstPosition = this.transform.position;
    }

    void OnMouseDown()
    {
        drag = true;
    }

    void OnMouseDrag()
    {
        if (drag)
        {
            Vector3 currentPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            this.transform.position = new Vector3(currentPos.x, currentPos.y, 0);
        }
    }

    void OnMouseUp()
    {
        drag = false;
        this.transform.position = firstPosition;
    }
}
