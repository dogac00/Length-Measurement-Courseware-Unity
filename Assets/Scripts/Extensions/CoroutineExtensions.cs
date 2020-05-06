
using System;
using System.Collections;
using UnityEngine;

public static class CoroutineExtensions
{
    public static void RunAfter(this MonoBehaviour behavior, int milliseconds, Action action)
    {
        behavior.StartCoroutine(Routine());

        IEnumerator Routine()
        {
            yield return new WaitForSeconds(milliseconds / 1000F);

            action();
        }
    }
}