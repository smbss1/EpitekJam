
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.Events;

public class OnStartHook : MonoBehaviour
{
    [SerializeField] UnityEvent onStartUnity;

    void Start()
    {
        onStartUnity.Invoke();
    }
}
