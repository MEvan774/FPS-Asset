using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Msmc : WeaponParent
{
    protected override void Fire()
    {
        base.Fire();
        audioManager.play("MsmcFire");
    }
}
