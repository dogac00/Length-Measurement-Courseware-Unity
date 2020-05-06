using UnityEngine;

public class RotationScript : MonoBehaviour
{
    public GameObject objectToRotate;

    void OnMouseDrag()
    {
        var mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        var difference = mousePos - objectToRotate.transform.position;

        difference.Normalize();

        var degreeZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;

        objectToRotate.transform.rotation = Quaternion.Euler(0, 0, degreeZ);
    }
}
