using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineDrawer : MonoBehaviour
{
    [SerializeField]
    LineRenderer lr;
    private void Awake()
    {
        StartCoroutine(LineDraw());
    }
    IEnumerator LineDraw()
    {
        float t = 0;
        float time = 2;
        Vector3 orig = lr.GetPosition(0);
        Vector3 orig2 = lr.GetPosition(1);
        lr.SetPosition(1, orig);
        Vector3 newpos;
        for (; t < time; t += Time.deltaTime)
        {
            newpos = Vector3.Lerp(orig, orig2, t / time);
            lr.SetPosition(1, newpos);
            yield return null;
        }
        lr.SetPosition(1, orig2);
    }
}
