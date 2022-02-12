using System.Collections;
using System.Collections.Generic;
using UnityAtoms.BaseAtoms;
using UnityEngine;

public class Hook : MonoBehaviour
{
    [SerializeField] private GameObjectReference playerRef;

    public void HookPlayer(Collider2D collider)
    {
        RotateToMouse player = playerRef.Value.GetComponent<RotateToMouse>();
        player.HookPosition = transform.position;
        player.IsHook = true;
    }
}
