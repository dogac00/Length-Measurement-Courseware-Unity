using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public GameObject ruler;
    public GameObject meter;
    public GameObject compass;
    public GameObject hammer;
    public GameObject winningPanel;
    public GameObject tryAgain;

    bool firstCondition, secondCondition, thirdCondition, fourthCondition;

    public void Check()
    {
        firstCondition = ruler.GetComponent<DragScript>().isinBox;
        secondCondition = meter.GetComponent<DragScript>().isinBox;
        thirdCondition = compass.GetComponent<DragScript>().isinBox;
        fourthCondition = hammer.GetComponent<DragScript>().isinBox;

        if (firstCondition && secondCondition && !thirdCondition && !fourthCondition)
        {
            winningPanel.SetActive(true);
        }

        else
        {
            tryAgain.SetActive(true);
        }
    }
}
