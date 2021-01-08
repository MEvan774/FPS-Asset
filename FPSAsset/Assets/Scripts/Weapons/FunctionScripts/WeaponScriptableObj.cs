using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

[CreateAssetMenu(fileName = "New Weapon", menuName = "Weapon")]
public class WeaponScriptableObj : ScriptableObject
{
    //Semi/Auto
    //Object pooling OBJ + Raycast + Turn on/off particle
    //Reload on Animation + Reload after shot + wind up machinegun barrel + shoot while winding up machine gun barrel
    //Effects, Muzzleflash + ShootSounds + Reload Sounds
    //Animation, Walk + Run, Shoot + reload + Swap
    //Aim down sight [recoil?]

    //Add new scriptable objects for more fire options

    //visual values
    [Header("Weapon visuals/effects")]
    public string weaponName;
    public GameObject weaponModel;


    [Header("Weapon attributes")]
    public float damageValue;
    public float rangeValue;
    public float fireRateValue;
    public float spreadValue;
    public int maxAmmoValue;
    //public int ammoMagNumberValue;

    [Header("Projectile visuals/effects")]
    //public Vector3 fireLocation;
    public ParticleSystem muzzleFlash;
    public AudioSource fireSound;
    public GameObject firePoint;

    [Header("Animations")]
    public Animation ReloadAnim;
    public Animation FireAnim;

    [Header("Aim position")]
    public Vector3 hipPosition;
    public Vector3 aimPosition;
    public float aimSpeed;
    public float rotation;

    [Header("Misc option")]
    public bool fullAuto;
    //public bool burstFire;
    public int burstCount;

    [Space(10)]
    [Header("Weapon sway")]
    public float swayAmount;
    public float maxSwayAmount;
    public float swaySmoothAmount;
    //Base values

    [Header("Aim sway")]
    public float maxSway;
    public float swayTimer;


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

    [Header("Vertical Recoil")]
    public float recoilX;
    public float recoilY;
    [Space(10)]
    public float recoilSmooth;
}
