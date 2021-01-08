using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New projectileType", menuName = "Raycast")]
public class FireRaycastScriptableObject : ScriptableObject
{
    public WeaponScriptableObj scriptObj;
    public Camera fpsCam;
    RaycastHit hit;

    public float damage;
    public float range;
    public float spread;
    public int shotCount = 1;
    public int shotCount_ = 1;
    public GameObject impactEffect;
    //public bullet trail;

    private void Awake()
    {
        fpsCam = Camera.main;
        Debug.Log("AWAKE");
    }

    public void FireEvent()
    {
        //---ACTIVATE TO SETCAMERA!!!---
        if(fpsCam == null)
        {
            fpsCam = Camera.main;
        }
        //----
        //base.Shoot();
        //recoil.Fire();
        if(shotCount > 0)
        {
            Debug.Log("Shot");
            shotCount--;
            float x = Random.Range(-spread, spread);
            float y = Random.Range(-spread, spread);

            Vector3 direction = fpsCam.transform.forward + new Vector3(x, y, 0);

            if (Physics.Raycast(fpsCam.transform.position, direction, out hit, range))
            {
                Debug.Log(hit.transform.name);

                EnemyHealth enemy = hit.transform.GetComponent<EnemyHealth>();
                if (enemy != null)
                {
                    Debug.Log("EnemyFound");
                    enemy.TakeDamage(damage);
                }
                GameObject impact = Instantiate(impactEffect, hit.point, Quaternion.LookRotation(hit.normal));
                Destroy(impact, 2f);
            }
            FireEvent();
        }
        else
        {
            shotCount = shotCount_;
        }
    }
}
