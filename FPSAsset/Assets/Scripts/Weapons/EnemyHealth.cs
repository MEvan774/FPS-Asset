using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : HealthParent
{
    public EnemyScriptableObj ScriptObj;

    void Start()
    {
        maxHP = ScriptObj.enemyMaxHPValue;

        currentHP = maxHP;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage (float amount)
    {
        Debug.Log(gameObject + "Damage" + amount);
        currentHP -= amount;
        NoHP();
    }
}
