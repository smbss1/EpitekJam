using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class OnDisableHook : MonoBehaviour
{
    [SerializeField] UnityEvent onDisable;
    void OnDisable()
    {
        onDisable.Invoke();
    }
}
