using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GenerateScript : MonoBehaviour
{
    public InputField TagValue;
    private static int totalCount;
    public GameObject RestartPanel, TryAgain, SuccessPanel, NumberPanel;
    public GameObject[] FirstTags, SecondTags, ThirdTags;
    public GameObject FirstTagArr, SecondTagArr, ThirdTagArr;

    void Start()
    {
        SetObjectsFalse();
        totalCount = 0;
    }

    public void ShowRestartPanel()
    {
        RestartPanel.SetActive(true);
    }

    public void ShowSuccessPanel()
    {
        SuccessPanel.SetActive(true);
    }

    public void ShowTryAgainPanel()
    {
        TryAgain.SetActive(true);
    }

    public void Generate()
    {
        if (int.Parse(TagValue.text) < 0 || int.Parse(TagValue.text) > 10)
        {
            NumberPanel.SetActive(true);
        }
        else if (totalCount == 0)
        {
            ActivateFirstTag();
            totalCount++;
        }
        else if (totalCount == 1)
        {
            ActivateSecondTag();
            totalCount++;
        }
        else if (totalCount == 2)
        {
            ActivateThirdTag();
            totalCount++;
        }
        else
            RestartPanel.SetActive(true);
    }

    private void SetObjectsFalse()
    {
        SetFalse(FirstTags);
        SetFalse(SecondTags);
        SetFalse(ThirdTags);
    }

    private void SetFalse(GameObject[] arr)
    {
        foreach (var obj in arr)
        {
            obj.SetActive(false);
        }
    }

    public void LoadThis()
    {
        SceneManager.LoadScene("Scene11");
    }

    private void ActivateFirstTag()
    {
        foreach (var obj in FirstTags)
        {
            if (obj.gameObject.name.Substring(0, 1) == TagValue.text)
            {
                obj.SetActive(true);
            }
            else if (obj.gameObject.name.Substring(0, 2) == TagValue.text)
            {
                obj.SetActive(true);
            }
        }
    }

    private void ActivateSecondTag()
    {
        foreach (var obj in SecondTags)
        {
            if (obj.gameObject.name.Substring(0, 1) == TagValue.text)
            {
                obj.SetActive(true);
            }
            else if (obj.gameObject.name.Substring(0, 2) == TagValue.text)
            {
                obj.SetActive(true);
            }
        }
    }

    private void ActivateThirdTag()
    {
        foreach (var obj in ThirdTags)
        {
            if (obj.gameObject.name.Substring(0, 1) == TagValue.text)
            {
                obj.SetActive(true);
            }
            else if (obj.gameObject.name.Substring(0, 2) == TagValue.text)
            {
                obj.SetActive(true);
            }
        }
    }
}
