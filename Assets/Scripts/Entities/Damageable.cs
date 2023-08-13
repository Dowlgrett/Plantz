using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Damageable : MonoBehaviour
{
    private int _health;

    public int Health => _health;

    public event Action<int> HealthChanged;

    public void TakeDamage(int damage)
    {
        _health -= damage;
        HealthChanged?.Invoke(_health);

        if (_health <= 0)
        {
            Destroy(gameObject);
        }
    }

    public void SetHealth(int value)
    {
        _health = value;
    }

}
