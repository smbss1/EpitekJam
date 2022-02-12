using System.Collections;
using System.Collections.Generic;
using UnityAtoms.BaseAtoms;
using UnityEngine;

public class Damager : MonoBehaviour
{
    [SerializeField] private IntReference damageAmount;
    public void Damage(Collider2D collider)
    {
        IDamageable damageable = collider.GetComponent<IDamageable>();

        if (damageable != null)
        {
            damageable.TakeDamage(damageAmount.Value);
        }
    }
}
