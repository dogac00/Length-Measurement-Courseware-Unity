using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InputsCheckScript : MonoBehaviour
{
    public InputField first;
    public InputField second;
    public InputField third;

    public GameObject winningPanel;
    public GameObject tryAgain;
    public GameObject helpPanel;

    public GameObject ruler;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void CheckValues()
    {
        ruler.GetComponent<RulerScript>().SetAllUnactive();

        if (first.text == "5" && second.text == "8" && third.text == "11")
        {
            winningPanel.SetActive(true);
        }
        else
        {
            tryAgain.SetActive(true);
        }
    }

    public void OpenHelp()
    {
        helpPanel.SetActive(true);
    }
}
