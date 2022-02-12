
using UnityEngine;
using Sirenix.OdinInspector;
using UnityAtoms.BaseAtoms;

public class OnTriggerScript : MonoBehaviour
{
    public bool verifyTag = true;
    
    public bool triggerEnter;
    public bool triggerStay;
    public bool triggerExit;
    
    [Tag, ShowIf("@verifyTag")]
    public string tagField = "";

    [ShowIf("@triggerEnter")]
    public Collider2DUnityEvent onUnityTriggerEnter;
    [ShowIf("@triggerStay")]
    public Collider2DUnityEvent onUnityTriggerStay;
    [ShowIf("@triggerExit")]
    public Collider2DUnityEvent onUnityTriggerExit;
    

    void OnTriggerEnter2D(Collider2D other)
    {
        if (verifyTag)
        {
            if (tagField == null || string.IsNullOrEmpty(tagField) || string.IsNullOrEmpty(tag)) return;
            if (other.CompareTag(tagField))
                RaiseEnter(other);
        }
        else
        {
            RaiseEnter(other);
        }
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (verifyTag)
        {
            if (tagField == null || string.IsNullOrEmpty(tagField) || string.IsNullOrEmpty(tag)) return;
            if (other.CompareTag(tagField))
                RaiseStay(other);
        }
        else
        {
            RaiseStay(other);
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (verifyTag)
        {
            if (tagField == null || string.IsNullOrEmpty(tagField) || string.IsNullOrEmpty(tag)) return;
            if (other.CompareTag(tagField))
                RaiseExit(other);
        }
        else
        {
            RaiseExit(other);
        }
    }
    
    void RaiseEnter(Collider2D other)
    {
        onUnityTriggerEnter.Invoke(other);
    }
    
    void RaiseStay(Collider2D other)
    {
        onUnityTriggerStay.Invoke(other);
    }
    
    void RaiseExit(Collider2D other)
    {
        onUnityTriggerExit.Invoke(other);
    }
}
