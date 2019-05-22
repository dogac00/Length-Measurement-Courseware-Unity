using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseupScript : MonoBehaviour
{
    public GameObject BodyZoomButton, LegZoomButton, GoBackButton;
    private bool flag, isZooming;

    private void ReverseActiveGameObject(GameObject obj)
    {
        if (obj.activeSelf)
        {
            obj.SetActive(false);
        }
        else
        {
            obj.SetActive(true);
        }
    }

    private void SetButtons(bool active)
    {
        BodyZoomButton.SetActive(active);
        LegZoomButton.SetActive(active);
        GoBackButton.SetActive(!active);
    }

    public void ZoomToLeg()
    {
        if (!isZooming)
        {
            SetButtons(false);
            isZooming = true;
            StartCoroutine(Zoom(-1.6F, -2.72F, 20, false));
        }
    }

    public void ZoomToBody()
    {
        if (!isZooming)
        {
            SetButtons(false);
            isZooming = true;
            StartCoroutine(Zoom(-6.4F, -0.4F, 20, false));
        }
    }

    public void GoBackToNormal()
    {
        if (!isZooming)
        {
            isZooming = true;
            StartCoroutine(Zoom(0, 0, 53, true));
        }
    }

    IEnumerator Zoom(float targetX, float targetY, int targetFov, bool isGoingBack)
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

            if (currentFov > targetFov + 0.3F)
            {
                flag = false;
                currentFov -= 0.3F;
            }

            if (currentFov < targetFov - 0.3F)
            {
                flag = false;
                currentFov += 0.3F;
            }

            if (flag)
            {
                if (isGoingBack) SetButtons(true);

                isZooming = false;
                break;
            }

            Camera.main.fieldOfView = currentFov;
            Camera.main.transform.position = new Vector3(curX, curY, -10);
            yield return new WaitForSeconds(0.002F);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        isZooming = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
