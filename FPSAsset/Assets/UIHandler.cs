using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIHandler : MonoBehaviour
{
    private DSR50 dsr;
    private Msmc msmc;

    [SerializeField]
    private GameObject reticle;

    public WeaponScriptableObj scriptObj;
    private WeaponData weaponData;

    public WeaponSwitching wepSwitch;

    public GameObject[] weapons;
    private int selectedWep = 0;

    private string wepName;
    public TextMeshProUGUI wepNameText;

    private int currentAmmo;
    private int maxAmmo;
    public TextMeshProUGUI wepCurrentAmmoText;
    public TextMeshProUGUI wepMaxAmmoText;

    private void Start()
    {
        SwitchEvent();
    }

    private void Update()
    {
        if (dsr != null)
            currentAmmo = dsr.currentAmmo;
        else
            currentAmmo = msmc.currentAmmo;

        wepCurrentAmmoText.text = currentAmmo.ToString();
    }

    public void SwitchEvent()
    {
        

        int currentWep = wepSwitch.selectedWep;

        //weapons[selectedWep] = weapons[currentWep];

        weaponData = weapons[currentWep].GetComponent<WeaponData>();
        scriptObj = weaponData.weaponData;

        dsr = weapons[currentWep].GetComponent<DSR50>();
        if(dsr == null)
        {
            msmc = weapons[currentWep].GetComponent<Msmc>();
        }
        SetData();
    }

    void SetData()
    {
        wepName = scriptObj.weaponName;
        wepNameText.text = wepName;

        if(dsr == null)
        {
            maxAmmo = msmc.maxAmmo;
        }
        else
        {
            maxAmmo = dsr.maxAmmo;
        }

        wepMaxAmmoText.text = "/ " + maxAmmo;
    }

    public void AimCenterEvent()
    {
        reticle.SetActive(false);
    }

    public void AimHipEvent()
    {
        reticle.SetActive(true);
    }
}
