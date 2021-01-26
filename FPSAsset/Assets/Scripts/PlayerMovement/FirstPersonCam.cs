using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstPersonCam : MonoBehaviour
{
    public WeaponScriptableObj scriptObj;
    private WeaponData weaponData;

    //Camera
    public float sensitivity = 1;
    public Transform Target, Player;
    float mouseX, mouseY;


    //RecoilSystem
    private float recoilY;
    private float recoilX;
    float recoilFireX, recoilFireY;
    private float recoilSmooth = 10;
    private float recoilTime = 1;
    float time;

    Vector2 recoilRemaining;
    public Transform aimPos;


    [Space(10)]
    [Header("Sway Settings")]
    public float maxSway = 10;
    private float smoothX, smoothY;

    public bool isAiming = false;

    public float timer;
    public float partialTimer = 0.4f;
    float counter = 0;

    //Vector3 originalPos;

    float x, y;

    //Quaternion aimRotX, aimRotY;

    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

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
        recoilX = scriptObj.recoilX;
        recoilY = scriptObj.recoilY;
        recoilSmooth = scriptObj.recoilSmooth;
        recoilTime = scriptObj.recoilTime;

        maxSway = scriptObj.maxSway;
        timer = scriptObj.swayTimer;
    }

    void FixedUpdate()
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
        recoilFireY = -recoilY;

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

            //aimRotX = Quaternion.Lerp(transform.rotation, Random.Range(-mouseY.rotation.y, mouseY), smoothX * Time.deltaTime);
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
