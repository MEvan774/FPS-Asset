using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Enemy", menuName = "Enemy")]
public class EnemyScriptableObj : ScriptableObject
{
    public string enemyName;
    public GameObject weaponModel;

    public int enemyMaxHPValue;
    public float enemyAttackValue;

    public float enemySpeedValue;

}
