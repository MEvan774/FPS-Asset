using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

[CreateAssetMenu(fileName = "New Weapon", menuName = "Weapon")]
public class WeaponScriptableObj : ScriptableObject
{
    //visual values
    [Header("Weapon visuals/effects")]
    public string weaponName;
    //public GameObject weaponPrefab;

    /*
    [Header("Weapon attributes")]
    public float damageValue;
    public float rangeValue;
    public float fireRateValue;
    public float spreadValue;
    public int maxAmmoValue;
    */
    //public int ammoMagNumberValue;

    [Header("Projectile visuals/effects")]
    //public Vector3 fireLocation;
    //public ParticleSystem muzzleFlash;
    public AudioSource fireSound;
    public GameObject firePoint;

    [Header("Animations")]
    public Animation ReloadAnim;
    public Animation FireAnim;

    [Header("Weapon Aim")]
    public Vector3 hipPosition;
    public Vector3 aimPosition;
    public float aimFOV = 55;
    public float aimSpeed = 25;
    public float fovSpeed = 1;

    /*
    [Header("Misc option")]
    public bool fullAuto;
    //public bool burstFire;
    public int burstCount;
    */

    [Space(10)]
    [Header("Weapon Sway")]
    public float swayAmount;
    public float maxSwayAmount;
    public float swaySmoothAmount;

    [Space(10)]
    [Header("Weapon Recoil")]
    public float PositionDampTime;
    public float RotationDampTime;
    [Space(10)]
    public float Recoil1;
    public float Recoil2;
    public float Recoil3;
    public float Recoil4;
    [Space(10)]
    public Vector3 RecoilRotation;
    public Vector3 RecoilKickBack;

    public Vector3 RecoilRotation_Aim;
    public Vector3 RecoilKickBack_Aim;

    [Header("FirstPersonCam/Fire Recoil/ AimSway")]
    public float recoilX;
    public float recoilY;
    public float recoilTime;
    [Space(10)]
    public float recoilSmooth;

    public float maxSway;
    public float swayTimer;

    [Header("UI")]

    public float reticleRestingSize;
    public float reticleMaxSize;
    public float reticleSpeed;
}
