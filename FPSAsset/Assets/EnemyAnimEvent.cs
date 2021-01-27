using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimEvent : MonoBehaviour
{
    public GameObject muzzleFlash;

    public AudioManager fireSound;

    private void Awake()
    {
        muzzleFlash.SetActive(false);
    }

    public void OnFireEvent()
    {
        muzzleFlash.SetActive(true);
        fireSound.play("EnemyFire");
    }

    public void OnFireStopEvent()
    {
        muzzleFlash.SetActive(false);
    }
}
