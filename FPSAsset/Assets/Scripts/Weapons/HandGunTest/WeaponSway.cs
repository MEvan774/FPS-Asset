using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSway : MonoBehaviour
{
    public WeaponSpawner swapWeapon;

    public float amount;
    public float maxAmount;
    public float smoothAmount;
    bool aim = false;

    private Vector3 initialPosition;

    void Start()
    {
        initialPosition = transform.localPosition;
    }

    // Update is called once per frame
    void Update()
    {
        Sway();
    }

    void Sway()
    {
        float movementX = -Input.GetAxis("Mouse X") * amount;
        float movementY = -Input.GetAxis("Mouse Y") * amount;

        Vector3 finalPosition = new Vector3(movementX, movementY, 0);
        //limiting movement
        if (aim)
        {
            movementX = Mathf.Clamp(movementX, 0, 0);
            movementY = Mathf.Clamp(movementY, 0, 0);
            transform.localPosition = Vector3.Lerp(transform.localPosition, initialPosition, Time.deltaTime * 100);
        }
        else
        {
            movementX = Mathf.Clamp(movementX, -maxAmount, maxAmount);
            movementY = Mathf.Clamp(movementY, -maxAmount, maxAmount);

            transform.localPosition = Vector3.Lerp(transform.localPosition, finalPosition + initialPosition, Time.deltaTime * smoothAmount);
        }


    }

    public void AimCenterEvent()
    {
        aim = true;
    }

    public void AimHipEvent()
    {
        aim = false;
    }
}
