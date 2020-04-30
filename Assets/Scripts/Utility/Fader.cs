using System.Collections;
using UnityEngine;

public class Fader : MonoBehaviour
{
    void Start()
    {
        var go = this.gameObject;
        go.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1);

        StartCoroutine(FadeRoutine(go.GetComponent<SpriteRenderer>()));
    }

    IEnumerator FadeRoutine(SpriteRenderer sprite)
    {
        float a = sprite.color.a;

        while (a > 0)
        {
            sprite.color = new Color(1, 1, 1, a);
            a -= 0.04F;

            yield return null;
        }
        
        sprite.color = new Color(1, 1, 1, 0);
    }
}
