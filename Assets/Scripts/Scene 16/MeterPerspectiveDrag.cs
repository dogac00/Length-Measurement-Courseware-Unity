using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeterPerspectiveDrag : MonoBehaviour
{
    private bool drag = false;

    public GameObject HoldingHand;

    void Start()
    {
        drag = false;
    }

    void OnMouseDown()
    {
        Cursor.visible = false;
        HoldingHand.SetActive(true);

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
            HoldingHand.transform.position = new Vector3(newPos.x, newPos.y, -1);
        }
    }

    void OnMouseUp()
    {
        Cursor.visible = true;
        HoldingHand.SetActive(false);

        drag = false;
    }
}

public enum CursorMode
{
    Hold, Hover, None
}