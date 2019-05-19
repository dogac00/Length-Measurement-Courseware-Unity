using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutScript : MonoBehaviour
{
    public Vector3 mousePos, blueLiner;
    public GameObject Saw, Line;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        blueLiner = Line.transform.position;

        if (isIn(mousePos))
        {
            Vector3 sawPosition = Saw.transform.position;
            Saw.transform.position = new Vector3(mousePos.x + 0.4F, sawPosition.y);
        }
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
}
