
using UnityEngine.Tilemaps;
using UnityEngine;
using System;

public class PlantCardPlacementStrategy : MonoBehaviour, ICardPlacementStrategy //TODO: monobehaviour?
{
    public bool CanPlace(Card card, Vector3Int clickedCell, Tilemap tilemap)
    {
        return card.CardSO.CardType == CardSO.Type.Plant && tilemap.HasTile(clickedCell);
    }

    public GameObject Place(Card card, Vector3Int clickedCell, Vector3 cellCenterWorldPosition, Tilemap tilemap)
    {
        GameObject plant = Instantiate(card.CardSO.PlantPrefab.gameObject, cellCenterWorldPosition, Quaternion.identity);

        
        GameObject tileObject = tilemap.GetInstantiatedObject(clickedCell);

        if (tileObject.TryGetComponent<GrassTileObject>(out var grassTileObjectComponent)) //TODO: can be different from grass in the future
        {
            grassTileObjectComponent.SetObjectOnTile(plant);
        }

        EventManager.Instance.TriggerPlantPlacedEvent(plant, clickedCell);
        Destroy(card.gameObject); //TODO: not the responsiblity of this class

        return plant;
    }
}

