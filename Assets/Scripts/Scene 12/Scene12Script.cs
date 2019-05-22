using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Scene12Script : MonoBehaviour
{
    public Text firstCM, firstMM;
    public InputField firstCMInput, firstMMInput, secondMMInput, secondCMInput, thirdCMInput, thirdMMInput;
    public GameObject successPanel, tryAgainPanel, redPointer;

    private bool flag, isCalculated;
    private float firstX, firstY;

    // Start is called before the first frame update
    void Start()
    {
        isCalculated = false;
        firstX = firstY = 0;
        firstCM.text = firstMM.text = "";
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void CheckValues()
    {
        if (firstCMInput.text == "1" && firstMMInput.text == "2"
            && secondCMInput.text == "1" && secondMMInput.text == "6"
            && thirdMMInput.text == "7" && (thirdCMInput.text == "0" || thirdCMInput.text == ""))
        {
            successPanel.SetActive(true);
        }
        else
        {
            tryAgainPanel.SetActive(true);
        }
    }

    public void Align()
    {
        StartCoroutine(AlignToFirst());
    }

    IEnumerator AlignToFirst()
    {
        float curX = transform.position.x;
        float curY = transform.position.y;

        while (true)
        {
            flag = true;

            if (curX < -1.55F)
            {
                curX += 0.02F;
                flag = false;
            }

            if (curX > -1.52F)
            {
                curX -= 0.02F;
                flag = false;
            }

            if (curY > -4.26F)
            {
                curY -= 0.02F;
                flag = false;
            }

            if (curY > -4.22F)
            {
                curY -= 0.02F;
                flag = false;
            }

            if (flag)
            {
                if (!isCalculated)
                {
                    redPointer.SetActive(true);
                    StartCoroutine(CalculateLength());
                }
                break;
            }

            yield return new WaitForSeconds(0.001F);
            transform.position = new Vector3(curX, curY);
        }
    }

    private void MovePointer()
    {
        Vector3 pointerPos = redPointer.transform.position;
        redPointer.transform.position = new Vector3(pointerPos.x + 0.23F, pointerPos.y);
    }

    IEnumerator CalculateLength()
    {
        while (firstY < 9 && firstX == 0)
        {
            MovePointer();
            firstMM.text = (++firstY).ToString() + " mm";
            yield return new WaitForSeconds(0.25F);
        }

        MovePointer();
        firstCM.text = (++firstX).ToString() + " cm";
        firstY = 0;

        while (firstY < 3)
        {
            MovePointer();
            firstMM.text = (firstY++).ToString() + " mm";
            yield return new WaitForSeconds(0.25F);
        }

        isCalculated = true;
        Destroy(redPointer, 3);
    }
}
