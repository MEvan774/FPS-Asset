using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimSway : MonoBehaviour
{
    public bool isAiming = false;
    public float timer;
    public float counter = 0;
    [Space(10)]
    [Header("Sway Settings")]
    public float maxSway = 10;
    public float magnitude = 5;

    public float smooth = 5;

    //Vector3 originalPos;
    Vector3 originalPos = new Vector3(0, 0, 0);

    float x;
    float y;

    public void AimCenterEvent()
    {
        counter += Time.deltaTime;

        if (counter > timer)
        {
            Debug.Log("Counter endSway");
            counter = 0;

            x = Random.Range(-maxSway, maxSway);
            y = Random.Range(-maxSway, maxSway);
        }

        Vector3 targetPosition = new Vector3(x, y, 0);
        transform.localPosition = Vector3.Lerp(transform.localPosition, targetPosition, smooth * Time.deltaTime);
    }

    public void AimHipEvent()
    {
        transform.localPosition = originalPos;
    }

}
