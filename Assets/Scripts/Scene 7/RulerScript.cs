using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RulerScript : MonoBehaviour
{
    public GameObject Pointer;

    private float startX;

    private float firstTargetY = 0.64f;
    private float secondTargetY = -0.96f;
    private float thirdTargetY = -2.52f;
    private float oldY = -3.6f;
    private bool isMoving, isPointerMoving;

    // Start is called before the first frame update
    void Start()
    {
        startX = Pointer.transform.position.x;
        isMoving = false;
    }

    void Update()
    {

    }

    private void ClearPointer()
    {
        Pointer.SetActive(false);
        float curY = Pointer.transform.position.y;
        Pointer.transform.position = new Vector3(startX, curY);
    }

    private void MovePointer(float target)
    {
        if (!isPointerMoving)
        {
            Pointer.SetActive(true);
            isPointerMoving = true;
            StartCoroutine(MovePointerTo(target));
        }
    }

    IEnumerator MovePointerTo(float target)
    {
        Vector3 curPos = Pointer.transform.position;
        float curX = curPos.x;

        while (curX < target)
        {
            curX += 0.08F;
            Pointer.transform.position = new Vector3(curX, curPos.y);
            yield return new WaitForSeconds(0.002F);
        }

        isPointerMoving = false;
    }

    public void AlignFirst()
    {
        if (!isMoving && !isPointerMoving)
        {
            ClearPointer();
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

            MovePointer(-2.70F);
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

            MovePointer(-2.70F);
            isMoving = false;
        }
    }

    public void AlignSecond()
    {
        if (!isMoving && !isPointerMoving)
        {
            ClearPointer();
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

            MovePointer(-0.32F);
            isMoving = false;
        }

        else
        {
            while (curY > secondTargetY)
            {
                curY -= 0.2f;
                yield return new WaitForSeconds(0.04f);
                this.transform.position = new Vector3(now.x, curY, 0);
            }

            MovePointer(-0.32F);
            isMoving = false;
        }
    }

    public void AlignThird()
    {
        if (!isMoving && !isPointerMoving)
        {
            ClearPointer();
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

            MovePointer(2.18F);
            isMoving = false;
        }
        else
        {
            while (curY > thirdTargetY)
            {
                curY -= 0.2f;
                yield return new WaitForSeconds(0.04f);
                this.transform.position = new Vector3(now.x, curY, 0);
            }

            MovePointer(2.18F);
            isMoving = false;
        }
    }

    public void ReturnToOldPosition()
    {
        if (!isMoving && !isPointerMoving)
        {
            ClearPointer();
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
