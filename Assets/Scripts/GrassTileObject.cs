using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class GrassTileObject : MonoBehaviour
{
    [SerializeField] private int _health; //should be in a tileObject instead to be inherited
    private GameObject _objectOnTile;
    private Tilemap _tilemap;

    private void Awake()
    {
        Damageable damageable = GetComponent<Damageable>();
        damageable.SetHealth(_health);
    }

    private void Start()
    {
        _tilemap = FindObjectOfType<Tilemap>();
    }

    public GameObject ObjectOnTile => _objectOnTile;

    public void SetObjectOnTile(GameObject objectOnTile)
    {
        _objectOnTile = objectOnTile;
    }

    private void OnDestroy()
    {
        _tilemap.SetTile(_tilemap.WorldToCell(transform.position), null);
    }

}
