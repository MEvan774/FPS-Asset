using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthParent : MonoBehaviour
{
    public float maxHP;
    public float currentHP;

    protected bool death = false;

    public void getHit()
    {

    }

    public void NoHP()
    {
        if (currentHP <= 0)
        {
            death = true;
            Destroy(gameObject);
        }
    }
}
