using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutScript : MonoBehaviour
{
    public static int TrueNumber;
    public Vector3 mousePos;
    public GameObject CloseFirst, CloseSecond, CloseThird;
    public GameObject Saw, WrongPlacePanel, FirstButton, SecondButton, ThirdButton;
    public GameObject FirstZoomButton, SecondZoomButton, ThirdZoomButton, GoBackButton;
    public GameObject FirstOkay, SecondOkay, ThirdOkay;
    public Animator BackPart, BackPartSecond, BackPartExtra;
    public Animator BodyPartExtra;
    public Animator LegPart, LegPartSecond, LegPartExtra;
    private bool flag, isZooming, zoomedIn;
    private bool firstCutted, secondCutted, thirdCutted;

    // Start is called before the first frame update
    void Start()
    {
        zoomedIn = false;
        isZooming = false;
        SetBodyAnimations(false);
        SetBackAnimations(false);
        SetLegAnimations(false);
        TrueNumber = 0;
    }

    private void SetBackAnimations(bool active)
    {
        BackPart.enabled = active;
        BackPartSecond.enabled = active;
        BackPartExtra.enabled = active;
    }

    private void SetBodyAnimations(bool active)
    {
        BodyPartExtra.enabled = active;
    }

    private void SetLegAnimations(bool active)
    {
        LegPart.enabled = active;
        LegPartSecond.enabled = active;
        LegPartExtra.enabled = active;
    }

    private void PlayBackAnimations()
    {
        BackPart.Play("BackPartAnimation");
        BackPartSecond.Play("BackPartSecondCutAnimation");
        BackPartExtra.Play("BackPartExtraCutAnimation");
    }

    private void PlayBodyAnimations()
    {
        BodyPartExtra.Play("BodyPartExtraCutAnimation");
    }

    private void PlayLegAnimations()
    {
        LegPart.Play("LegPartAnimation");
        LegPartSecond.Play("LegPartSecondAnimation");
        LegPartExtra.Play("LegPartExtraAnimation");
    }

    private void SetAllButtons(bool active)
    {
        GoBackButton.SetActive(!active);

        if (!firstCutted)
        {
            FirstButton.SetActive(active);
            FirstZoomButton.SetActive(active);
        }
        if (!secondCutted)
        {
            SecondButton.SetActive(active);
            SecondZoomButton.SetActive(active);
        }
        if (!thirdCutted)
        {
            ThirdButton.SetActive(active);
            ThirdZoomButton.SetActive(active);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!zoomedIn)
        {
            Vector3 mouseInput = Input.mousePosition;
            mouseInput.z = 10;
            mousePos = Camera.main.ScreenToWorldPoint(mouseInput);

            if (isIn(mousePos))
            {
                Vector3 sawPosition = Saw.transform.position;
                Saw.transform.position = new Vector3(mousePos.x + 0.4F, sawPosition.y);
            }
        }

        if (TrueNumber == 3)
        {
            StartCoroutine(AllTrue());
            TrueNumber = 0;
        }
    }

    IEnumerator AllTrue()
    {
        Saw.SetActive(false);

        yield return new WaitForSeconds(1.6F);

        FirstOkay.SetActive(false);
        SecondOkay.SetActive(false);
        ThirdOkay.SetActive(false);

        yield return null;
    }

    private bool isIn(Vector3 position)
    {
        return isInFirst(position.x, position.y) || isInSecond(position.x, position.y) || isInThird(position.x, position.y);
    }

    private bool isInFirst(float x, float y)
    {
        return x > -9 && x < -3.2F && y > -3.8F && y < -3;
    }

    private bool isInSecond(float x, float y)
    {
        return x > -2.12F && x < 1 && y > -3.8F && y < -2.34F;
    }

    private bool isInThird(float x, float y)
    {
        return x > 1.72F && x < 4.80F && y > -3.8F && y < -2.52F;
    }

    private bool isCorrectPositionFirst(float x)
    {
        return x < -3.96F && x > -4.25F;
    }

    private bool isCorrectPositionSecond(float x)
    {
        return x < 0.26F && x > -0.04F;
    }

    private bool isCorrectPositionThird(float x)
    {
        return x < 3.84F && x > 3.66F;
    }

    public void CutBack()
    {
        if (isCorrectPositionFirst(Saw.transform.position.x))
        {
            TrueNumber++;
            SetBackAnimations(true);
            PlayBackAnimations();
            CloseFirst.SetActive(false);
            FirstOkay.SetActive(true);
            FirstButton.SetActive(false);
            firstCutted = true;
        }
        else
        {
            WrongPlacePanel.SetActive(true);
        }
    }

    public void CutBody()
    {
        if (isCorrectPositionSecond(Saw.transform.position.x))
        {
            TrueNumber++;
            SetBodyAnimations(true);
            PlayBodyAnimations();
            CloseSecond.SetActive(false);
            SecondOkay.SetActive(true);
            SecondButton.SetActive(false);
            secondCutted = true;
        }
        else
        {
            WrongPlacePanel.SetActive(true);
        }
    }

    public void CutLeg()
    {
        if (isCorrectPositionThird(Saw.transform.position.x))
        {
            TrueNumber++;
            SetLegAnimations(true);
            PlayLegAnimations();
            CloseThird.SetActive(false);
            ThirdOkay.SetActive(true);
            ThirdButton.SetActive(false);
            thirdCutted = true;
        }
        else
        {
            WrongPlacePanel.SetActive(true);
        }
    }

    public void ZoomToFirst()
    {
        if (!isZooming)
        {
            zoomedIn = false;
            SetAllButtons(false);
            isZooming = true;
            StartCoroutine(Zoom(-4.95F, -2.72F, 24));
        }
    }

    public void ZoomToSecond()
    {
        if (!isZooming)
        {
            zoomedIn = false;
            SetAllButtons(false);
            isZooming = true;
            StartCoroutine(Zoom(-0.52F, -2.72F, 24));
        }
    }

    public void ZoomToThird()
    {
        if (!isZooming)
        {
            zoomedIn = false;
            SetAllButtons(false);
            isZooming = true;
            StartCoroutine(Zoom(3.54F, -2.72F, 24));
        }
    }

    public void GoBackToNormal()
    {
        if (!isZooming)
        {
            zoomedIn = true;
            SetAllButtons(true);
            isZooming = true;
            StartCoroutine(Zoom(0, 0, 53));
        }
    }

    IEnumerator Zoom(float targetX, float targetY, int targetFov)
    {
        while (true)
        {
            flag = true;

            float currentFov = Camera.main.fieldOfView;
            float curX = Camera.main.transform.position.x;
            float curY = Camera.main.transform.position.y;

            if (curX < targetX - 0.2F)
            {
                flag = false;
                curX += 0.04F;
            }

            if (curX > targetX + 0.2F)
            {
                flag = false;
                curX -= 0.04F;
            }

            if (curY < targetY - 0.2F)
            {
                flag = false;
                curY += 0.04F;
            }

            if (curY > targetY + 0.2F)
            {
                flag = false;
                curY -= 0.04F;
            }

            if (currentFov > targetFov + 0.5F)
            {
                flag = false;
                currentFov -= 0.5F;
            }

            if (currentFov < targetFov - 0.5F)
            {
                flag = false;
                currentFov += 0.5F;
            }

            if (flag)
            {
                zoomedIn = !zoomedIn;
                isZooming = false;
                break;
            }

            Camera.main.fieldOfView = currentFov;
            Camera.main.transform.position = new Vector3(curX, curY, -10);
            yield return new WaitForSeconds(0.002F);
        }
    }
}
