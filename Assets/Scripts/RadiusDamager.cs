using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RadiusDamager : Damager
{
    [SerializeField] private float radius;
    [SerializeField] private LayerMask whatIsDamageable;

    public void Damage()
    {
        RaycastHit2D[] hits = Physics2D.CircleCastAll(transform.position, radius, Vector2.down, .2f, whatIsDamageable);

        foreach (var hit in hits)
        {
            if (hit.collider != null)
            {
                IDamageable damageable = hit.collider.GetComponent<IDamageable>();
                if (damageable != null)
                {
                    damageable.TakeDamage(DamageAmout.Value);
                }
            }
        }
    }

    public void Kick(Collision2D collision)
    {
        IDamageable damageable = collision.collider.GetComponent<IDamageable>();
        if (damageable != null)
        {
            if (collision.collider.TryGetComponent<Rigidbody2D>(out Rigidbody2D rb2d))
            {
                Vector3 direction = transform.position - collision.transform.position;
                damageable.Hit(-rb2d.velocity * 2);
            }
            
            
            // Vector3 direction = transform.position - collision.transform.position;
            // if (collision.collider.TryGetComponent<Rigidbody2D>(out Rigidbody2D rb2d))
            // {
            //     rb2d.AddForce(-direction * 5, ForceMode2D.Impulse);
            // }
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}
