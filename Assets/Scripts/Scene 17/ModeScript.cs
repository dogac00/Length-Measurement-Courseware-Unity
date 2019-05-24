﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ModeScript : MonoBehaviour
{
    public static bool isInDragMode;
    public static bool isInDrawMode;

    public GameObject drawButton, dragButton;
    public GameObject drawObject, dragObject;

    public Sprite drawButtonActive, dragButtonActive;
    public Sprite drawButtonInactive, dragButtonInactive;

    void Start()
    {
        SetModes(false, true);

        drawButton.GetComponent<Image>().sprite = drawButtonActive;
        dragButton.GetComponent<Image>().sprite = dragButtonInactive;
    }

    private void SetModes(bool dragMode, bool drawMode)
    {
        isInDragMode = dragMode;
        isInDrawMode = drawMode;

        dragObject.SetActive(dragMode);
        drawObject.SetActive(drawMode);
    }

    public void DragModeClick()
    {
        if (!isInDragMode)
        {
            drawButton.GetComponent<Image>().sprite = drawButtonInactive;
            dragButton.GetComponent<Image>().sprite = dragButtonActive;

            SetModes(true, false);
        }
    }

    public void DrawModeClick()
    {
        if (!isInDrawMode)
        {

            drawButton.GetComponent<Image>().sprite = drawButtonActive;
            dragButton.GetComponent<Image>().sprite = dragButtonInactive;

            SetModes(false, true);
        }
    }
}
