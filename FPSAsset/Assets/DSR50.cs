using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class DSR50 : WeaponParent
{
    protected override void IsAiming()
    {
        //Make sniper invisible
    }

    protected override void Fire()
    {
        base.Fire();
        if (currentAmmo != 0)
        {
            animator.SetTrigger("AfterShotReloading");
        }
    }
}
