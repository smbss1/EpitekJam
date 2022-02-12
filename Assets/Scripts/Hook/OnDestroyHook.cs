using UnityEngine;
using UnityEngine.Events;

public class OnDestroyHook : MonoBehaviour
{
    [SerializeField] UnityEvent onDestroy;
    void OnDestroy()
    {
        onDestroy.Invoke();
    }
}
