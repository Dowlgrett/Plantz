using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class GrassTileObject : MonoBehaviour
{
    private GameObject _objectOnTile;
    private Tilemap _tilemap;
    private void Awake()
    {
        Health damageable = GetComponent<Health>();
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
