using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DragScript : DraggableObject
{
    public bool isinBox;

    public void Success()
    {
        CarScript.isSuccessful = true;
        SceneManager.LoadScene("Scene5");
    }

    protected override void Start()
    {
        base.Start();

        isinBox = false;
    }

    protected override void OnMouseDown()
    {
        base.OnMouseDown();
    }

    protected override void OnMouseUp()
    {
        base.OnMouseUp();

        if (isinBox)
        {
            if (this.name == "compass")
            {
                this.transform.position = new Vector3(-1.92f, -2.52f, 0);
            }

            else if (this.name == "ruler")
            {
                this.transform.position = new Vector3(-0.84f, -2.58f, 0);
            }

            else if (this.name == "hammer")
            {
                this.transform.position = new Vector3(-0.22f, -2.64f, 0);
            }

            else if (this.name == "meter")
            {
                this.transform.position = new Vector3(-0.60f, -2.75f, 0);
            }
        }
        else
        {
            base.GoBack();
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        isinBox = true;
    }

    void OnTriggerExit2D(Collider2D col)
    {
        isinBox = false;
    }
}
