using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RulerScript : MonoBehaviour
{
    public GameObject Pointer5;
    public GameObject Pointer8;
    public GameObject Pointer11;

    float firstTargetY = 0.64f;
    float secondTargetY = -0.96f;
    float thirdTargetY = -2.52f;
    float oldY = -3.6f;
    private bool flag5, flag8, flag11;
    private bool isMoving;

    // Start is called before the first frame update
    void Start()
    {
        isMoving = false;
        flag5 = false;
        flag8 = false;
        flag11 = false;
    }

    void Update()
    {
        if (flag5)
        {
            Pointer5.SetActive(true);
        }
        if (flag8)
        {
            Pointer8.SetActive(true);
        }
        if (flag11)
        {
            Pointer11.SetActive(true);
        }
    }

    public void SetAllUnactive()
    {
        Pointer5.SetActive(false);
        Pointer8.SetActive(false);
        Pointer11.SetActive(false);
        flag5 = false;
        flag8 = false;
        flag11 = false;
    }

    public void AlignFirst()
    {
        SetAllUnactive();

        if (!isMoving)
        {
            isMoving = true;
            StartCoroutine(MoveToFirst());
        }
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

            flag5 = true;
            isMoving = false;
        }

        else
        {
            while (curY > firstTargetY)
            {
                curY -= 0.2f;
                yield return new WaitForSeconds(0.04f);
                this.transform.position = new Vector3(now.x, curY, 0);
            }

            flag5 = true;
            isMoving = false;
        }
    }

    public void AlignSecond()
    {
        SetAllUnactive();

        if (!isMoving)
        {
            isMoving = true;
            StartCoroutine(moveToSecond());
        }
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

            isMoving = false;
            flag8 = true;
        }

        else
        {
            while (curY > secondTargetY)
            {
                curY -= 0.2f;
                yield return new WaitForSeconds(0.04f);
                this.transform.position = new Vector3(now.x, curY, 0);
            }

            isMoving = false;
            flag8 = true;
        }
    }

    public void AlignThird()
    {
        SetAllUnactive();

        if (!isMoving)
        {
            isMoving = true;
            StartCoroutine(moveToThird());
        }
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

            isMoving = false;
            flag11 = true;
        }
        else
        {
            while (curY > thirdTargetY)
            {
                curY -= 0.2f;
                yield return new WaitForSeconds(0.04f);
                this.transform.position = new Vector3(now.x, curY, 0);
            }

            isMoving = false;
            flag11 = true;
        }
    }

    public void ReturnToOldPosition()
    {
        SetAllUnactive();

        if (!isMoving)
        {
            isMoving = true;
            StartCoroutine(moveToOld());
        }
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

            isMoving = false;
        }
        else
        {
            while (curY > oldY)
            {
                curY -= 0.2f;
                yield return new WaitForSeconds(0.04f);
                this.transform.position = new Vector3(now.x, curY, 0);
            }

            isMoving = false;
        }
    }

    public void GetPosition()
    {
        Vector3 now = this.transform.position;
        Debug.Log("X: " + now.x + " Y: " + now.y);
    }
}
