using System.Collections;
using System.Collections.Generic;
using UnityEditor;
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

    #if UNITY_EDITOR
    [MenuItem("Assets/Create/GrassTile")]
    public static void CreateGrassTile()
    {
        string path = EditorUtility.SaveFilePanelInProject("Save Grass Tile", "New Grass Tile", "Asset", "Save Grass Tile", "Assets");
        if (path == "")
            return;
        AssetDatabase.CreateAsset(CreateInstance<GrassTile>(), path);
    }
    #endif

}
