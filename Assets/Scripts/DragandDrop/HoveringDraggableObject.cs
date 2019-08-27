using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoveringDraggableObject : DraggableObject
{
    private GameObject _hover, _hold;

    void Awake()
    {
        _hover = Finder.FindObjectByTag(HandTags.Hover);
        _hold = Finder.FindObjectByTag(HandTags.Hold);
    }

    protected override void OnMouseDown()
    {
        base.OnMouseDown();

        if (!_hold.activeSelf)
        {
            _hover.SetActive(false);
        }

        Cursor.visible = false;

        _hold.SetActive(true);
    }

    protected override void OnMouseUp()
    {
        base.OnMouseUp();

        _hold.SetActive(false);

        Cursor.visible = false;

        _hover.SetActive(true);
    }

    protected virtual void OnMouseEnter()
    {
        if (_hold.activeSelf) return;

        Cursor.visible = false;

        _hover.SetActive(true);
    }

    protected virtual void OnMouseExit()
    {
        if (_hold.activeSelf) return;

        Cursor.visible = true;

        _hover.SetActive(false);
    }
}
