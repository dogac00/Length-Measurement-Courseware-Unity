using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class HoveringHand : MonoBehaviour
{
    private Camera _mainCamera;

    protected static GameObject _instance;

    // Start is called before the first frame update
    void Start()
    {
        _mainCamera = Camera.main;
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        Vector3 mousePosition = _mainCamera.ScreenToWorldPoint(Input.mousePosition);
        this.transform.position = new Vector3(mousePosition.x, mousePosition.y);
    }

    public static void Enable()
    {
        if (HoldingHand.Enabled) return;

        Cursor.visible = false;

        if (_instance == null) _instance = Finder.FindObjectByName(nameof(HoveringHand));

        _instance.SetActive(true);
    }

    public static void Disable()
    {
        if (HoldingHand.Enabled) return;

        Cursor.visible = true;

        if (_instance == null) _instance = Finder.FindObjectByName(nameof(HoveringHand));

        _instance.SetActive(false);
    }
}
