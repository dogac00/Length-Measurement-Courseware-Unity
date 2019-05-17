using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateMeterScript : MonoBehaviour
{
    public void Rotate()
    {
        float curZ = this.transform.eulerAngles.z;

        if (curZ % 90 == 0)
        {
            StartCoroutine(RotateCoroutine(curZ - 90));
        }
    }

    IEnumerator RotateCoroutine(float targetZ)
    {
        float curZ = this.transform.eulerAngles.z;

        while (curZ > targetZ)
        {
            curZ -= 3;
            this.transform.eulerAngles = new Vector3(0, 0, curZ);
            yield return new WaitForSeconds(0.02F);
        }
    }
}
