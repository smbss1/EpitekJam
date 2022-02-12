using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class OnAwakeHook : MonoBehaviour
{
    [SerializeField] UnityEvent onAwake;
    void Awake()
    {
        onAwake.Invoke();
    }
}
