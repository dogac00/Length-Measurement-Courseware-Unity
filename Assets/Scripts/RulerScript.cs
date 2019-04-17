using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RulerScript : MonoBehaviour
{
    float firstTargetY = 2.0f;
    float secondTargetY = -0.12f;
    float thirdTargetY = -2.12f;
    float oldY = -3.6f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void AlignFirst()
    {
        StartCoroutine(MoveToFirst());
    }

    IEnumerator MoveToFirst()
    {
        Vector3 now = this.transform.position;
        float curY = now.y;

        if (curY < firstTargetY)
        {
            while (curY < firstTargetY)
            {
                curY += 0.2f;
                yield return new WaitForSeconds(0.04f);
                this.transform.position = new Vector3(now.x, curY, 0);
            }
        }

        else
        {
            while (curY > firstTargetY)
            {
                curY -= 0.2f;
                yield return new WaitForSeconds(0.04f);
                this.transform.position = new Vector3(now.x, curY, 0);
            }
        }
    }

    public void AlignSecond()
    {
        StartCoroutine(moveToSecond());
    }

    IEnumerator moveToSecond()
    {
        Vector3 now = this.transform.position;
        float curY = now.y;

        if (curY < secondTargetY)
        {
            while (curY < secondTargetY)
            {
                curY += 0.2f;
                yield return new WaitForSeconds(0.04f);
                this.transform.position = new Vector3(now.x, curY, 0);
            }
        }

        else
        {
            while (curY > secondTargetY)
            {
                curY -= 0.2f;
                yield return new WaitForSeconds(0.04f);
                this.transform.position = new Vector3(now.x, curY, 0);
            }
        }
    }

    public void AlignThird()
    {
        StartCoroutine(moveToThird());
    }

    IEnumerator moveToThird()
    {
        Vector3 now = this.transform.position;
        float curY = now.y;

        if (curY < thirdTargetY)
        {
            while (curY < thirdTargetY)
            {
                curY += 0.2f;
                yield return new WaitForSeconds(0.04f);
                this.transform.position = new Vector3(now.x, curY, 0);
            }
        }
        else
        {
            while (curY > thirdTargetY)
            {
                curY -= 0.2f;
                yield return new WaitForSeconds(0.04f);
                this.transform.position = new Vector3(now.x, curY, 0);
            }
        }
    }

    public void ReturnToOldPosition()
    {
        StartCoroutine(moveToOld());
    }

    IEnumerator moveToOld()
    {
        Vector3 now = this.transform.position;
        float curY = now.y;

        if (curY < oldY)
        {
            while (curY < oldY)
            {
                curY += 0.2f;
                yield return new WaitForSeconds(0.04f);
                this.transform.position = new Vector3(now.x, curY, 0);
            }
        }
        else
        {
            while (curY > oldY)
            {
                curY -= 0.2f;
                yield return new WaitForSeconds(0.04f);
                this.transform.position = new Vector3(now.x, curY, 0);
            }
        }
    }

    public void GetPosition()
    {
        Vector3 now = this.transform.position;
        Debug.Log("X: " + now.x + " Y: " + now.y);
    }
}
