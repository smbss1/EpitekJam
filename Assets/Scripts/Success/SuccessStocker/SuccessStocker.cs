using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuccessStocker : MonoBehaviour
{
    public SuccessObject[] successes;

    public static SuccessStocker instance;

    private void Awake()
    {
        if (instance != null)
            Debug.Log("pas bien là répare");
        instance = this;
    }
}
