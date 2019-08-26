using System.Collections;
using UnityEngine;

public class Panel : MonoBehaviour
{
    protected virtual void OnEnable()
    {
        StartCoroutine(Show(this.gameObject, 1));
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
