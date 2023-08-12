using System.Collections.Generic;
using UnityEngine;

public class Walker
{
    private Vector2Int _position;

    public Vector2Int Position => _position;

    public Walker()
    {
        _position = new Vector2Int(0, 0);
    }

    public void MakeRandomMove()
    {
        List<Vector2Int> moveList = new();
        moveList.Add(Vector2Int.up);
        moveList.Add(Vector2Int.down);
        moveList.Add(Vector2Int.left);
        moveList.Add(Vector2Int.right);
        _position += moveList[Random.Range(0, moveList.Count)];
    }
}

