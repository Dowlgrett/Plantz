using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Enemy : Entity
{
    private Tilemap _tilemap;
    private Damageable _damageable;
    private int _damage;

    [SerializeField] private EnemySO _enemySO;

    public override void DoAction()
    {
        var target = FindClosestTargetToAttack();

        if (target == null) //TODO: for test
            return;
        target.TakeDamage(_damage);

    }

    private void Awake()
    {
        _damageable = GetComponent<Damageable>();
        _damageable.SetHealth(_enemySO.DefaultHealth);
        _damage = _enemySO.DefaultDamage;
    }
    private void Start()
    {
        _tilemap = FindObjectOfType<Tilemap>();
    }

    private Damageable FindClosestTargetToAttack()
    {
        Damageable closestTarget = null;

        var directions = new Vector3[]
        {
            Vector3.up,
            Vector3.down,
            Vector3.left,
            Vector3.right
        };

        var targets = FindValidTargetsToAttack();

        foreach (var target in targets)
        {
            if (closestTarget != null) break;

            var targetPosition = _tilemap.GetCellCenterWorld(_tilemap.WorldToCell(target.transform.position));
            var myPosition = _tilemap.GetCellCenterWorld(_tilemap.WorldToCell(transform.position));

            foreach (Vector3 direction in directions)
            {
                Vector3 positionToAttack = myPosition + direction;

                if (targetPosition == positionToAttack)
                {
                    closestTarget = target;
                    break;
                }
            }
        }
        return closestTarget; //TODO: potential null return
    }

    private List<Damageable> FindValidTargetsToAttack()
    {
        var validTargets = new List<Damageable>();

        //find empty tiles with no plants
        GrassTileObject[] tiles = FindObjectsOfType<GrassTileObject>();

        foreach (var tile in tiles)
        {
            if (tile.ObjectOnTile != null) continue;

            tile.TryGetComponent<Damageable>(out var validTile);
            
            if (validTile != null) validTargets.Add(validTile);
        }

        var plants = FindObjectsOfType<Plant>();

        foreach (var plant in plants)
        {
            if (plant.TryGetComponent<Damageable>(out var damageable))
            {
                validTargets.Add(damageable);
            }
        }
        return validTargets;
    }
}
