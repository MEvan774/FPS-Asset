using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadBob : MonoBehaviour
{
    private float timer = 0.0f;
    public float bobbingSpeed = 0.18f;
    public float bobbingAmount = 0.2f;
    public float midPoint = 2.0f;

    public float bobbingSpeedSprint;
    public float bobbingAmountSprint;
    public float midPointSprint;

    private float speedReset, amountReset, midReset;

    private void Start()
    {
        speedReset = bobbingSpeed;
        amountReset = bobbingAmount;
        midReset = midPoint;
    }

    void FixedUpdate()
    {
        float waveSlice = 0.0f;
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        if (Mathf.Abs(horizontal) == 0 && Mathf.Abs(vertical) == 0)
        {
            timer = 0.0f;
        }
        else
        {
            waveSlice = Mathf.Sin(timer);
            timer = timer + bobbingSpeed;
            if (timer > Mathf.PI * 2)
            {
                timer = timer - (Mathf.PI * 2);
            }
        }

        if (waveSlice != 0)
        {
            float translateChange = waveSlice * bobbingAmount;
            float totalAxes = Mathf.Abs(horizontal) + Mathf.Abs(vertical);
            totalAxes = Mathf.Clamp(totalAxes, 0.0f, 1.0f);
            translateChange = totalAxes * translateChange;
            transform.localPosition = new Vector3(transform.localPosition.x, midPoint + translateChange, transform.localPosition.z);

        }
        else
        {
            transform.localPosition = new Vector3(transform.localPosition.x, midPoint, transform.localPosition.z);
        }
    }

    public void IsSprinting()
    {
        bobbingSpeed = bobbingSpeedSprint;
        bobbingAmount = bobbingAmountSprint;
        midPoint = midPointSprint;
    }

    public void IsNotSprinting()
    {
        bobbingSpeed = speedReset;
        bobbingAmount = amountReset;
        midPoint = midReset;
    }
}
