using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Reticle : MonoBehaviour
{
    private UIHandler UIh;

    private RectTransform reticle;

    private float restingSize;
    private float maxSize;
    private float speed;

    private float currentsize;

    private void Start()
    {
        UIh = GetComponentInParent<UIHandler>();
        reticle = GetComponent<RectTransform>();

        SwitchEvent();
    }

    public void SwitchEvent()
    {
        SetData();
    }

    void SetData()
    {
        if (UIh != null)
        {
            restingSize = UIh.scriptObj.reticleRestingSize;
            maxSize = UIh.scriptObj.reticleMaxSize;
            speed = UIh.scriptObj.reticleSpeed;
        }
        else
        {
            UIh = GetComponentInParent<UIHandler>();
            SetData();
        }
    }

    private void Update()
    {
        if (isMoving)
        {
            currentsize = Mathf.Lerp(currentsize, maxSize, Time.deltaTime * speed);
        }
        else
        {
            currentsize = Mathf.Lerp(currentsize, restingSize, Time.deltaTime * speed);
        }

        reticle.sizeDelta = new Vector2(currentsize,currentsize);
    }

    bool isMoving
    {
        get
        {
            if (Input.GetAxis("Horizontal") != 0
                || Input.GetAxis("Vertical") != 0 
                || Input.GetAxis("Mouse X") != 0 
                || Input.GetAxis("Mouse Y") != 0)
            
                return true;
                else
                    return false;
            
        }
    }
}
