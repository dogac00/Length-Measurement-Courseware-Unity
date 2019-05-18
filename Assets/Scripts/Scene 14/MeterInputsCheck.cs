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
        return leftWidthCentimeter.text == "60" && leftWidthMeter.text == "" || leftWidthMeter.text == "0";
    }

    private bool leftHeightCondition()
    {
        return leftHeightMeter.text == "1" && leftHeightCentimeter.text == "60";
    }

    private bool rightWidthCondition()
    {
        return rightWidthCentimeter.text == "80" && rightWidthMeter.text == "" || rightWidthMeter.text == "0";
    }

    private bool rightHeightCondition()
    {
        return rightHeightMeter.text == "2" && rightHeightCentimeter.text == "" || rightHeightCentimeter.text == "0";
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
