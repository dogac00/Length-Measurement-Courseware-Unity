using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

public class AnimationCode : MonoBehaviour
{
    public GameObject backman;
    public Vector3 curPos;

    public Text distance;
    public GameObject winningPanel;
    public GameObject checkAgain;

    void Start()
    {
        this.GetComponent<Animator>().enabled = false;
    }

    public void MoveForward()
    {
        if (float.Parse(distance.text) % 50 == 0)
        {
            StartCoroutine(MovePositionForward());

            this.GetComponent<Animator>().Play("walking-front");
            this.GetComponent<Animator>().enabled = true;

            StartCoroutine(WaitandStop());
        }
    }

    public void MoveBackward()
    {
        if (float.Parse(distance.text) % 50 == 0)
        {
            Vector3 pos = backman.transform.position;
            this.transform.position = new Vector3(pos.x - 1.38f, pos.y, 0);
        }
    }

    IEnumerator WaitandStop()
    {
        yield return new WaitForSeconds(1f);

        this.GetComponent<Animator>().enabled = false;
    }

    IEnumerator MovePositionForward()
    {
        float curX = this.transform.position.x;
        float targetX = curX + 1.38f;

        while(curX < targetX)
        {
            curX += 0.07f;
            distance.text = (float.Parse(distance.text) + 2.5f).ToString();
            yield return new WaitForSeconds(0.05f);
            this.transform.position = new Vector3(curX, curPos.y, 0);
        }
    }

    public void CheckDistance()
    {
        if (distance.text == "450")
        {
            winningPanel.SetActive(true);
        }
        else
        {
            checkAgain.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        curPos = this.transform.position;
    }
}
