using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroySelf : MonoBehaviour
{
    public int seconds = 5;

    void Start()
    {
        StartCoroutine(Destroyer());
    }

    IEnumerator Destroyer()
    {
        yield return new WaitForSeconds(seconds);

        if (this.gameObject != null)
            Destroy(this.gameObject);
    }
}
