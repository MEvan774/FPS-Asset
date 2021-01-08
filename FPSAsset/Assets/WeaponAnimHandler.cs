using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class WeaponAnimHandler : MonoBehaviour
{
    public Animator animator;
    public UnityEvent reloadEnd;

    public void AnimReloadStart()
    {
        animator.SetBool("IsReloading", true);
    }

    public void AnimReloadEndEvent()
    {
        animator.SetBool("IsReloading", false);
        reloadEnd.Invoke();
    }

}
