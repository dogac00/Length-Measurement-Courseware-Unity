using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Draggable : MonoBehaviour
{
    private Camera _mainCamera;

    private Vector3 _firstPosition;

    protected virtual void Start()
    {
        _mainCamera = Camera.main;
        _firstPosition = this.transform.position;
    }

    protected virtual void OnMouseDrag()
    {
        Vector3 currentPos = _mainCamera.ScreenToWorldPoint(Input.mousePosition);
        this.transform.position = new Vector3(currentPos.x + 0.4F, currentPos.y, 0);
        print(this.transform.position);
    }

    protected void GoBack()
    {
        this.transform.position = new Vector3(_firstPosition.x, _firstPosition.y);
    }
}
