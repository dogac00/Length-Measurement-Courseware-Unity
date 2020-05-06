using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnMeterScript : MonoBehaviour
{
    public GameObject rotateIcon;
    public GameObject meter;
    public GameObject pencil, dragHand;
    public GameObject meterLeft, meterRight;

    private Camera mainCamera;

    void Start()
    {
        mainCamera = Camera.main;
    }

    void LateUpdate()
    {
        var close = IsMouseClose();
        var mousePos = mainCamera.ScreenToWorldPoint(Input.mousePosition);

        if (close)
        {
            ModeScript.rotationMode = true;
            rotateIcon.SetActive(true); 
            
            rotateIcon.transform.position = new Vector3(mousePos.x, mousePos.y);

            if (pencil.activeSelf)
                pencil.SetActive(false);
            if (dragHand.activeSelf)
                dragHand.SetActive(false);
        }
        else
        {
            ModeScript.rotationMode = false;
            rotateIcon.SetActive(false);
            
            if (ModeScript.isInDragMode)
                dragHand.SetActive(true);
            if (ModeScript.isInDrawMode)
                pencil.SetActive(true);
        }

        if (close && Input.GetMouseButtonDown(0))
        {
            var difference = mousePos - meter.transform.position;

            difference.Normalize();

            var degreeZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;

            meter.transform.rotation = Quaternion.Euler(0, 0, degreeZ);
        }
    }

    bool IsMouseClose()
    {
        var mousePos = mainCamera.ScreenToWorldPoint(Input.mousePosition);

        if (mousePos.IsClose(meterLeft.transform.position, 0.5F))
            return true;
        if (mousePos.IsClose(meterRight.transform.position, 0.5F))
            return true;

        return false;
    }
}
