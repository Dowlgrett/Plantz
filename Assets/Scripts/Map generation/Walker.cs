using System.Collections.Generic;
using UnityEngine;

public class Walker
{
    private Vector2Int _position = new(0, 0);

    public Vector2Int Position => _position;

    public void MakeRandomMove()
    {
        List<Vector2Int> moveList = new()
        {
            Vector2Int.up,
            Vector2Int.down,
            Vector2Int.left,
            Vector2Int.right
        };
        _position += moveList[Random.Range(0, moveList.Count)];
    }
}

