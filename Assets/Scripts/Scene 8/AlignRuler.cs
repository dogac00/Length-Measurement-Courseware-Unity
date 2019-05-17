using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AlignRuler : MonoBehaviour
{
    public GameObject ruler;
    public GameObject success;
    public GameObject tryAgain;

    public Camera myCamera;
    public InputField legWidth;
    public InputField bodyWidth;

    public GameObject Pointer2;
    public GameObject Pointer3;

    private string aligned;
    
    private bool flag;
    private bool isMoving;

    // Start is called before the first frame update
    void Start()
    {
        aligned = "null";
        isMoving = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxis("Mouse ScrollWheel") > 0)
        {
            if (myCamera.fieldOfView > 1)
            {
                myCamera.fieldOfView--;
            }
        }
        if (Input.GetAxis("Mouse ScrollWheel") < 0)
        {
            if (myCamera.fieldOfView < 53)
            {
                myCamera.fieldOfView++;
            }
        }
    }

    private void SetAllUnactive()
    {
        Pointer2.SetActive(false);
        Pointer3.SetActive(false);
    }

    public void CheckValues()
    {
        if (legWidth.text == "3" && bodyWidth.text == "2")
        {
            success.SetActive(true);
        }
        else
        {
            tryAgain.SetActive(true);
        }
    }

    public void AlignToNormal()
    {
        if (!isMoving)
        {
            SetAllUnactive();
            aligned = "null";
            isMoving = true;
            StartCoroutine(AlignToNormalCoroutine());
        }
    }

    IEnumerator AlignToNormalCoroutine()
    {
        float curX = ruler.transform.position.x;
        float curY = ruler.transform.position.y;
        float rotationZ = ruler.transform.eulerAngles.z;

        while (true)
        {
            flag = true;

            if (curX < 3.24F)
            {
                curX += 0.04F;
                flag = false;
            }

            if (curY > -4.11F)
            {
                curY -= 0.04F;
                flag = false;
            }

            if (rotationZ > 0)
            {
                rotationZ -= 1F;
                ruler.transform.eulerAngles = new Vector3(0, 0, rotationZ);
                flag = false;
            }
            else if (rotationZ < 0)
            {
                rotationZ += 1F;
                ruler.transform.eulerAngles = new Vector3(0, 0, rotationZ);
                flag = false;
            }

            if (flag)
            {
                isMoving = false;
                break;
            }

            yield return new WaitForSeconds(0.001F);
            ruler.transform.position = new Vector3(curX, curY);
        }
    }

    public void AlignToBody()
    {
        if (aligned == "body")
        {
            return;
        }

        if (!isMoving)
        {
            aligned = "body";
            isMoving = true;
            SetAllUnactive();
            StartCoroutine(AlignToBodyCoroutine());
        }
    }

    IEnumerator AlignToBodyCoroutine()
    {
        float curX = ruler.transform.position.x;
        float curY = ruler.transform.position.y;
        float rotationZ = ruler.transform.eulerAngles.z;

        while (true)
        {
            flag = true;

            if (curX > -8.08F)
            {
                curX -= 0.04F;
                flag = false;
            }
            else if (curX < -8.12F)
            {
                curX += 0.04F;
                flag = false;
            }

            if (curY > -3.84F)
            {
                curY -= 0.04F;
                flag = false;
            }
            else if (curY < -3.88F)
            {
                curY += 0.04F;
                flag = false;
            }

            if (rotationZ > -89)
            {
                rotationZ -= 1F;
                ruler.transform.eulerAngles = new Vector3(0, 0, rotationZ);
                flag = false;
            }
            else if (rotationZ < -91)
            {
                rotationZ += 1F;
                ruler.transform.eulerAngles = new Vector3(0, 0, rotationZ);
                flag = false;
            }

            if (flag)
            {
                isMoving = false;
                Pointer2.SetActive(true);
                break;
            }

            yield return new WaitForSeconds(0.001F);
            ruler.transform.position = new Vector3(curX, curY);
        }
    }

    public void AlignToLeg()
    {
        if (aligned == "leg")
        {
            return;
        }

        if (!isMoving)
        {
            aligned = "leg";
            isMoving = true;
            SetAllUnactive();
            StartCoroutine(AlignToLegCoroutine());
        }
    }

    IEnumerator AlignToLegCoroutine()
    {
        float curX = ruler.transform.position.x;
        float curY = ruler.transform.position.y;
        float rotationZ = ruler.transform.eulerAngles.z;

        while (true)
        {
            flag = true;

            if (curX < 0.83F)
            {
                curX += 0.04F;
                flag = false;
            }

            else if (curX > 0.88F)
            {
                curX -= 0.04F;
                flag = false;
            }

            if (curY > -3.88F)
            {
                curY -= 0.04F;
                flag = false;
            }

            else if (curY < -3.93F)
            {
                curY += 0.04F;
                flag = false;
            }
            
            if (rotationZ > 0)
            {
                rotationZ -= 1F;
                ruler.transform.eulerAngles = new Vector3(0, 0, rotationZ);
                flag = false;
            }
            else if (rotationZ < 0)
            {
                rotationZ += 1F;
                ruler.transform.eulerAngles = new Vector3(0, 0, rotationZ);
                flag = false;
            }

            if (flag)
            {
                isMoving = false;
                Pointer3.SetActive(true);
                break;
            }

            yield return new WaitForSeconds(0.001F);
            ruler.transform.position = new Vector3(curX, curY);
        }
    }
}
