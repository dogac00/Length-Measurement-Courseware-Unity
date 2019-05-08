using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CarScript : MonoBehaviour
{
    public GameObject car;
    public GameObject toolsPanel;
    public GameObject FailurePanel;
    public GameObject SuccessPanel;
    public Text distance;
    public Text toolsDistance;

    public void MoveForward()
    {
        if (float.Parse(distance.text) % 100 == 0)
        {
            int i = 0;
            StartCoroutine(MovePositionForward(i));
        }
    }

    IEnumerator MovePositionForward(int i)
    {
        Vector3 curPos = car.transform.position;
        float curX = curPos.x;

        while (i < 20)
        {
            curX += 0.14f;
            distance.text = (float.Parse(distance.text) + 5f).ToString();
            yield return new WaitForSeconds(0.05f);
            car.transform.position = new Vector3(curX, curPos.y, 0);
            ++i;
        }
    }

    public void MoveBackward()
    {
        if (float.Parse(distance.text) % 100 == 0)
        {
            int i = 0;
            StartCoroutine(MovePositionBackward(i));
        }
    }

    IEnumerator MovePositionBackward(int i)
    {
        Vector3 curPos = car.transform.position;
        float curX = curPos.x;

        while (i < 20)
        {
            curX -= 0.14f;
            distance.text = (float.Parse(distance.text) - 5f).ToString();
            yield return new WaitForSeconds(0.05f);
            car.transform.position = new Vector3(curX, curPos.y, 0);
            ++i;
        }
    }

    public void GetTools()
    {
        if (distance.text == "200")
        {
            toolsDistance.text = "Alındı.";
            toolsDistance.color = new Color(0, 255, 0);
        }
        else
        {
            toolsPanel.SetActive(true);
        }
    }

    public void GetInside()
    {
        if (distance.text == "400" && toolsDistance.text == "Alındı.")
        {
            SuccessPanel.SetActive(true);
        }
        else
        {
            FailurePanel.SetActive(true);
        }
    }

    void Start()
    {
        toolsDistance.text = "Alınmadı.";
        toolsDistance.color = new Color(255, 0, 0);
    }
}
