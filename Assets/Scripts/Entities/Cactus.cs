using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cactus : Entity
{
    //TODO: get damage from SO
    private int _damage = 4;


    public override void DoAction()
    {
        var target = GetEnemyToAttack();
        if (target != null)
        {
            if (target.TryGetComponent(out Health health))
                health.TakeDamage(_damage);
        }
    }

    public Hostile GetEnemyToAttack()
    {
        var enemies = FindObjectsOfType<Hostile>();

        if (enemies != null && enemies.Length != 0)
        {
            var index = Random.Range(0, enemies.Length);
            return enemies[index];
        }
        else return null;

    }
}
