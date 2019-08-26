using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Tag : DraggableObject
{
    private bool _inCollider;
    private string _tag;
    private Collider2D _collider;
    private GameObject _successPanel, _tryAgainPanel;

    public static int Count { get; private set; }

    void Awake()
    {
        _tag = this.GetComponentInChildren<TextMeshProUGUI>().text.RemoveAllWhitespace();
        _successPanel = Finder.FindObjectByTag(PanelTag.Success);
        _tryAgainPanel = Finder.FindObjectByTag(PanelTag.TryAgain);
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        _collider = collider;
        _inCollider = true;

        if (_tag == collider.tag) Count++;
    }

    void OnTriggerExit2D(Collider2D collider)
    {
        _collider = collider;
        _inCollider = false;

        if (_tag == collider.tag) Count--;
    }

    protected override void OnMouseUp()
    {
        base.OnMouseUp();

        if (_inCollider)
        {
            if (_collider.GetComponent<ColliderObject>().IsFull)
            {
                GoBack();
            }
            else
            {
                this.transform.position = _collider.bounds.center;
            }
        }
        else
        {
            GoBack();
        }
    }

    public void Check()
    {
        if (Count == 3) _successPanel.SetActive(true);

        else _tryAgainPanel.SetActive(true);
    }
}
