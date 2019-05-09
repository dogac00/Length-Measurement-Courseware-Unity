using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TableDrag : MonoBehaviour
{
    private bool drag;
    private Vector3 firstPosition;
    public static string firstShelf, secondShelf, thirdShelf;
    private string objectName;

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

    private bool isInFirst(float x, float y)
    {
        return x > -7.5F && x < -5.60F && y > -0.52F && y < 0.32F;
    }

    private bool isInSecond(float x, float y)
    {
        return x > -2.80F && x < -0.40F && y > -0.28F && y < 0.10F;
    }

    private bool isInThird(float x, float y)
    {
        return x > 2.48F && x < 5.52F && y > -0.40F && y < 0.16F;
    }

    void OnMouseUp()
    {
        drag = false;
        Vector3 currentPosition = this.transform.position;
        objectName = this.gameObject.name;

        ClearOldShelf(objectName);

        if (isInFirst(currentPosition.x, currentPosition.y))
        {
            firstShelf = objectName;
        }

        else if (isInSecond(currentPosition.x, currentPosition.y))
        {
            secondShelf = objectName;
        }

        else if (isInThird(currentPosition.x, currentPosition.y))
        {
            thirdShelf = objectName;
        }

        else
        {
            FindAndSetNull(objectName);
            this.transform.position = firstPosition;
        }
    }

    private void ClearOldShelf(string name)
    {
        if (firstShelf == name)
        {
            firstShelf = null;
        }
        else if (secondShelf == name)
        {
            secondShelf = null;
        }
        else if (thirdShelf == name)
        {
            thirdShelf = null;
        }
    }

    private void FindAndSetNull(string name)
    {
        if (firstShelf == name)
        {
            firstShelf = null;
        }
        else if (secondShelf == name)
        {
            secondShelf = null;
        }
        else if (thirdShelf == name)
        {
            thirdShelf = null;
        }
    }

    public void CheckValues()
    {
        if (firstShelf == "table-body-2" && secondShelf == "table-body-3" && thirdShelf == "table-body-1")
        {
            Debug.Log("Success!");
        }
        else
        {
            Debug.Log("Try Again.");
        }
    }
}
