using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawCode : MonoBehaviour
{
    public GameObject Pencil;
    public GameObject[] Parts, Lines, Buttons, Panels;
    public GameObject Table, SuccessPanel, WrongPlacePanel;
    public Vector3 pencilPosition;
    public Animator Bottom, Left;

    public static bool isDrawing;

    private int drawNumber;

    // Start is called before the first frame update
    void Start()
    {
        drawNumber = 0;
        isDrawing = false;
        Bottom.enabled = Left.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        pencilPosition = Pencil.transform.position;

        if (Input.GetMouseButtonDown(0))
        {
            if (isRightPositionBottom(pencilPosition.x, pencilPosition.y))
            {
                isDrawing = true;
                StartCoroutine(DrawFromBottom());
                Bottom.Play("BottomDrawAnimation");
                Bottom.enabled = true;
                drawNumber++;

                CheckDrawings();
            }
            else if (isRightPositionLeft(pencilPosition.x, pencilPosition.y))
            {
                isDrawing = true;
                StartCoroutine(DrawFromLeft());
                Left.Play("LeftDrawAnimation");
                Left.enabled = true;
                drawNumber++;

                CheckDrawings();
            }
            else if (isInsideTable(pencilPosition.x, pencilPosition.y) && !Cursor.visible)
            {
                ModeScript.isInPanelMode = true;
                WrongPlacePanel.SetActive(true);
            }
        }
    }

    private void CheckDrawings()
    {
        if (drawNumber == 2)
        {
            StartCoroutine(CutTable());
        }
    }

    private void SetPartsActive()
    {
        Table.SetActive(false);

        foreach (var item in Lines)
        {
            item.SetActive(false);
        }

        foreach (var item in Parts)
        {
            item.SetActive(true);
        }

        foreach (var item in Buttons)
        {
            item.SetActive(false);
        }

        foreach (var item in Panels)
        {
            item.SetActive(false);
        }
    }

    IEnumerator CutTable()
    {
        yield return new WaitForSeconds(3.6F);

        ModeScript.isInDragMode = false;
        ModeScript.isInDrawMode = false;
        ModeScript.isInPanelMode = true;

        Cursor.visible = true;

        SetPartsActive();

        yield return new WaitForSeconds(2);

        StartCoroutine(ShowSuccessPanel());
    }

    IEnumerator ShowSuccessPanel()
    {
        float time = 1;
        float timemax = time;

        SuccessPanel.SetActive(true);
        SuccessPanel.transform.localScale = Vector3.zero;

        while (time > 0)
        {
            time -= Time.deltaTime;
            yield return new WaitForSeconds(Time.deltaTime);
            SuccessPanel.transform.localScale = Vector3.Lerp(Vector3.zero, Vector3.one, (timemax - time) / timemax);
        }
    }

    IEnumerator DrawFromLeft()
    {
        float curY = 0.63F, curX = -4.73F, targetX = 2.98F;
        Pencil.transform.position = new Vector3(curX, curY);

        while (curX < targetX)
        {
            curX += 0.096F;
            Pencil.transform.position = new Vector3(curX, curY);
            yield return new WaitForSeconds(0.01F);
        }

        isDrawing = false;
    }

    IEnumerator DrawFromBottom()
    {
        float curY = -2.28F, targetY = 1.65F, curX = 0.46F;
        Pencil.transform.position = new Vector3(curX, curY);

        while (curY < targetY)
        {
            curY += 0.045F;
            Pencil.transform.position = new Vector3(curX, curY);
            yield return new WaitForSeconds(0.01F);
        }
        
        isDrawing = false;
    }

    private bool isRightPositionBottom(float x, float y)
    {
        return x > -0.24F && x < 0.54F && y > -2.41F && y < -2.19F;
    }

    private bool isRightPositionLeft(float x, float y)
    {
        return x > -4.80F && x < -4.53F && y > 0.39F && y < 0.74F;
    }

    private bool isInsideTable(float x, float y)
    {
        return x > -5 && x < 3.24F && y > -2.70F && y < 1.92F;
    }
}
