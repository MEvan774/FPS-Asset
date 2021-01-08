using UnityEngine;

public class SwitchWeapon : MonoBehaviour
{
    public int SelectedWeapon = 0;
    private bool aim = false;


    void Start()
    {
        SelectWeapon();
    }

    // Update is called once per frame
    void Update()
    {

        int PreviousSelectedWeapon = SelectedWeapon;

        if (Input.GetAxis("Mouse ScrollWheel") > 0f && aim == false)
        {
            if (SelectedWeapon >= transform.childCount - 1)
                SelectedWeapon = 0;
            else
                SelectedWeapon++;
        }
        if (Input.GetAxis("Mouse ScrollWheel") < 0f && aim == false)
        {
            if (SelectedWeapon <= 0)
                SelectedWeapon = transform.childCount - 1;
            else
                SelectedWeapon++;
        }
        //Weapon1(HandGun)
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            SelectedWeapon = 0;
        }

        //Weapon2(AssaultRifle)
        if (Input.GetKeyDown(KeyCode.Alpha2) && transform.childCount >=2)
        {
            SelectedWeapon = 1;
        }

        //Add new weapon slot by increasing number in [exampple]:
        //(KeyCode.Alpha[Keyboard number]), transform.childCount >= [wich child from weaponManager] and SelectedWeapon = [number];

        //Weapon3
        //if (Input.GetKeyDown(KeyCode.Alpha3) && transform.childCount >= 3)
        //{
        //    SelectedWeapon = 2;
        //}

        if (PreviousSelectedWeapon != SelectedWeapon)
        {
            SelectWeapon();
        }
    }


    void SelectWeapon()
    {
        int i = 0;
        foreach (Transform weapon in transform)
        {
            if (i == SelectedWeapon)
                weapon.gameObject.SetActive(true);
            else
                weapon.gameObject.SetActive(false);
            i++;
        }
    }
}
