using UnityEngine;

public class DsrAnimEvents : MonoBehaviour
{
    AudioManager audioManager;


    private void Start()
    {
        audioManager = FindObjectOfType<AudioManager>();
    }

    public void DsrMagIn()
    {
        audioManager.play("DsrMagIn");
    }

    public void DsrMagOut()
    {
        audioManager.play("DsrMagOut");
    }

    public void MsmcMagIn()
    {
        audioManager.play("MsmcMagIn");
    }

    public void MsmcMagOut()
    {
        audioManager.play("MsmcMagOut");
    }

    public void MsmcCharge()
    {
        audioManager.play("MsmcCharge");
    }
}
