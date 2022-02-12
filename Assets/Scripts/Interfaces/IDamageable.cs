using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDamageable
{
    void Hit(Vector2 launchDirection);
    void TakeDamage(int amount);
}
