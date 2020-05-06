using UnityEngine;

public class RotationIconScript : MonoBehaviour
{
    public GameObject meter;

    void OnMouseDrag()
    {
        ModeScript.rotationMode = true;

        var mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        var difference = mousePos - meter.transform.position;

        difference.Normalize();

        var degreeZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;

        meter.transform.rotation = Quaternion.Euler(0, 0, degreeZ);
    }
}
