using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class Walker
{
    private Vector2Int _position;
    private int _steps;

    public Vector2Int Position => _position;

    public Walker(int steps)
    {
        _steps = steps;
        _position = new Vector2Int();
    }

    public void MakeRandomMove()
    {
        for (int i = 0; i <= _steps; i++)
        {
            Vector2Int move = new Vector2Int(Random.Range(-1, 1), Random.Range(-1, 1));
            _position += move;
        }
    }
}

