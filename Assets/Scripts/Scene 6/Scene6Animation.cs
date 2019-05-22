using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scene6Animation : MonoBehaviour
{
    private Animator RulerAnimator, ArrowAnimator;

    // Start is called before the first frame update
    void Start()
    {
        RulerAnimator = this.gameObject.GetComponent<Animator>();
        ArrowAnimator = this.transform.GetChild(0).GetComponent<Animator>();

        RulerAnimator.enabled = ArrowAnimator.enabled = false;

        StartCoroutine(AnimateRuler());
    }

    IEnumerator AnimateRuler()
    {
        yield return new WaitForSeconds(4);

        RulerAnimator.Play("RulerAnimation");
        RulerAnimator.enabled = true;

        ArrowAnimator.Play("ArrowAnimation");
        ArrowAnimator.enabled = true;

        yield return null;
    }
}
