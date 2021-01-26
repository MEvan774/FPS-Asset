using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class DSR50 : WeaponParent
{
    //public GameObject[] prefabs;
    public GameObject[] objects;

    public GameObject ScopeUI;

    private bool aiming = false;

    protected override void IsAiming()
    {
        //Make sniper invisible
        if (!aiming)
        {
            aiming = true;
            for (int i = 0; i < objects.Length; i++)
            {
                objects[i].SetActive(false);
            }
        }

        //render.material = new 

        ScopeUI.SetActive(true);
    }

    protected override void IsNotAiming()
    {
        if (aiming)
        {

            aiming = false;
            for (int i = 0; i < objects.Length; i++)
            {
                objects[i].SetActive(true);
            }
        }

        ScopeUI.SetActive(false);
    }

    protected override void Fire()
    {
        base.Fire();
        audioManager.play("DsrFire");
        if (currentAmmo != 0)
        {
            animator.SetTrigger("AfterShotReloading");
        }
    }
}
