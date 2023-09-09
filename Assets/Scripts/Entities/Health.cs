using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Health : MonoBehaviour
{
    [SerializeField] private int _health;
    public int HealthPoints => _health;
    public event Action<int> HealthChanged; //TODO: move to eventManager
    public void TakeDamage(int damage)
    {
        _health -= damage;
        HealthChanged?.Invoke(_health);

        if (_health <= 0)
        {
            EventManager.Instance.TriggerEntityDiedEvent(GetComponent<Entity>());
            Destroy(gameObject);
        }
    }

    public void SetHealth(int value)
    {
        _health = value;
    }

}
