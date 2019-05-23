using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ConverterScript : MonoBehaviour
{
    public InputField FirstPartInput, SecondPartInput;
    public Text FirstPartResult, SecondPartResult;
    public GameObject ConverterPanel, WarningPanel, OrderWarningPanel, MachineBreakdownPanel;
    public GameObject FirstConvertButton, SecondConvertButton, ThirdConvertButton, FourthConvertButton;
    private bool firstConverted, secondConverted;

    public void ConvertFirst()
    {
        if (FirstPartInput.text == "40")
        {
            StartCoroutine(FirstPartCoroutine());
            firstConverted = true;
        }
        else
        {
            ConverterPanel.SetActive(false);
            WarningPanel.SetActive(true);
        }
    }

    IEnumerator FirstPartCoroutine()
    {
        FirstPartResult.text = "40 / 10";

        yield return new WaitForSeconds(1.2F);

        FirstPartResult.text = "4 cm";
    }

    public void ConvertSecond()
    {
        if (!firstConverted)
        {
            ConverterPanel.SetActive(false);
            OrderWarningPanel.SetActive(true);
        }
        else if (SecondPartInput.text != "5")
        {
            ConverterPanel.SetActive(false);
            WarningPanel.SetActive(true);
        }
        else
        {
            StartCoroutine(ConvertSecondCoroutine());
            secondConverted = true;
        }
    }

    IEnumerator ConvertSecondCoroutine()
    {
        SecondPartResult.text = "5 x 10";

        yield return new WaitForSeconds(1.2F);

        SecondPartResult.text = "50 cm";
    }

    public void ConvertThird()
    {
        if (!secondConverted)
        {
            ConverterPanel.SetActive(false);
            OrderWarningPanel.SetActive(true);
        }
        else
        {
            ConverterPanel.SetActive(false);
            MachineBreakdownPanel.SetActive(true);
            FirstConvertButton.SetActive(false);
            SecondConvertButton.SetActive(false);
            ThirdConvertButton.SetActive(false);
            FourthConvertButton.SetActive(false);
        }
    }

    public void ConvertFourth()
    {
        ConverterPanel.SetActive(false);
        OrderWarningPanel.SetActive(true);
    }
    // Start is called before the first frame update
    void Start()
    {
        firstConverted = secondConverted = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
