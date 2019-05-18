using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CheckConversionsScript : MonoBehaviour
{
    public InputField First, Second, Third, Fourth;
    public GameObject Success, Failure;

    public void CheckValues()
    {
        if (First.text == "4" && Second.text == "50"
            && Third.text == "300" && Fourth.text == "8")
        {
            Success.SetActive(true);
        }
        else
        {
            Failure.SetActive(true);
        }
    }
}
