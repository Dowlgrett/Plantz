using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Enemy : Entity
{
    private Tilemap _tilemap;
    private Health _damageable;
    private int _damage;

    private Health _target;

    [SerializeField] private EnemySO _enemySO;

    public event Action EnemyHit;

    public override void DoAction()
    {
        _target = FindAdjacentTargetToAttack();

        if (_target == null)
        {
            _target = GetRandomTarget();

            if (_target == null)
                return;

            if (_target.transform.position.x < transform.position.x)
                Move(Vector3.left);
            else if (_target.transform.position.x > transform.position.x)
                Move(Vector3.right);
            else if (_target.transform.position.y > transform.position.y)
                Move(Vector3.up);
            else if (_target.transform.position.y < transform.position.y)
                Move(Vector3.down);
            return;
        }
        StartCoroutine(AttackAnimation(_target));
        _target.TakeDamage(_damage);
        EnemyHit?.Invoke();
    }

    //TODO: animations aren't the enemy logic, put it somewhere else
    private IEnumerator AttackAnimation(Health target)
    {
        var initialPosition = transform.position;
        var targetPosition = target.transform.position;
        float duration = .1f;
        float timeElapsed = 0f;

        while (timeElapsed < duration)
        {
            transform.position = Vector3.Lerp(initialPosition, targetPosition, timeElapsed / duration);
            timeElapsed += Time.deltaTime;
            yield return null;
        }
        transform.position = targetPosition;

        timeElapsed = 0f;

        while (timeElapsed < duration)
        {
            transform.position = Vector3.Lerp(targetPosition, initialPosition, timeElapsed / duration);
            timeElapsed += Time.deltaTime;
            yield return null;
        }
        transform.position = initialPosition;
    }

    private IEnumerator MoveAnimation(Vector3 targetPosition)
    {
        var initialPosition = transform.position;
        float duration = .1f;
        float timeElapsed = 0f;

        while (timeElapsed < duration)
        {
            transform.position = Vector3.Lerp(initialPosition, targetPosition, timeElapsed / duration);
            timeElapsed += Time.deltaTime;
            yield return null;
        }
        transform.position = targetPosition;
    }


    private void Move(Vector3 moveVector)
    {
        var targetPosition = transform.position + moveVector;
        var enemies = FindObjectsOfType<Enemy>();
        bool canMove = true;

        foreach (var enemy in enemies)
        {
            if (enemy.transform.position == targetPosition)
            {
                canMove = false;
            }
        }
        if (canMove)
            StartCoroutine(MoveAnimation(targetPosition));
    }

    private Health GetRandomTarget()
    {
        List<Health> damageable = FindValidTargetsToAttack();

        if (damageable.Count > 0)
        {
            int randomIndex = UnityEngine.Random.Range(0, damageable.Count);
            return damageable[randomIndex];
        }
        else return null;

    }

    private void Awake()
    {
        _damageable = GetComponent<Health>();
        _damageable.SetHealth(_enemySO.DefaultHealth);
        _damage = _enemySO.DefaultDamage;
    }
    private void Start()
    {
        _tilemap = FindObjectOfType<Tilemap>();
        AudioManager audioManager = FindObjectOfType<AudioManager>();
        EnemyHit += audioManager.OnEnemyHit;
    }

    private Health FindAdjacentTargetToAttack()
    {
        Health closestTarget = null;

        var directions = new Vector3[] //TODO: prioritizing up target first, should be randomized each time
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
        return closestTarget;
    }

    private List<Health> FindValidTargetsToAttack()
    {
        var validTargets = new List<Health>();

        //find empty tiles with no plants
        GrassTileObject[] tiles = FindObjectsOfType<GrassTileObject>();

        foreach (var tile in tiles)
        {
            if (tile.ObjectOnTile != null) continue;

            tile.TryGetComponent<Health>(out var validTile);

            if (validTile != null) validTargets.Add(validTile);
        }

        var plants = FindObjectsOfType<Plant>();

        foreach (var plant in plants)
        {
            if (plant.TryGetComponent<Health>(out var damageable))
            {
                validTargets.Add(damageable);
            }
        }
        return validTargets;
    }
}
