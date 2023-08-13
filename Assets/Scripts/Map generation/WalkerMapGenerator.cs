using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class WalkerMapGenerator : MonoBehaviour
{
    private Tilemap _tilemap;
    [SerializeField] private GrassTile _ground;

    public int WalkerCount;
    public int WalkerSteps;

    public void Awake()
    {
        _tilemap = FindObjectOfType<Tilemap>();
        _tilemap.CompressBounds();
        GenerateMap(WalkerCount, WalkerSteps);
    }
    public void GenerateMap(int walkerCount, int walkerSteps)
    {
        List<Walker> walkers = new();
        for (int i = 0; i < walkerCount; i++)
        {
            walkers.Add(new Walker());
        }

        foreach (Walker walker in walkers)
        {
            for (int i = 0; i < walkerSteps; i++)
            {
                _tilemap.SetTile(new Vector3Int(walker.Position.x, walker.Position.y, 0), _ground);
                walker.MakeRandomMove();
            }
            _tilemap.SetTile(new Vector3Int(walker.Position.x, walker.Position.y, 0), _ground);
        }
    }
}
