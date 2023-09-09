
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class EntityPlacer : MonoBehaviour
{
    private Tilemap _tilemap;
    private Dictionary<GameObject, Vector3Int> _plantedPlants;
    [SerializeField] private PlayerSO _playerSO;

    private Dictionary<CardSO.Type, ICardPlacementStrategy> _placementStrategies;

    [SerializeField] private GrassTile _grassTile;

    private void Awake()
    { 
        _plantedPlants = new Dictionary<GameObject, Vector3Int>();


        _placementStrategies = new Dictionary<CardSO.Type, ICardPlacementStrategy>
        {
            { CardSO.Type.Plant, gameObject.AddComponent<PlantCardPlacementStrategy>()},
            { CardSO.Type.Tile, gameObject.AddComponent<TileCardPlacementStrategy>()},
        };
    }
    private void Start()
    {
        _tilemap = FindObjectOfType<Tilemap>();
    }

    private void OnEnable()
    {
        EventManager.Instance.ClickedToPlantEvent += OnClickedToPlant;
        EventManager.Instance.PlantPlacedEvent += OnPlantPlaced;
    }
    private void OnDisable()
    {
        EventManager.Instance.ClickedToPlantEvent -= OnClickedToPlant;
        EventManager.Instance.PlantPlacedEvent -= OnPlantPlaced;

    }
    public void OnClickedToPlant(Vector3 mouseClickPosition)
    {
        Vector3Int clickedCell = _tilemap.WorldToCell(mouseClickPosition);
        Vector3 cellCenterWorldPosition = _tilemap.GetCellCenterWorld(clickedCell);
        Card card = Hand.instance.SelectedCard;

        if (card != null && _playerSO.energy >= card.Cost)
        {

            CardSO.Type cardType = card.CardSO.CardType;
            if (_placementStrategies.ContainsKey(cardType) &&
                _placementStrategies[cardType].CanPlace(card, clickedCell, _tilemap))
            {
                _placementStrategies[cardType].Place(card, clickedCell, cellCenterWorldPosition, _tilemap);
                GameManager.Instance.ChangeEnergyByAmount(-card.CardSO.Cost);
            }
        }
    }

    private void OnPlantPlaced(GameObject plant, Vector3Int cell)
    {
        _plantedPlants.Add(plant, cell);
    }
}
