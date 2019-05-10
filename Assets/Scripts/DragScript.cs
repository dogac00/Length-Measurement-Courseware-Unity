using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragScript : MonoBehaviour
{
    public bool isinBox;
    private Vector3 curPos;
    private Vector3 firstPos;
    private bool drag = false;

    void Start()
    {
        firstPos = this.transform.position;
        isinBox = false;
    }

    void Update()
    {
        curPos = this.transform.position;
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

        if (isinBox)
        {
            if (this.name == "compass")
            {
                this.transform.position = new Vector3(-1.72f, -2.52f, 0);
            }

            else if (this.name == "ruler")
            {
                this.transform.position = new Vector3(-0.64f, -2.58f, 0);
            }

            else if (this.name == "hammer")
            {
                this.transform.position = new Vector3(0.02f, -2.64f, 0);
            }

            else if (this.name == "meter")
            {
                this.transform.position = new Vector3(-0.40f, -2.75f, 0);
            }
        }

        else
        {
            this.transform.position = new Vector3(firstPos.x, firstPos.y, 0);
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        isinBox = true;
    }

    void OnTriggerExit2D(Collider2D col)
    {
        isinBox = false;
    }
}
