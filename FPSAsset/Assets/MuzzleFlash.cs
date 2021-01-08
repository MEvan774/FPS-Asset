using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MuzzleFlash : MonoBehaviour
{
    //public GameObject muzzleFlash;
    public ParticleSystem muzzleFlash;
    public AudioManager audioManager;
    public void FireEvent()
    {
        if(muzzleFlash == null || audioManager == null)
        {
            audioManager = FindObjectOfType<AudioManager>();
            //muzzleFlash = GetComponent<ParticleSystem>();
        }
        //Debug.Log("Fire particle effect");
        muzzleFlash.Play();
        //Instantiate(muzzleFlash);
        //audioManager.play("FireGlock");
    } 
}
