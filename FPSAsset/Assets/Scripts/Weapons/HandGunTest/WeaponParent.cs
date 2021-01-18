﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public enum FireTypes { semi, auto, burst }
public class WeaponParent : MonoBehaviour
{
    [SerializeField]
    FireTypes fireType;

    //[Base values (configable with 'WeaponScriptableObj')]
    [SerializeField]
    protected float damage;
    [SerializeField]
    protected float range = 100;
    [SerializeField]
    protected float spread;
    [SerializeField]
    protected int maxAmmo;
    protected int currentAmmo;
    protected bool reloading = false;
    protected bool isSprinting = false;

    [Space(10)]
    [SerializeField]
    protected float fireRate;
    private float nextTimeToFire = 0f;
    [SerializeField]
    protected int burstLeft;
    private int burstReset;

    [Header("Main References")]
    public FirstPersonCam fpsCam;
    public WeaponRecoil recoil;
    public Animator animator;

    //Events
    public UnityEvent aimCenterEvent;
    public UnityEvent aimHipEvent;
    public UnityEvent fireEvent;
    public UnityEvent reloadEvent;

    protected bool isReloading = false;

    protected void Start()
    {
        burstReset = burstLeft;
        currentAmmo = maxAmmo;
    }

    protected virtual void Update()
    {
        Shoot(fireType);
        AimCheck();
    }

    protected virtual void Shoot(FireTypes type)
    {
        if (currentAmmo > 0 && !isReloading)
        {
            if (type == FireTypes.semi && !isSprinting && Input.GetMouseButtonDown(0) && Time.time >= nextTimeToFire ||
                type == FireTypes.auto && !isSprinting && Input.GetMouseButton(0) && Time.time >= nextTimeToFire)
            {
                Fire();
            }
            if (type == FireTypes.burst && !isSprinting && Input.GetMouseButtonDown(0) && Time.time >= nextTimeToFire && burstLeft > 0)//Burst fire
            {
                burstLeft--;
                Fire();
                if (burstLeft <= 0)
                    burstLeft = burstReset;
            }
        }
        else//Reloads if there is no ammo in magazine left
        {
            Debug.Log("Reloading...");
            isReloading = true;
            reloadEvent.Invoke();
            animator.SetBool("IsReloading", true);
        }
    }

    protected virtual void Fire()
    {
        nextTimeToFire = Time.time + 1f / fireRate;
        fireEvent.Invoke();
        Projectile();
        currentAmmo--;
    }


    protected virtual void Projectile()
    {
        RaycastHit hit;

        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
        {

            Debug.Log(hit.transform.name);

            EnemyHealth enemy = hit.transform.GetComponent<EnemyHealth>();
            if (enemy != null)
            {
                //Debug.Log("EnemyFound");
                enemy.TakeDamage(damage);
            }
        }
    }


    private void AimCheck()
    {
        if (Input.GetMouseButton(1) && !isReloading)
        {
            aimCenterEvent.Invoke();
            IsAiming();
        }
        else
        {
            aimHipEvent.Invoke();
        }
    }

    protected virtual void IsAiming()
    {

    }

    public void ReloadEndEvent()
    {
        currentAmmo = maxAmmo;
        animator.SetBool("IsReloading", false);
        isReloading = false;
    }

    public void IsSprinting()
    {
        isSprinting = true;
    }

    public void IsNotSprinting()
    {
        isSprinting = false;
    }
}
