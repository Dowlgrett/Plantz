using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class WalkerMapGenerator : MonoBehaviour
{
    private Tilemap _tilemap;

    [SerializeField] private Tile _ground;

    public void Awake()
    {
        _tilemap = FindObjectOfType<Tilemap>().GetComponent<Tilemap>();
        GenerateMap(5, 5);
    }




    public void GenerateMap(int walkerCount, int walkerSteps)
    {
        List<Walker> walkers = new List<Walker>();
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
