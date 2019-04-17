using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnimationBackward : MonoBehaviour
{
    public GameObject frontman;
    public Vector3 curPos;

    public Text distance;

    void Start()
    {
        this.GetComponent<Animator>().enabled = false;
    }

    public void MoveBackward()
    {
        if (float.Parse(distance.text) % 50 == 0)
        {
            StartCoroutine(MovePositionBackward());

            this.GetComponent<Animator>().Play("walking-back");
            this.GetComponent<Animator>().enabled = true;

            StartCoroutine(WaitandStop());
        }
    }

    IEnumerator WaitandStop()
    {
        yield return new WaitForSeconds(1f);

        this.GetComponent<Animator>().enabled = false;

    }

    public void MoveForward()
    {
        if (float.Parse(distance.text) % 50 == 0)
        {
            Vector3 pos = frontman.transform.position;
            this.transform.position = new Vector3(pos.x + 1.4f, pos.y, 0);
        }
    }

    IEnumerator MovePositionBackward()
    {
        float curX = this.transform.position.x;
        float targetX = curX - 1.38f;

        while (targetX < curX)
        {
            curX -= 0.07f;
            distance.text = (float.Parse(distance.text) - 2.5f).ToString();
            yield return new WaitForSeconds(0.05f);
            this.transform.position = new Vector3(curX, curPos.y, 0);
        }
    }

    // Update is called once per frame
    void Update()
    {
        curPos = this.transform.position;
    }
}
