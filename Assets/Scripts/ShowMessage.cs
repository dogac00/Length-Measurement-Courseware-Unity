using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowMessage : MonoBehaviour
{
    void Start()
    {
        ShowPanel(this.gameObject, 1);
    }

    public void ShowPanel(GameObject obj, float time)
    {
        StartCoroutine(Show(obj, time));
    }

    IEnumerator Show(GameObject obj, float time)
    {
        float timemax = time;

        obj.SetActive(true);
        obj.transform.localScale = Vector3.zero;

        while (time > 0)
        {
            time -= Time.deltaTime;
            yield return new WaitForSeconds(Time.deltaTime);
            obj.transform.localScale = Vector3.Lerp(Vector3.zero, Vector3.one, (timemax - time) / timemax);
        }
    }
}
