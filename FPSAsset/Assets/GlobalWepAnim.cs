using UnityEngine;
using UnityEngine.Animations;

public class GlobalWepAnim : MonoBehaviour
{
    Animator anim;

    bool isSprinting = false;
    float blend = 0;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    void FixedUpdate()
    {
        anim.SetFloat("Blend", blend);

        if (isSprinting && blend < 1)
            blend += 0.05f;
        else if (!isSprinting && blend > 0)
            blend -= 0.05f;
    }

    public void SprintBeginEvent()
    {
        //anim.SetBool("IsSprinting", true);

        isSprinting = true;
    }

    public void SprintEndEvent()
    {
        //anim.SetBool("IsSprinting", false);

        isSprinting = false;
    }

    public void NextAnimStage()
    {
        anim.SetTrigger("NextStage");
    }
}
