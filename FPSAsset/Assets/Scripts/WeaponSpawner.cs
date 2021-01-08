using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSpawner : MonoBehaviour
{
    public MainWeapon mainWeapon;
    public GameObject weaponModel;
    public WeaponManager manager;
    public WeaponScriptableObj scriptObj;

    private void Start()
    {
        //scriptObj = manager.gunInventory[0];
    }

    public void wepSwapEvent()
    {
        Debug.Log("WEPSWAP");
            //places/replaces weaponPrefab
            Destroy(weaponModel);
            weaponModel = scriptObj.weaponModel;
            weaponModel = Instantiate(weaponModel, transform.position, transform.rotation, this.transform.parent);

        mainWeapon = weaponModel.GetComponent<MainWeapon>();
        scriptObj = mainWeapon.scriptObj;
    }
}
