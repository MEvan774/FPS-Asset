using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetWepType : MonoBehaviour
{
    [SerializeField]
    private AnimatorOverrideController[] overrideCon;

    [SerializeField]
    private AnimatorOverrider overrider;

    public void Set (int value)
    {
        overrider.SetAnim(overrideCon[value]);
    }
}
