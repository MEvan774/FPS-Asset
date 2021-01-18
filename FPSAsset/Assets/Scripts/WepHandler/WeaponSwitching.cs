using UnityEngine;
using UnityEngine.Events;

public class WeaponSwitching : MonoBehaviour
{
    // Start is called before the first frame update
    private int selectedWep = 0;
    public GameObject[] wep;

    public AnimatorControllerParameter[] anims;
    public SetWepType wepType;

    public UnityEvent wepSwapEvent;

    void Start()
    {
        wep[0].SetActive(true);
        wep[1].SetActive(false);

        //anims[0] = wep[0].GetComponent<Animator>();
        //anims[1] = wep[1].GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Alpha1) && selectedWep != 0)
        {
            selectedWep = 0;
            wepType.Set(0);
            wep[0].SetActive(true);
            wep[1].SetActive(false);
            WepSwapEvent();
        }
        if (Input.GetKey(KeyCode.Alpha2) && selectedWep != 1)
        {
            selectedWep = 1;
            wepType.Set(1);
            wep[0].SetActive(false);
            wep[1].SetActive(true);
            WepSwapEvent();
        }
    }

    void WepSwapEvent()
    {
        wepSwapEvent.Invoke();
    }
}
