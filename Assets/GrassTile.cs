using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class GrassTile : TileBase
{
    public GameObject tileGameObject;
    public Sprite sprite;

    public override void GetTileData(Vector3Int position, ITilemap tilemap, ref TileData tileData)
    {
        tileData.gameObject = tileGameObject;
        tileData.sprite = sprite;
    }

}
