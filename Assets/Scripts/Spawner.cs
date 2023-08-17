using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Tilemap _tilemap;
    [SerializeField] private GameObject _prefab;

    private void Start()
    {
        List<Vector3> spawnPositions = GetSpawnPositions(_tilemap);

        for (int i = 0; i < 2; ++i)
        {
            var spawnPosition = spawnPositions[UnityEngine.Random.Range(0, spawnPositions.Count)];
            Instantiate(_prefab, spawnPosition, Quaternion.identity);
        }



    }
    private List<Vector3> GetSpawnPositions(Tilemap tilemap)
    {
        List<Vector3Int> tilePositions = new();
        List<Vector3> spawnPositions = new();
        BoundsInt bounds = tilemap.cellBounds;
        Vector3Int[] directions = new Vector3Int[] { Vector3Int.up, Vector3Int.down, Vector3Int.left, Vector3Int.right };

        for (int x = bounds.x; x < bounds.x + bounds.size.x; x++)
        {
            for (int y = bounds.y; y < bounds.y + bounds.size.y; y++)
            {
                Vector3Int tilePosition = new Vector3Int(x, y, 0);
                if (tilemap.HasTile(tilePosition))
                {
                    tilePositions.Add(tilePosition);
                }
            }
        }

        foreach (Vector3Int tilePosition in tilePositions)
        {
            foreach (Vector3Int direction in directions)
            {
                Vector3Int potentialSpawnPosition = tilePosition + direction;
                Vector3 centeredSpawnCell = tilemap.GetCellCenterWorld(potentialSpawnPosition);
                if (!tilemap.HasTile(potentialSpawnPosition) && !spawnPositions.Contains(centeredSpawnCell))
                {
                    spawnPositions.Add(centeredSpawnCell);
                }
            }
        }
        return spawnPositions;
    }
}
