using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class WeaponAnimHandler : MonoBehaviour
{
    Animator anim;
    public UnityEvent reloadEnd;


    private void Start()
    {
        anim = GetComponent<Animator>();
    }
    public void AnimReloadStart()
    {
        anim.SetBool("IsReloading", true);
    }

    public void AnimReloadEndEvent()
    {
        anim.SetBool("IsReloading", false);
        reloadEnd.Invoke();
    }

}
