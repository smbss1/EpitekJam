using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityAtoms.BaseAtoms;
using UnityEngine;

public class OnCollider2DHook : MonoBehaviour
{
    public bool verifyTag = true;
    
    public bool collisionEnter;
    public bool collisionStay;
    public bool collisionExit;
    
    [Tag, ShowIf("@verifyTag")]
    public string tagField = "";

    [ShowIf("@collisionEnter")]
    public Collision2DUnityEvent onUnityTriggerEnter;
    [ShowIf("@collisionStay")]
    public Collision2DUnityEvent onUnityTriggerStay;
    [ShowIf("@collisionExit")]
    public Collision2DUnityEvent onUnityTriggerExit;
    

    void OnCollisionEnter2D(Collision2D other)
    {
        if (verifyTag)
        {
            if (tagField == null || string.IsNullOrEmpty(tagField) || string.IsNullOrEmpty(tag)) return;
            if (other.collider.CompareTag(tagField))
                RaiseEnter(other);
        }
        else
        {
            RaiseEnter(other);
        }
    }

    void OnCollisionStay2D(Collision2D other)
    {
        if (verifyTag)
        {
            if (tagField == null || string.IsNullOrEmpty(tagField) || string.IsNullOrEmpty(tag)) return;
            if (other.collider.CompareTag(tagField))
                RaiseStay(other);
        }
        else
        {
            RaiseStay(other);
        }
    }

    void OnCollisionExit2D(Collision2D other)
    {
        if (verifyTag)
        {
            if (tagField == null || string.IsNullOrEmpty(tagField) || string.IsNullOrEmpty(tag)) return;
            if (other.collider.CompareTag(tagField))
                RaiseExit(other);
        }
        else
        {
            RaiseExit(other);
        }
    }
    
    void RaiseEnter(Collision2D other)
    {
        onUnityTriggerEnter.Invoke(other);
    }
    
    void RaiseStay(Collision2D other)
    {
        onUnityTriggerStay.Invoke(other);
    }
    
    void RaiseExit(Collision2D other)
    {
        onUnityTriggerExit.Invoke(other);
    }
}
