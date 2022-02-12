using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityAtoms.BaseAtoms;
using UnityEngine;

public class VirtualSetFollow : MonoBehaviour
{
    [SerializeField] private GameObjectReference follow;
    private CinemachineVirtualCamera vCam;

    private void Awake()
    {
        vCam = GetComponent<CinemachineVirtualCamera>();
        
        if (follow.Value)
            SetFollow(follow.Value);
    }

    public void SetFollow(GameObject _follow)
    {
        vCam.Follow = _follow.transform;
    }

    public void SetOrthoSize(float value)
    {
        vCam.m_Lens.OrthographicSize = value;
    }

    public void SetOffset(Vector2 value)
    {
        GetComponent<CinemachineCameraOffset>().m_Offset = value;
    }

    public void SetConfinerDamping(float value)
    {
        GetComponent<CinemachineConfiner>().m_Damping = value;
    }

    public void ResetFollow()
    {
        vCam.Follow = null;
    }
}
