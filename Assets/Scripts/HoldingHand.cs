using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;

public class HoldingHand : MonoBehaviour
{
    private Camera _mainCamera;

    // Start is called before the first frame update
    void Start()
    {
        _mainCamera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mousePosition = _mainCamera.ScreenToWorldPoint(Input.mousePosition);
        this.transform.position = new Vector3(mousePosition.x, mousePosition.y);
    }

    public static void Enable()
    {
        Cursor.visible = false;

        GameObject thisObject = Finder.FindObjectByName("HoldingHand");

        thisObject.SetActive(true);
    }

    public static void Disable()
    {
        Cursor.visible = true;

        GameObject thisObject = Finder.FindObjectByName("HoldingHand");

        thisObject.SetActive(false);
    }
}
