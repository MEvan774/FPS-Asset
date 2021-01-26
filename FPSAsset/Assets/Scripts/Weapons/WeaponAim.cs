using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponAim : MonoBehaviour
{
    private WeaponScriptableObj scriptObj;
    private WeaponData weaponData;

    public Vector3 hipPosition;
    public Vector3 aimPosition;

    public float aimSpeed = 25f;
    private float fovSpeed = 1;

    public Camera mainCamera;
    private float aimFOV = 55;
    private float defaultFOV;
    private bool isSprinting = false;

    void Start()
    {
        //float mainSpeed = aimSpeed;
        defaultFOV = mainCamera.fieldOfView;
        SwitchEvent();
    }

    public void SwitchEvent()
    {
        weaponData = GetComponentInChildren<WeaponData>();
        scriptObj = weaponData.weaponData;
        SetData();
    }

    void SetData()
    {
        hipPosition = scriptObj.hipPosition;
        aimPosition = scriptObj.aimPosition;
        aimFOV = scriptObj.aimFOV;
        aimSpeed = scriptObj.aimSpeed;
        fovSpeed = scriptObj.fovSpeed;
    }

    public void AimCenterEvent()
    {
        if (!isSprinting)
        {
            //Debug.Log("EVENTON");
            if (mainCamera.fieldOfView > aimFOV)
            {
                mainCamera.fieldOfView -= fovSpeed;
            }
            transform.localPosition = Vector3.Slerp(transform.localPosition, aimPosition, Time.deltaTime * aimSpeed);
        }
    }

    public void AimHipEvent()
    {
         //Debug.Log("EVENTOFF");
         if (mainCamera.fieldOfView < defaultFOV)
         {
             mainCamera.fieldOfView += fovSpeed;
         }
         transform.localPosition = Vector3.Slerp(transform.localPosition, hipPosition, Time.deltaTime * aimSpeed);
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
