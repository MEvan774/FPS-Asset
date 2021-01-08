using UnityEngine;
using UnityEngine.Events;

public class WeaponManager : MonoBehaviour
{
    public WeaponScriptableObj[] gunInventory;
    public MainWeapon mainWeapon;
    public WeaponSpawner swapWeapon;
    private int currentWeapon = 0;

    public UnityEvent wepSwapEvent;

    // Start is called before the first frame update
    void Start()
    {
        //swapWeapon.weaponModel = gunInventory[0].weaponModel;
        //swapWeapon.scriptObj = gunInventory[0];
        //swapWeapon.wepSwapEvent();
        //wepSwapEvent.Invoke();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Alpha1) && currentWeapon != 0)
        {
            currentWeapon = 0;
            swapWeapon.scriptObj = gunInventory[0];
            wepSwapEvent.Invoke();
        }
        if (Input.GetKey(KeyCode.Alpha2) && currentWeapon != 1)
        {
            currentWeapon = 1;
            swapWeapon.scriptObj = gunInventory[1];
            wepSwapEvent.Invoke();
        }
    }
}
