using UnityEngine;

public class FireEffectListener : MonoBehaviour
{
    public GameObject Particles;

    private bool scopeIn = false;

    private void OnEnable()
    {
        Particles.SetActive(false);
    }

    public void AimInEvent()
    {
        scopeIn = true;
    }

    public void AimHipEvent()
    {
        scopeIn = false;
    }

    public void FireEndEvent()
    {
       Particles.SetActive(false);
    }

    public void FireEvent()
    {
        if(!scopeIn)
        Particles.SetActive(true);
    }
}
