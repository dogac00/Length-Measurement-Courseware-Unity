using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CarScript : MonoBehaviour
{
    public GameObject car, toolsPanel, FailurePanel, SuccessPanel, QuestionPanel, CheckAnswersPanel, getToolsButton;
    public GameObject smallRuler, smallMeter;

    public Text distance;
    public Text toolsDistance;
    public InputField FirstDistance, SecondDistance;

    public static bool isSuccessful;

    void Start()
    {
        WorkForSuccess();
    }

    private void WorkForSuccess()
    {
        if (isSuccessful)
        {
            smallRuler.SetActive(true);
            smallMeter.SetActive(true);
            distance.text = "200";
            toolsDistance.text = "Alındı.";
            toolsDistance.color = new Color(0, 255, 0);
            getToolsButton.SetActive(false);
            car.transform.position = new Vector3(-0.93F, -3.41F);
        }
    }

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
            SceneManager.LoadScene("Scene3");
        }
        else
        {
            toolsPanel.SetActive(true);
        }
    }

    public void GetInside()
    {
        if (distance.text == "400" && isSuccessful)
        {
            QuestionPanel.SetActive(true);
        }
        else
        {
            FailurePanel.SetActive(true);
        }
    }

    public void CheckAnswers()
    {
        print("In");
        if (FirstDistance.text == "200" && SecondDistance.text == "400")
        {
            SuccessPanel.SetActive(true);
        }
        else
        {
            CheckAnswersPanel.SetActive(true);
        }
    }
}
