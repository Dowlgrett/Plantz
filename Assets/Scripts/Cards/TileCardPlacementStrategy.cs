using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Tilemaps;


public class TileCardPlacementStrategy : MonoBehaviour, ICardPlacementStrategy
{
    [SerializeField] private Tile _grassTile;

    public bool CanPlace(Card card, Vector3Int clickedCell, Tilemap tilemap)
    {
        return card.CardSO.CardType == CardSO.Type.Tile && !tilemap.HasTile(clickedCell);
    }

    public GameObject Place(Card card, Vector3Int clickedCell, Vector3 cellCenterWorldPosition, Tilemap tilemap)
    {
        tilemap.SetTile(clickedCell, _grassTile); //TODO: who is responsible for holding reference to tile?


        Destroy(card.gameObject); //TODO: not your responsiblity
 

        return null;
    }
}
