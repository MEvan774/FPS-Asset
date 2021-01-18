using UnityEngine;

public class AnimatorOverrider : MonoBehaviour
{
    private Animator anim;

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    public void SetAnim(AnimatorOverrideController overrideController)
    {
        anim.runtimeAnimatorController = overrideController;
    }
}
