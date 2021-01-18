using UnityEngine.Events;
using UnityEngine;

public class ReloadEndEventInvoker : MonoBehaviour
{
    public UnityEvent reloadEndEvent;

    public void ReloadEndEvent()
    {
        reloadEndEvent.Invoke();
    }
}
