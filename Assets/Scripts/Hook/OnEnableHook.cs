using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine;
using Sirenix.OdinInspector;

public class OnEnableHook : MonoBehaviour
{
    [SerializeField] UnityEvent onEnableUnity;

    void OnEnable()
    {
        onEnableUnity.Invoke();
    }
}
