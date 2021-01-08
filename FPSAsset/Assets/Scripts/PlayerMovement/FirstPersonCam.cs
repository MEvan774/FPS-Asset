using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstPersonCam : MonoBehaviour
{
    public WeaponSpawner swapWeapon;
    WeaponScriptableObj scriptObj;

    //Camera
    public float sensitivity = 1;
    public Transform Target, Player;
    float mouseX, mouseY;


    //RecoilSystem
    public float recoilY;
    public float recoilX;
    float recoilFireX, recoilFireY;
    public float recoilSmooth = 10;
    public float recoilTime = 1;
    float time;

    Vector2 recoilRemaining;
    public Transform aimPos;


    [Space(10)]
    [Header("Sway Settings")]
    public float maxSway = 10;
    public float smoothX, smoothY;

    public bool isAiming = false;

    public float timer;
    public float partialTimer = 0.4f;
    float counter = 0;

    //Vector3 originalPos;

    float x;
    float y;

    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    //Random.Range(-maxAmount, maxAmount), Random.Range(-maxAmount, maxAmount)

    void Update()
    {
        CamControl();
    }

    void CamControl()
    {
        mouseX += recoilFireX + smoothX + Input.GetAxis("Mouse X") * sensitivity * Time.deltaTime;
        mouseY -= -recoilFireY + smoothY + Input.GetAxis("Mouse Y") * sensitivity * Time.deltaTime;

        time -= Time.deltaTime;
        if(time > 0)
        {
            recoilFireX = recoilSmooth * Time.deltaTime;
            recoilFireY -= recoilSmooth * Time.deltaTime;
        }
        else
        {
            recoilFireX = 0;
            recoilFireY = 0;
        }



        //Prevent camera from going upside down when moving up or down
        mouseY = Mathf.Clamp(mouseY, -35, 60);

        transform.LookAt(Target);

        Target.rotation = Quaternion.Euler(mouseY, mouseX, 0);
        Player.rotation = Quaternion.Euler(0, mouseX, 0);
    }

    public Quaternion GetRotation()
    {
        return Target.rotation;
    }

    public void FireEvent()
    {
        //Vertical recoil
        recoilFireX = Random.Range(-recoilX, recoilX);
        recoilFireY = Random.Range(0, -recoilY);

        time = recoilTime;
    }

    //Aim sway event
    public void AimCenterEvent()
    {
        counter += Time.deltaTime;

        if (counter > timer)
        {
            //Debug.Log("Counter endAim");
            counter = 0;

            x = Random.Range(-maxSway, maxSway);
            y = Random.Range(-maxSway, maxSway);

            smoothX = x * Time.deltaTime;
            smoothY = y * Time.deltaTime;
        }

    }

    //Aim sway event disable
    public void AimHipEvent()
    {
        //Debug.Log("Hip");
        x = 0;
        y = 0;
        smoothX = 0;
        smoothY = 0;
    }
}
