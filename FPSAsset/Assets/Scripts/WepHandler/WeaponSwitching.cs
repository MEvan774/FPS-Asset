using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class WeaponSwitching : MonoBehaviour
{
    // Start is called before the first frame update
    public int selectedWep = 0;
    private int prevWep = 1;
    public GameObject[] wep;

    public AnimatorControllerParameter[] anims;
    public SetWepType wepType;

    public UnityEvent wepSwapEvent;
    public UnityEvent swapOutAnimEvent;

    private bool switching = false;

    [SerializeField]
    private float switchTimer;

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
        if (!switching)
        {
            if (Input.GetKey(KeyCode.Alpha1) && selectedWep != 0)
            {
                switching = true;
                swapOutAnimEvent.Invoke();
                prevWep = 1;
                selectedWep = 0;
                StartCoroutine(SwapOut());
            }
            if (Input.GetKey(KeyCode.Alpha2) && selectedWep != 1)
            {
                switching = true;
                swapOutAnimEvent.Invoke();
                prevWep = 0;
                selectedWep = 1;
                StartCoroutine(SwapOut());
            }
        }

    }

    IEnumerator SwapOut()
    {
        yield return new WaitForSeconds(switchTimer);
        wepType.Set(selectedWep);
        wep[prevWep].SetActive(false);
        wep[selectedWep].SetActive(true);
        WepSwapEvent();
        switching = false;
    }

    void WepSwapEvent()
    {
        wepSwapEvent.Invoke();
    }
}
