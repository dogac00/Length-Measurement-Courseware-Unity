using UnityEngine;

public class DestroyAnimator : MonoBehaviour
{
    public int seconds;

    void Start()
    {
        var anim = this.GetComponent<Animator>();

        this.RunAfter(12000, () =>
        {
            Destroy(anim);
        });
    }
}
