using System.Collections;
using UnityEngine;

public class Panel : MonoBehaviour, IPanel
{
    public virtual void OnDisable()
    {
        Globals.PanelMode = false;
    }

    public virtual void OnEnable()
    {
        Globals.PanelMode = true;

        StartCoroutine(ShowFast(this.gameObject));
    }

    IEnumerator ShowFast(GameObject obj)
    {
        obj.SetActive(true);
        obj.transform.localScale = Vector3.zero;

        float time = 100;

        while (time-- > 0)
        {
            yield return new WaitForSeconds(0.001F);
            obj.transform.localScale = Vector3.Lerp(Vector3.zero, Vector3.one, (100 - time--) / 100);
        }
    }

    IEnumerator ShowSlow(GameObject obj, float time)
    {
        float timemax = time;

        obj.SetActive(true);
        obj.transform.localScale = Vector3.zero;

        while (time > 0)
        {
            time -= Time.deltaTime;
            yield return new WaitForSeconds(Time.deltaTime);
            print((timemax - time) / timemax);
            obj.transform.localScale = Vector3.Lerp(Vector3.zero, Vector3.one, (timemax - time) / timemax);
        }
    }
}
