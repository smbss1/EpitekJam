using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityAtoms.BaseAtoms;
using UnityEngine;
using UnityEngine.Events;

public class HealthSystem : MonoBehaviour, IDamageable
{
    [SerializeField] IntReference health;
    [SerializeField] IntReference maxHealth;
    [SerializeField] bool resetHP;
    [SerializeField] bool knockback;

    [SerializeField] UnityEvent DamagedEvent;
    [ShowIf("knockback")]
    [SerializeField] UnityVector2ForceModeEvent HitEvent;
    [SerializeField] UnityEvent KilledEvent;

    bool isDied;

    /*public bool IsDied { get { return isDied; } set { isDied = value; } }*/

    private void Start()
    {
        if (resetHP)
        {
            ResetHealth();
        }
    }

    public void Hit(Vector2 launch)
    {
        if (isDied)
            return;

        if (knockback)
        {
            HitEvent.Invoke(launch, ForceMode2D.Impulse);
        }
    }

    public void TakeDamage(int amount)
    {
        if (isDied)
        {
            return;
        }

        health.Value -= amount;
        DamagedEvent.Invoke();

        if (health.Value <= 0)
        {
            Die();
        }
    }

    public void TakeDamage(IntVariable amount)
    {
        TakeDamage(amount.Value);
    }

    public void Die()
    {
        isDied = true;
        KilledEvent.Invoke();
    }

    public void ResetHealth()
    {
        health.Value = maxHealth.Value;
    }
}
[System.Serializable]
public class UnityVector2ForceModeEvent : UnityEvent<Vector2, ForceMode2D> { }