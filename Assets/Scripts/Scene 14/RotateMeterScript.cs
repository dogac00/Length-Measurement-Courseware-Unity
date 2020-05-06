using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;

public class RotateMeterScript : MonoBehaviour
{
    public GameObject left, right;
    public GameObject rotateIcon;

    void Start()
    {
        rotateIcon.AddComponent(typeof(EventTrigger));
        EventTrigger trigger = rotateIcon.GetComponent<EventTrigger>();
        var entry = new EventTrigger.Entry();
        entry.eventID = EventTriggerType.Drag;
        entry.callback.AddListener((eventData) =>
        {
            RotateWithMouse();
        });
        trigger.triggers.Add(entry);
    }

    void Update()
    {
        var mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        bool isClose = mousePos.IsClose(left.transform.position, 2) ||
                           mousePos.IsClose(right.transform.position, 2);

        if (isClose)
        {
            Cursor.visible = false;

            rotateIcon.SetActive(true);

            rotateIcon.transform.position = new Vector3(mousePos.x, mousePos.y);
        }
        else
        {
            Cursor.visible = true;

            rotateIcon.SetActive(false);
        }

        if (isClose && Input.GetMouseButtonDown(0))
        {
            RotateWithMouse();
        }
    }

    private void RotateWithMouse()
    {
        var mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        var difference = mousePos - this.transform.position;

        difference.Normalize();

        var degreeZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;

        this.transform.rotation = Quaternion.Euler(0, 0, degreeZ);
    }
}
