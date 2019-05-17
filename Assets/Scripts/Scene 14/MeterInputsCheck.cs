using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MeterInputsCheck : MonoBehaviour
{
    public InputField leftWidthMeter, leftWidthCentimeter;
    public InputField leftHeightMeter, leftHeightCentimeter;
    public InputField rightWidthMeter, rightWidthCentimeter;
    public InputField rightHeightMeter, rightHeightCentimeter;
    public GameObject tryAgainPanel, successPanel;

    private bool leftWidthCondition()
    {
        return leftWidthCentimeter.text == "80" && leftWidthMeter.text == "" || leftWidthMeter.text == "0";
    }

    private bool leftHeightCondition()
    {
        return leftHeightMeter.text == "2" && leftHeightCentimeter.text == "40";
    }

    private bool rightWidthCondition()
    {
        return rightWidthMeter.text == "1" && rightWidthCentimeter.text == "20";
    }

    private bool rightHeightCondition()
    {
        return rightHeightMeter.text == "2" && rightHeightCentimeter.text == "80";
    }

    public void CheckValues()
    {
        if (leftWidthCondition() && rightWidthCondition()
            && leftHeightCondition() && rightHeightCondition())
        {
            successPanel.SetActive(true);
        }
        else
        {
            tryAgainPanel.SetActive(true);
        }
    }
}
