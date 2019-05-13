using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TagScript : MonoBehaviour
{
    private static string firstLeg, secondLeg, thirdLeg;
    private bool drag = false;
    private Vector3 first6, first8, first10, fixedFirst, fixedSecond, fixedThird;
    public GameObject tryAgain, successPanel;

    void Start()
    {
        first6 = new Vector3(7.66F, 1.71F);
        first8 = new Vector3(7.66F, 0.73F);
        first10 = new Vector3(7.66F, -0.22F);
        fixedFirst = new Vector3(-5.16F, -3.43F);
        fixedSecond = new Vector3(-0.58F, -3.12F);
        fixedThird = new Vector3(3.54F, -3.22F);
        firstLeg = null;
        secondLeg = null;
        thirdLeg = null;
        drag = false;
    }

    void Update()
    {

    }

    private bool isInFirstLeg(float x, float y)
    {
        return x > -5.68F && x < -4.64F && y > -4.02F && y < 0.02F;
    }

    private bool isInSecondLeg(float x, float y)
    {
        return x > -1.09F && x < 0.06F && y > -3.58F && y < -1.12F;
    }

    private bool isInThirdLeg(float x, float y)
    {
        return x > 2.92F && x < 4.08F && y > -3.68F && y < -0.36F;
    }

    private void ClearOldData()
    {
        if (this.gameObject.name == firstLeg)
        {
            firstLeg = null;
        }
        else if (this.gameObject.name == secondLeg)
        {
            secondLeg = null;
        }
        else if (this.gameObject.name == thirdLeg)
        {
            thirdLeg = null;
        }
    }

    private void ReturnAll()
    {
        GameObject.Find("6cm-tag").transform.position = first6;
        GameObject.Find("8cm-tag").transform.position = first8;
        GameObject.Find("10cm-tag").transform.position = first10;
    }

    private void ClearAllData()
    {
        firstLeg = null;
        secondLeg = null;
        thirdLeg = null;
    }

    public void CheckValues()
    {
        ReturnAll();

        if (firstLeg == "10cm-tag" && secondLeg == "6cm-tag" && thirdLeg == "8cm-tag")
        {
            successPanel.SetActive(true);
        }
        else
        {
            tryAgain.SetActive(true);
        }

        ClearAllData();
    }

    private void ReturnToOldPosition(string objName)
    {
        if (objName == "6cm-tag")
        {
            transform.position = first6;
        }
        else if (objName == "8cm-tag")
        {
            transform.position = first8;
        }
        else if (objName == "10cm-tag")
        {
            transform.position = first10;
        }
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

    private void LocateObject()
    {
        string objectName = this.gameObject.name;
        Vector3 current = this.transform.position;

        if (isInFirstLeg(current.x, current.y) && firstLeg == null)
        {
            transform.position = fixedFirst;
            firstLeg = objectName;
        }
        else if (isInSecondLeg(current.x, current.y) && secondLeg == null)
        {
            transform.position = fixedSecond;
            secondLeg = objectName;
        }
        else if (isInThirdLeg(current.x, current.y) && thirdLeg == null)
        {
            transform.position = fixedThird;
            thirdLeg = objectName;
        }
        else
        {
            ReturnToOldPosition(objectName);
        }
    }

    void OnMouseUp()
    {
        ClearOldData();

        LocateObject();

        drag = false;
    }
}
