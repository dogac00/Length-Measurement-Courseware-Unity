using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class HoveringDraggable : Draggable
{
    private GameObject _hover, _hold;

    protected virtual void Awake()
    {
        _hover = Finder.FindGameObjectOfType<HoveringHand>();
        _hold = Finder.FindGameObjectOfType<HoldingHand>();
    }

    protected void OnMouseDown()
    {
        if (Globals.PanelMode) return;

        if (!_hold.activeSelf)
        {
            _hover.SetActive(false);
        }

        Cursor.visible = false;

        _hold.SetActive(true);
    }

    protected virtual void OnMouseUp()
    {
        if (Globals.PanelMode) return;

        _hold.SetActive(false);

        Cursor.visible = false;

        _hover.SetActive(true);
    }

    protected virtual void OnMouseEnter()
    {
        if (Globals.PanelMode) return;

        if (_hold.activeSelf) return;

        Cursor.visible = false;

        _hover.SetActive(true);
    }

    protected virtual void OnMouseExit()
    {
        if (Globals.PanelMode) return;

        if (_hold.activeSelf) return;

        Cursor.visible = true;

        _hover.SetActive(false);
    }
}
