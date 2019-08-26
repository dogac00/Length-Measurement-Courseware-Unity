using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Analytics;

public class HoldingHand : MonoBehaviour
{
    private Camera _mainCamera;

    public static bool Enabled { get; private set; }

    private static GameObject _instance;

    // Start is called before the first frame update
    void Start()
    {
        _mainCamera = Camera.main;
        _instance = Finder.FindObjectByName(nameof(HoldingHand));
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

        if (_instance == null) _instance = Finder.FindObjectByName(nameof(HoldingHand));

        _instance.SetActive(true);

        Enabled = true;
    }

    public static void Disable()
    {
        Cursor.visible = true;

        if (_instance == null) _instance = Finder.FindObjectByName(nameof(HoldingHand));

        _instance.SetActive(false);

        Enabled = false;
    }
}
