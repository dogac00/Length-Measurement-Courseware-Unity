using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Table : DraggableObject
{
    public static string firstShelf, secondShelf, thirdShelf;
    private GameObject winPanel, tryAgain;

    private string objectName;

    void Awake()
    {
        winPanel = Finder.FindObjectByTag(PanelTag.Success);
        tryAgain = Finder.FindObjectByTag(PanelTag.TryAgain);
    }

    protected override void Start()
    {
        firstShelf = secondShelf = thirdShelf = null;

        base.Start();
    }

    private bool isInFirst(float x, float y)
    {
        return x > -7.5F && x < -5.60F && y > -0.52F && y < 0.32F;
    }

    private bool isInSecond(float x, float y)
    {
        return x > -2.80F && x < 0.20F && y > -0.36F && y < 0.24F;
    }

    private bool isInThird(float x, float y)
    {
        return x > 2.48F && x < 5.52F && y > -0.40F && y < 0.16F;
    }

    protected override void OnMouseUp()
    {
        base.OnMouseUp();

        Vector3 currentPosition = this.transform.position;
        objectName = this.gameObject.name;

        FindAndSetNull(objectName);

        if (isInFirst(currentPosition.x, currentPosition.y) && firstShelf == null)
        {
            firstShelf = objectName;
        }

        else if (isInSecond(currentPosition.x, currentPosition.y) && secondShelf == null)
        {
            secondShelf = objectName;
        }

        else if (isInThird(currentPosition.x, currentPosition.y) && thirdShelf == null)
        {
            thirdShelf = objectName;
        }

        else
        {
            FindAndSetNull(objectName);
            base.GoBack();
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
            winPanel.SetActive(true);
        }
        else
        {
            tryAgain.SetActive(true);
        }
    }
}
