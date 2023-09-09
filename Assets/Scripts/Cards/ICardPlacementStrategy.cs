using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public interface ICardPlacementStrategy
{
    bool CanPlace(Card card, Vector3Int clickedCell, Tilemap tilemap);
    GameObject Place(Card card, Vector3Int clickedCell, Vector3 cellCenterWorldPosition, Tilemap tilemap);
}
